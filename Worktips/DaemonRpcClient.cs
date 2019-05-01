using System;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
using TheDialgaTeam.Cryptonote.Rpc.Worktips.Json;
using HttpRpcClient = TheDialgaTeam.Cryptonote.Rpc.Worktips.Http.HttpRpcClient;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips
{
    public class DaemonRpcClient : IDisposable
    {
        private HttpRpcClient HttpRpcClient { get; }

        public DaemonRpcClient(string host, ushort port = 31022, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClient = new HttpRpcClient(host, port, username, password, httpRpcClientOptions);
        }

        public DaemonRpcClient(string hostname, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClient = new HttpRpcClient(hostname, username, password, httpRpcClientOptions);
        }

        /// <summary>
        /// Get the node's current height.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetHeight.Response> GetHeightAsync(CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpRpcResponseAsync<CommandRpcGetHeight.Response>("get_height", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve general information about the state of your node and the network.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetInfo.Response> GetInfoAsync(CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpJsonRpcResponseAsync<CommandRpcGetInfo.Response>("get_info", cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            HttpRpcClient?.Dispose();
        }
    }
}