using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Http;

internal class HttpRpcClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly HttpRpcClientOptions _httpRpcClientOptions;

    public HttpRpcClient(string hostname, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient, HttpClientHandler>? implementationAction = null)
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

        _httpRpcClientOptions = httpRpcClientOptions ?? new HttpRpcClientOptions();

        var httpClientHandler = new HttpClientHandler();
        _httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(hostname) };

        implementationAction?.Invoke(_httpClient, httpClientHandler);
    }

    public async Task<TResponse?> GetHttpRpcResponseAsync<TResponse>(string endpoint, JsonTypeInfo<TResponse> responseTypeInfo, CancellationToken cancellationToken = default) where TResponse : class
    {
        var response = await _httpClient.GetAsync(endpoint, cancellationToken).ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException exception)
        {
            throw new HttpRpcRequestException(response, exception);
        }

        return await response.Content.ReadFromJsonAsync(responseTypeInfo, cancellationToken).ConfigureAwait(false);
    }

    public async Task<TResponse?> GetHttpRpcResponseAsync<TResponse, TRequest>(string endpoint, TRequest request, JsonTypeInfo<TResponse> responseTypeInfo, JsonTypeInfo<TRequest> requestTypeInfo, CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        var response = await _httpClient.PostAsync(endpoint, new StringContent(JsonSerializer.Serialize(request, requestTypeInfo), Encoding.UTF8, "application/json"), cancellationToken).ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException exception)
        {
            throw new HttpRpcRequestException(response, exception);
        }

        return await response.Content.ReadFromJsonAsync(responseTypeInfo, cancellationToken).ConfigureAwait(false);
    }

    public async Task GetHttpJsonRpcResponseAsync(string method, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync("json_rpc", new StringContent(JsonSerializer.Serialize(new Request { JsonRpc = _httpRpcClientOptions.JsonRpcVersion, Id = _httpRpcClientOptions.JsonRpcId, Method = method }, Context.Default.Request), Encoding.UTF8, "application/json"), cancellationToken).ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException exception)
        {
            throw new HttpRpcRequestException(response, exception);
        }
    }

    public async Task<TResponse?> GetHttpJsonRpcResponseAsync<TResponse>(string method, JsonTypeInfo<Response<TResponse>> responseTypeInfo, CancellationToken cancellationToken = default) where TResponse : class
    {
        var response = await _httpClient.PostAsync("json_rpc", new StringContent(JsonSerializer.Serialize(new Request { JsonRpc = _httpRpcClientOptions.JsonRpcVersion, Id = _httpRpcClientOptions.JsonRpcId, Method = method }, Context.Default.Request), Encoding.UTF8, "application/json"), cancellationToken).ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException exception)
        {
            throw new HttpRpcRequestException(response, exception);
        }

        var result = await response.Content.ReadFromJsonAsync(responseTypeInfo, cancellationToken).ConfigureAwait(false);

        if (result?.Error != null)
        {
            throw new HttpJsonRpcRequestException(result.Error);
        }

        return result?.Result;
    }

    public async Task<TResponse?> GetHttpJsonRpcResponseAsync<TResponse, TRequest>(string method, TRequest request, JsonTypeInfo<Response<TResponse>> responseTypeInfo, JsonTypeInfo<Request<TRequest>> requestTypeInfo, CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        var response = await _httpClient.PostAsync("json_rpc", new StringContent(JsonSerializer.Serialize(new Request<TRequest> { JsonRpc = _httpRpcClientOptions.JsonRpcVersion, Id = _httpRpcClientOptions.JsonRpcId, Method = method, Parameters = request }, requestTypeInfo), Encoding.UTF8, "application/json"), cancellationToken).ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException exception)
        {
            throw new HttpRpcRequestException(response, exception);
        }

        var result = await response.Content.ReadFromJsonAsync(responseTypeInfo, cancellationToken).ConfigureAwait(false);

        if (result?.Error != null)
        {
            throw new HttpJsonRpcRequestException(result.Error);
        }

        return result?.Result;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}