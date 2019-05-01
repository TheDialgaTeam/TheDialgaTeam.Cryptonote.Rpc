using System;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
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

        public void Dispose()
        {
            HttpRpcClient?.Dispose();
        }
    }
}