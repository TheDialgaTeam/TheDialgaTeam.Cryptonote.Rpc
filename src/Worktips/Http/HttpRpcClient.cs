using System.Net;
using TheDialgaTeam.Cryptonote.Rpc.Http;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Http
{
    internal sealed class HttpRpcClient : Rpc.Http.HttpRpcClient
    {
        public HttpRpcClient(string host, ushort port, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null) : this($"{host}:{port}", username, password, httpRpcClientOptions)
        {
        }

        public HttpRpcClient(string hostname, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null) : base(hostname, httpRpcClientOptions)
        {
            if (string.IsNullOrWhiteSpace(username))
                return;

            HttpRpcClientOptions.HttpClientHandler.Credentials = new NetworkCredential(username, password ?? "");
        }
    }
}