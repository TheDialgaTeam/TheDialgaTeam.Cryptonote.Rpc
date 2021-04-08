using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetTransactions
    {
        public class Request
        {
            [JsonProperty("txs_hashes")]
            public string[] TransactionHashes { get; set; }

            [JsonProperty("decode_as_json")]
            public bool DecodeAsJson { get; set; }

            [JsonProperty("prune", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool Prune { get; set; }

            [JsonProperty("split", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool Split { get; set; }
        }

        public class Response
        {
            [JsonProperty("txs_as_hex")]
            public string[] TransactionsAsHex { get; set; }

            [JsonProperty("txs_as_json")]
            public string[] TransactionsAsJson { get; set; }

            [JsonProperty("missed_tx")]
            public string[] MissedTransactions { get; set; }

            [JsonProperty("txs")]
            public Entry[] Transactions { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }
        }

        public class Entry
        {
            [JsonProperty("tx_hash")]
            public string TransactionHash { get; set; }

            [JsonProperty("as_hex")]
            public string AsHex { get; set; }

            [JsonProperty("pruned_as_hex")]
            public string PrunedAsHex { get; set; }

            [JsonProperty("prunable_as_hex")]
            public string PrunableAsHex { get; set; }

            [JsonProperty("prunable_hash")]
            public string PrunableHash { get; set; }

            [JsonProperty("as_json")]
            public string AsJson { get; set; }

            [JsonProperty("in_pool")]
            public bool InPool { get; set; }

            [JsonProperty("double_spend_seen")]
            public bool DoubleSpendSeen { get; set; }

            [JsonProperty("block_height")]
            public ulong BlockHeight { get; set; }

            [JsonProperty("block_timestamp")]
            public ulong BlockTimestamp { get; set; }

            [JsonProperty("output_indices")]
            public ulong[] OutputIndices { get; set; }
        }
    }
}