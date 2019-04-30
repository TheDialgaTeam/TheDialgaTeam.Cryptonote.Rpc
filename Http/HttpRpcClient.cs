using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    internal class HttpRpcClient : IDisposable
    {
        public HttpClient HttpClient { get; }

        public HttpRpcClientOptions HttpRpcClientOptions { get; }

        public HttpRpcClient(string host, ushort port, HttpRpcClientOptions httpRpcClientOptions = null) : this($"{host}:{port}", httpRpcClientOptions)
        {
        }

        public HttpRpcClient(string hostname, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClientOptions = httpRpcClientOptions ?? new HttpRpcClientOptions();
            HttpClient = new HttpClient { BaseAddress = new Uri($"{(HttpRpcClientOptions.UseSecureEndpoints ? "https" : "http")}://{hostname}/"), Timeout = Timeout.InfiniteTimeSpan };
        }

        public async Task<TResponse> GetHttpRpcResponse<TResponse>(string endpoint, CancellationToken cancellationToken = default)
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

        public async Task<TResponse> GetHttpRpcResponse<TResponse, TRequest>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
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

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}