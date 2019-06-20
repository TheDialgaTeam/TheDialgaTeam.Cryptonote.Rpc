using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetHeight
    {
        public class Response
        {
            /// <summary>
            /// Current length of longest chain known to daemon.
            /// </summary>
            [JsonProperty("height")]
            public ulong Height { get; set; }

            /// <summary>
            /// General RPC error code. "OK" means everything looks good.
            /// </summary>
            [JsonProperty("Status")]
            public string Status { get; set; }

            /// <summary>
            /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
            /// </summary>
            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }
        }
    }
}