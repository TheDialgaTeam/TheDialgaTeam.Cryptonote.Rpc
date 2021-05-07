using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetTransactionPool
    {
        public class Response
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("transactions")]
            public TransactionInfo[]? Transactions { get; set; }

            [JsonProperty("spent_key_images")]
            public SpentKeyImageInfo[] SpentKeyImages { get; set; }

            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }
        }

        public class TransactionInfo
        {
            [JsonProperty("id_hash")]
            public string IdHash { get; set; }

            [JsonProperty("tx_json")]
            public string TransactionJson { get; set; }

            [JsonProperty("blob_size")]
            public ulong BlobSize { get; set; }

            [JsonProperty("weight")]
            public ulong Weight { get; set; }

            [JsonProperty("fee")]
            public ulong Fee { get; set; }

            [JsonProperty("max_used_block_id_hash")]
            public string MaxUsedBlockIdHash { get; set; }

            [JsonProperty("max_used_block_height")]
            public ulong MaxUsedBlockHeight { get; set; }

            [JsonProperty("kept_by_block")]
            public bool KeptByBlock { get; set; }

            [JsonProperty("last_failed_height")]
            public ulong LastFailedHeight { get; set; }

            [JsonProperty("last_failed_id_hash")]
            public string LastFailedIdHash { get; set; }

            [JsonProperty("receive_time")]
            public long ReceiveTime { get; set; }

            [JsonProperty("relayed")]
            public bool Relayed { get; set; }

            [JsonProperty("last_relayed_time")]
            public ulong LastRelayedTime { get; set; }

            [JsonProperty("do_not_relay")]
            public bool DoNotRelay { get; set; }

            [JsonProperty("double_spend_seen")]
            public bool DoubleSpendSeen { get; set; }

            [JsonProperty("tx_blob")]
            public string TransactionBlob { get; set; }
        }

        public class SpentKeyImageInfo
        {
            [JsonProperty("id_hash")]
            public string IdHash { get; set; }

            [JsonProperty("txs_hashes")]
            public string[] TransactionHashes { get; set; }
        }
    }
}