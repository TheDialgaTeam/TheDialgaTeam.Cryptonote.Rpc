using System;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
using TheDialgaTeam.Cryptonote.Rpc.Json;
using TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;
using HttpRpcClient = TheDialgaTeam.Cryptonote.Rpc.Worktips.Http.HttpRpcClient;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips
{
    public class WalletRpcClient : IDisposable
    {
        private HttpRpcClient HttpRpcClient { get; }

        public WalletRpcClient(string host, ushort port = 31024, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClient = new HttpRpcClient(host, port, username, password, httpRpcClientOptions);
        }

        public WalletRpcClient(string hostname, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClient = new HttpRpcClient(hostname, username, password, httpRpcClientOptions);
        }

        /// <summary>
        /// Return the wallet's balance.
        /// </summary>
        /// <param name="accountIndex">Return balance for this account.</param>
        /// <param name="addressIndices">Return balance detail for those subaddresses.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetBalance.Response> GetBalanceAsync(uint accountIndex, uint[] addressIndices = null, CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcGetBalance.Response, CommandRpcGetBalance.Request>("get_balance", new CommandRpcGetBalance.Request { AccountIndex = accountIndex, AddressIndices = addressIndices }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Return the wallet's addresses for an account. Optionally filter for specific set of subaddresses.
        /// </summary>
        /// <param name="accountIndex">Return subaddresses for this account.</param>
        /// <param name="addressIndex">List of subaddresses to return from an account.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetAddress.Response> GetAddressAsync(uint accountIndex, uint[] addressIndex = null, CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcGetAddress.Response, CommandRpcGetAddress.Request>("get_address", new CommandRpcGetAddress.Request { AccountIndex = accountIndex, AddressIndex = addressIndex }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all accounts for a wallet. Optionally filter accounts by tag.
        /// </summary>
        /// <param name="tag">Tag for filtering accounts.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetAccounts.Response> GetAccountsAsync(string tag = null, CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcGetAccounts.Response, CommandRpcGetAccounts.Request>("get_accounts", new CommandRpcGetAccounts.Request { Tag = tag }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new account with an optional label.
        /// </summary>
        /// <param name="label">Label for the account.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcCreateAccount.Response> CreateAccountAsync(string label = null, CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcCreateAccount.Response, CommandRpcCreateAccount.Request>("create_account", new CommandRpcCreateAccount.Request { Label = label }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the wallet's current block height.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetHeight.Response> GetHeightAsync(CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcGetHeight.Response>("get_height", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Same as transfer, but can split into more than one tx if necessary.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcTransferSplit.Response> TransferSplitAsync(CommandRpcTransferSplit.Request request, CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcTransferSplit.Response, CommandRpcTransferSplit.Request>("transfer_split", request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Save the wallet file.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task StoreAsync(CancellationToken cancellationToken = default)
        {
            await HttpRpcClient.GetHttpJsonRpcResponseAsync<JsonRpc.Response>("store", cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            HttpRpcClient?.Dispose();
        }
    }
}