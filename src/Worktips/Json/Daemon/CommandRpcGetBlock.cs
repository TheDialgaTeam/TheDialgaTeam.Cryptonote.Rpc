using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetBlock
    {
        public class Request
        {
            [JsonProperty("hash")]
            public string Hash { get; set; }

            [JsonProperty("height")]
            public ulong Height { get; set; }

            [JsonProperty("fill_pow_hash")]
            public bool FillPowHash { get; set; }
        }

        public class Response
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("block_header")]
            public BlockHeaderResponse BlockHeader { get; set; }

            [JsonProperty("miner_tx_hash")]
            public string MinerTransactionHash { get; set; }

            [JsonProperty("tx_hashes")]
            public string[]? TransactionHashes { get; set; }

            [JsonProperty("blob")]
            public string Blob { get; set; }

            [JsonProperty("json")]
            public string Json { get; set; }

            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }
        }
    }
}