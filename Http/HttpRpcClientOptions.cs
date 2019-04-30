using System;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    internal class HttpRpcClientOptions
    {
        /// <summary>
        /// Get/Set the time delay for the request to be considered as a time out.
        /// </summary>
        public TimeSpan RequestTimeoutDelay { get; set; } = TimeSpan.FromSeconds(100);

        /// <summary>
        /// Get/Set whether to use secure endpoints (https) for the request.
        /// </summary>
        public bool UseSecureEndpoints { get; set; }
    }
}