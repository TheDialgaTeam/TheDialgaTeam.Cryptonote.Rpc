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
        protected HttpClient HttpClient { get; set; }

        protected HttpRpcClientOptions HttpRpcClientOptions { get; }

        protected HttpRpcClient(string hostname, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            if (string.IsNullOrWhiteSpace(hostname))
                throw new ArgumentException("Invalid host to connect.", nameof(hostname));

            if (!hostname.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !hostname.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                hostname = $"http://{hostname}";

            if (!hostname.EndsWith("/"))
                hostname = $"{hostname}/";

            HttpRpcClientOptions = httpRpcClientOptions ?? new HttpRpcClientOptions();
            HttpClient = new HttpClient(HttpRpcClientOptions.HttpClientHandler) { BaseAddress = new Uri(hostname), Timeout = Timeout.InfiniteTimeSpan };
        }

        public async Task<TResponse> GetHttpRpcResponseAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = null;
            var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);

            try
            {
                response = await HttpClient.GetAsync(endpoint, cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<TResponse>(jsonReader);
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }

        public async Task<TResponse> GetHttpRpcResponseAsync<TResponse, TRequest>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = null;
            var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);

            try
            {
                response = await HttpClient.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"), cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<TResponse>(jsonReader);
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }

        public async Task<TResponse> GetHttpJsonRpcResponseAsync<TResponse>(string method, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = null;
            var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);

            try
            {
                response = await HttpClient.PostAsync("json_rpc", new StringContent(JsonConvert.SerializeObject(new JsonRpc.Request { JsonRpc = HttpRpcClientOptions.JsonRpcVersion, Id = HttpRpcClientOptions.JsonRpcId, Method = method }), Encoding.UTF8, "application/json"), cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<JsonRpc.Response<TResponse>>(jsonReader).Result;
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }

        public async Task<TResponse> GetHttpJsonRpcResponseAsync<TResponse, TRequest>(string method, TRequest request, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = null;
            var cancellationTokenSource = new CancellationTokenSource(HttpRpcClientOptions.RequestTimeoutDelay);

            try
            {
                response = await HttpClient.PostAsync("json_rpc", new StringContent(JsonConvert.SerializeObject(new JsonRpc.Request<TRequest> { JsonRpc = HttpRpcClientOptions.JsonRpcVersion, Id = HttpRpcClientOptions.JsonRpcId, Method = method, Parameters = request }), Encoding.UTF8, "application/json"), cancellationToken == default ? cancellationTokenSource.Token : cancellationToken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<JsonRpc.Response<TResponse>>(jsonReader).Result;
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRpcRequestException(response, exception);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}