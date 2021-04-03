using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
using TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;
using HttpRpcClient = TheDialgaTeam.Cryptonote.Rpc.Worktips.Http.HttpRpcClient;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips
{
    public class DaemonRpcClient : IDisposable
    {
        private readonly HttpRpcClient _httpRpcClient;

        public DaemonRpcClient(string host, int port = 31022, string? username = null, string? password = null, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient>? implementationAction = null)
        {
            _httpRpcClient = new HttpRpcClient(host, port, username, password, httpRpcClientOptions, implementationAction);
        }

        public DaemonRpcClient(string hostname, string? username = null, string? password = null, HttpRpcClientOptions? httpRpcClientOptions = null, Action<HttpClient>? implementationAction = null)
        {
            _httpRpcClient = new HttpRpcClient(hostname, username, password, httpRpcClientOptions, implementationAction);
        }

        /// <summary>
        /// Get the node's current height.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetHeight.Response?> GetHeightAsync(CancellationToken cancellationToken = default)
        {
            return await _httpRpcClient.GetHttpRpcResponseAsync<CommandRpcGetHeight.Response>("get_height", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve general information about the state of your node and the network.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetInfo.Response?> GetInfoAsync(CancellationToken cancellationToken = default)
        {
            return await _httpRpcClient.GetHttpRpcResponseAsync<CommandRpcGetInfo.Response>("get_info", cancellationToken).ConfigureAwait(false);
        }

        public async Task<CommandRpcGetTransactions.Response?> GetTransactionsAsync(CommandRpcGetTransactions.Request request, CancellationToken cancellationToken = default)
        {
            return await _httpRpcClient.GetHttpRpcResponseAsync<CommandRpcGetTransactions.Response, CommandRpcGetTransactions.Request>("get_transactions", request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<CommandRpcGetTransactionPool.Response?> GetTransactionPoolAsync(CancellationToken cancellationToken = default)
        {
            return await _httpRpcClient.GetHttpRpcResponseAsync<CommandRpcGetTransactionPool.Response>("get_transaction_pool", cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _httpRpcClient.Dispose();
        }
    }
}