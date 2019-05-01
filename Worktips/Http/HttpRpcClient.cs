using System;
using System.Net;
using System.Net.Http;
using System.Threading;
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
            if (username == null || password == null)
                return;

            HttpClient.Dispose();
            HttpClient = new HttpClient(new HttpClientHandler { Credentials = new NetworkCredential(username, password) }) { BaseAddress = new Uri($"{(HttpRpcClientOptions.UseSecureEndpoints ? "https" : "http")}://{hostname}/"), Timeout = Timeout.InfiniteTimeSpan };
        }
    }
}