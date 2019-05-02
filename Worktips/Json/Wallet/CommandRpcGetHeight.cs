using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet
{
    public class CommandRpcGetHeight
    {
        public class Response
        {
            /// <summary>
            /// The current monero-wallet-rpc's blockchain height. If the wallet has been offline for a long time, it may need to catch up with the daemon.
            /// </summary>
            [JsonProperty("height")]
            public ulong Height { get; set; }
        }
    }
}