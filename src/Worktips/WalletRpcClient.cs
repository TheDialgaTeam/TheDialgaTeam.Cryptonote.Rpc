using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
using TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips;

public class WalletRpcClient : IDisposable
{
    private readonly HttpRpcClient _httpRpcClient;

    public WalletRpcClient(string host, int port = 31027, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient, HttpClientHandler>? implementationAction = null) : this($"{host}:{port}", httpRpcClientOptions, implementationAction)
    {
    }

    public WalletRpcClient(string hostname, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient, HttpClientHandler>? implementationAction = null)
    {
        _httpRpcClient = new HttpRpcClient(hostname, httpRpcClientOptions, implementationAction);
    }

    /// <summary>
    /// Return the wallet's balance.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetBalance.Response?> GetBalanceAsync(CommandRpcGetBalance.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_balance", request, WalletCommandRpcGetBalanceContext.Default.ResponseResponse, WalletCommandRpcGetBalanceContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Return the wallet's addresses for an account. Optionally filter for specific set of subaddresses.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetAddress.Response?> GetAddressAsync(CommandRpcGetAddress.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_address", request, WalletCommandRpcGetAddressContext.Default.ResponseResponse, WalletCommandRpcGetAddressContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Get all accounts for a wallet. Optionally filter accounts by tag.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetAccounts.Response?> GetAccountsAsync(CommandRpcGetAccounts.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_accounts", request, WalletCommandRpcGetAccountsContext.Default.ResponseResponse, WalletCommandRpcGetAccountsContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Create a new account with an optional label.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcCreateAccount.Response?> CreateAccountAsync(CommandRpcCreateAccount.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("create_account", request, WalletCommandRpcCreateAccountContext.Default.ResponseResponse, WalletCommandRpcCreateAccountContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the wallet's current block height and blockchain immutable height
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcGetHeight.Response?> GetHeightAsync(CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("get_height", WalletCommandRpcGetHeightContext.Default.ResponseResponse, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Same as transfer, but can split into more than one tx if necessary.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcTransferSplit.Response?> TransferSplitAsync(CommandRpcTransferSplit.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("transfer_split", request, WalletCommandRpcTransferSplitContext.Default.ResponseResponse, WalletCommandRpcTransferSplitContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Send all unlocked balance to an address.
    /// </summary>
    /// <param name="request">Parameter for the request.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task<CommandRpcSweepAll.Response?> SweepAllAsync(CommandRpcSweepAll.Request request, CancellationToken cancellationToken = default)
    {
        return await _httpRpcClient.GetHttpJsonRpcResponseAsync("sweep_all", request, WalletCommandRpcSweepAllContext.Default.ResponseResponse, WalletCommandRpcSweepAllContext.Default.RequestRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Save the wallet file.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">.NET Core and .NET 5.0 and later only: The request failed due to timeout.</exception>
    /// <exception cref="HttpRpcRequestException">The HTTP response is unsuccessful.</exception>
    public async Task StoreAsync(CancellationToken cancellationToken = default)
    {
        await _httpRpcClient.GetHttpJsonRpcResponseAsync("store", cancellationToken).ConfigureAwait(false);
    }

    public void Dispose()
    {
        _httpRpcClient.Dispose();
        GC.SuppressFinalize(this);
    }
}