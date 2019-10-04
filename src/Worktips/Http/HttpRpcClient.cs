using System;
using System.Net;
using System.Net.Http;
using TheDialgaTeam.Cryptonote.Rpc.Http;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Http
{
    internal sealed class HttpRpcClient : Rpc.Http.HttpRpcClient
    {
        public HttpRpcClient(string host, ushort port, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null, Action<HttpClient> implementationAction = null) : this($"{host}:{port}", username, password, httpRpcClientOptions, implementationAction)
        {
        }

        public HttpRpcClient(string hostname, string username = null, string password = null, HttpRpcClientOptions httpRpcClientOptions = null, Action<HttpClient> implementationAction = null) : base(hostname, httpRpcClientOptions)
        {
            if (!string.IsNullOrWhiteSpace(username))
                HttpRpcClientOptions.HttpClientHandler.Credentials = new NetworkCredential(username, password ?? "");

            implementationAction?.Invoke(HttpClient);
        }
    }
}