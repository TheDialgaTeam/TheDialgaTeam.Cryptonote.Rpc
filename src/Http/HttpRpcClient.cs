using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheDialgaTeam.Cryptonote.Rpc.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    internal abstract class HttpRpcClient : IDisposable
    {
        protected HttpClient HttpClient { get; }

        protected HttpRpcClientOptions HttpRpcClientOptions { get; }

        protected HttpRpcClient(string hostname, HttpRpcClientOptions? httpRpcClientOptions = null)
        {
            if (string.IsNullOrWhiteSpace(hostname)) throw new ArgumentException("Invalid host to connect.", nameof(hostname));

            if (!hostname.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !hostname.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                hostname = $"http://{hostname}";
            }

            if (!hostname.EndsWith("/"))
            {
                hostname = $"{hostname}/";
            }

            HttpRpcClientOptions = httpRpcClientOptions ?? new HttpRpcClientOptions();
            HttpClient = new HttpClient(HttpRpcClientOptions.HttpClientHandler) { BaseAddress = new Uri(hostname), Timeout = Timeout.InfiniteTimeSpan };
        }

        public async Task<TResponse?> GetHttpRpcResponseAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default) where TResponse : class
        {
            using var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);
            var response = await HttpClient.GetAsync(endpoint, cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);
            
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            using var jsonReader = new JsonTextReader(streamReader);

            return JsonSerializer.Create().Deserialize<TResponse>(jsonReader);
        }

        public async Task<TResponse?> GetHttpRpcResponseAsync<TResponse, TRequest>(string endpoint, TRequest request, CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
        {
            using var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);
            var response = await HttpClient.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"), cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            using var jsonReader = new JsonTextReader(streamReader);

            return JsonSerializer.Create().Deserialize<TResponse>(jsonReader);
        }

        public async Task<TResponse?> GetHttpJsonRpcResponseAsync<TResponse>(string method, CancellationToken cancellationToken = default) where TResponse : class
        {
            using var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);
            var response = await HttpClient.PostAsync("json_rpc", new StringContent(JsonConvert.SerializeObject(new JsonRpc.Request { JsonRpc = HttpRpcClientOptions.JsonRpcVersion, Id = HttpRpcClientOptions.JsonRpcId, Method = method }), Encoding.UTF8, "application/json"), cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            using var jsonReader = new JsonTextReader(streamReader);

            var result = JsonSerializer.Create().Deserialize<JsonRpc.Response<TResponse>>(jsonReader);

            if (result?.Error != null)
            {
                throw new HttpJsonRpcRequestException(result.Error);
            }

            return result?.Result;
        }

        public async Task<TResponse?> GetHttpJsonRpcResponseAsync<TResponse, TRequest>(string method, TRequest request, CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
        {
            using var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);
            var response = await HttpClient.PostAsync("json_rpc", new StringContent(JsonConvert.SerializeObject(new JsonRpc.Request<TRequest> { JsonRpc = HttpRpcClientOptions.JsonRpcVersion, Id = HttpRpcClientOptions.JsonRpcId, Method = method, Parameters = request }), Encoding.UTF8, "application/json"), cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            using var jsonReader = new JsonTextReader(streamReader);

            var result = JsonSerializer.Create().Deserialize<JsonRpc.Response<TResponse>>(jsonReader);

            if (result?.Error != null)
            {
                throw new HttpJsonRpcRequestException(result.Error);
            }

            return result?.Result;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}