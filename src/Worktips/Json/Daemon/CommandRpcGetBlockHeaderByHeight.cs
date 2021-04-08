using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetBlockHeaderByHeight
    {
        public class Request
        {
            [JsonProperty("height")]
            public ulong Height { get; set; }

            [JsonProperty("fill_pow_hash", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool FillPowHash { get; set; }
        }

        public class Response
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("block_header")]
            public BlockHeaderResponse BlockHeader { get; set; }

            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }
        }
    }
}