using System;
using System.Threading;
using System.Threading.Tasks;
using TheDialgaTeam.Cryptonote.Rpc.Http;
using TheDialgaTeam.Cryptonote.Rpc.Worktips.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips
{
    public class DaemonRpcClient : IDisposable
    {
        private HttpRpcClient HttpRpcClient { get; }

        public DaemonRpcClient(string host, ushort port, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClient = new HttpRpcClient(host, port, httpRpcClientOptions);
        }

        public DaemonRpcClient(string hostname, HttpRpcClientOptions httpRpcClientOptions = null)
        {
            HttpRpcClient = new HttpRpcClient(hostname, httpRpcClientOptions);
        }

        /// <summary>
        /// Get the node's current height.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CommandRpcGetHeight.Response> GetHeightAsync(CancellationToken cancellationToken = default)
        {
            return await HttpRpcClient.GetHttpRpcResponseAsync<CommandRpcGetHeight.Response>("get_height", cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            HttpRpcClient?.Dispose();
        }
    }
}