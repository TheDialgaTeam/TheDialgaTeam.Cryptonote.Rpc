using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetBlockHeadersRange
    {
        public class Request
        {
            [JsonProperty("start_height")]
            public ulong StartHeight { get; set; }

            [JsonProperty("end_height")]
            public ulong EndHeight { get; set; }

            [JsonProperty("fill_pow_hash", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool FillPowHash { get; set; }
        }

        public class Response
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("headers")]
            public BlockHeaderResponse[] Headers { get; set; }

            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }
        }
    }
}