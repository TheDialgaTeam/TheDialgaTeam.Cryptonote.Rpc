using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
using TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips;

public class DaemonRpcClient : IDisposable
{
    private readonly HttpRpcClient _httpRpcClient;

    public DaemonRpcClient(string host, int port = 31022, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient, HttpClientHandler>? implementationAction = null) : this($"{host}:{port}", httpRpcClientOptions, implementationAction)
    {
    }

    public DaemonRpcClient(string hostname, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient, HttpClientHandler>? implementationAction = null)
    {
        _httpRpcClient = new HttpRpcClient(hostname, httpRpcClientOptions, implementationAction);
    }

    /// <summary>
    /// Get the node's current height.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetHeight.Response?> GetHeightAsync(CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpRpcResponseAsync("get_height", DaemonCommandRpcGetHeightContext.Default.Response, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieve general information about the state of your node and the network.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetInfo.Response?> GetInfoAsync(CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpRpcResponseAsync("get_info", DaemonCommandRpcGetInfoContext.Default.Response, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Look up one or more transactions by hash.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetTransactions.Response?> GetTransactionsAsync(CommandRpcGetTransactions.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpRpcResponseAsync("get_transactions", request, DaemonCommandRpcGetTransactionsContext.Default.Response, DaemonCommandRpcGetTransactionsContext.Default.Request, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Show information about valid transactions seen by the node but not yet mined into a block, as well as spent key image information for the txpool in the node's memory.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetTransactionPool.Response?> GetTransactionPoolAsync(CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpRpcResponseAsync("get_transaction_pool", DaemonCommandRpcGetTransactionPoolContext.Default.Response, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Full block information can be retrieved by either block height or hash, like with the above block header calls. For full block information, both lookups use the same method, but with different input parameters.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetBlock.Response?> GetBlockAsync(CommandRpcGetBlock.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_block", request, DaemonCommandRpcGetBlockContext.Default.ResponseResponse, DaemonCommandRpcGetBlockContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Similar to get_block_header_by_hash above, this method includes a block's height as an input parameter to retrieve basic information about the block.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetBlockHeaderByHeight.Response?> GetBlockHeaderByHeightAsync(CommandRpcGetBlockHeaderByHeight.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_block_header_by_height", request, DaemonCommandRpcGetBlockHeaderByHeightContext.Default.ResponseResponse, DaemonCommandRpcGetBlockHeaderByHeightContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Block header information can be retrieved using either a block's hash or height. This method includes a block's hash as an input parameter to retrieve basic information about the block.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetBlockHeaderByHash.Response?> GetBlockHeaderByHashAsync(CommandRpcGetBlockHeaderByHash.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_block_header_by_hash", request, DaemonCommandRpcGetBlockHeaderByHashContext.Default.ResponseResponse, DaemonCommandRpcGetBlockHeaderByHashContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Similar to get_block_header_by_height above, but for a range of blocks. This method includes a starting block height and an ending block height as parameters to retrieve basic information about the range of blocks.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetBlockHeadersRange.Response?> GetBlockHeadersRangeAsync(CommandRpcGetBlockHeadersRange.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_block_headers_range", request, DaemonCommandRpcGetBlockHeadersRangeContext.Default.ResponseResponse, DaemonCommandRpcGetBlockHeadersRangeContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    public void Dispose()
    {
        _httpRpcClient.Dispose();
        GC.SuppressFinalize(this);
    }
}