using System;
using System.Net.Http;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    public class HttpRpcClientOptions
    {
        /// <summary>
        /// Get/Set the http client handler for the http client connection.
        /// </summary>
        public HttpClientHandler HttpClientHandler { get; set; } = new HttpClientHandler();

        /// <summary>
        /// Get/Set the time delay for the request to be considered as a time out.
        /// </summary>
        public TimeSpan RequestTimeoutDelay { get; set; } = TimeSpan.FromSeconds(100);

        /// <summary>
        /// Get/Set json rpc version.
        /// </summary>
        public string JsonRpcVersion { get; set; } = "2.0";

        /// <summary>
        /// Get/Set json rpc id.
        /// </summary>
        public string JsonRpcId { get; set; } = "0";
    }
}