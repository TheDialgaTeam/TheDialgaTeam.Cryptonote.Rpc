using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class CommandRpcGetTransactions
{
    public class Request
    {
        /// <summary>
        /// List of transaction hashes to look up.
        /// </summary>
        [JsonPropertyName("txs_hashes")]
        public string[] TransactionHashes { get; set; } = null!;

        /// <summary>
        /// Optional (false by default). If set true, the returned transaction information will be decoded rather than binary.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("decode_as_json")]
        public bool? DecodeAsJson { get; set; }

        /// <summary>
        /// Prunes the blockchain, drops off 7/8 off the block iirc. Optional (False by default).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("prune")]
        public bool? Prune { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("split")]
        public bool? Split { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// Transaction hashes that could not be found.
        /// </summary>
        [JsonPropertyName("missed_tx")]
        public string[]? MissedTransactions { get; set; }

        /// <summary>
        /// Array of transaction entry.
        /// </summary>
        [JsonPropertyName("txs")]
        public Entry[] Transactions { get; set; } = null!;

        /// <summary>
        /// General RPC error code. "OK" means everything looks good.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
        /// </summary>
        [JsonPropertyName("untrusted")]
        public bool Untrusted { get; set; }
    }

    public class Entry
    {
        /// <summary>
        /// Transaction hash.
        /// </summary>
        [JsonPropertyName("tx_hash")]
        public string TransactionHash { get; set; } = null!;

        /// <summary>
        /// Full transaction information as a hex string.
        /// </summary>
        [JsonPropertyName("as_hex")]
        public string AsHex { get; set; } = null!;

        [JsonPropertyName("pruned_as_hex")]
        public string PrunedAsHex { get; set; } = null!;

        [JsonPropertyName("prunable_as_hex")]
        public string PrunableAsHex { get; set; } = null!;

        [JsonPropertyName("prunable_hash")]
        public string PrunableHash { get; set; } = null!;

        /// <summary>
        /// List of transaction info.
        /// </summary>
        [JsonPropertyName("as_json")]
        public string AsJson { get; set; } = null!;

        /// <summary>
        /// States if the transaction is in pool (true) or included in a block (false).
        /// </summary>
        [JsonPropertyName("in_pool")]
        public bool InPool { get; set; }

        /// <summary>
        /// States if the transaction is a double-spend (true) or not (false).
        /// </summary>
        [JsonPropertyName("double_spend_seen")]
        public bool DoubleSpendSeen { get; set; }

        /// <summary>
        /// Block height including the transaction.
        /// </summary>
        [JsonPropertyName("block_height")]
        public ulong BlockHeight { get; set; }

        /// <summary>
        /// Unix time at chich the block has been added to the blockchain.
        /// </summary>
        [JsonPropertyName("block_timestamp")]
        public ulong BlockTimestamp { get; set; }

        /// <summary>
        /// List of transaction indexes.
        /// </summary>
        [JsonPropertyName("output_indices")]
        public ulong[] OutputIndices { get; set; } = null!;

        [JsonPropertyName("relayed")]
        public bool Relayed { get; set; }

        /// <summary>
        /// True if this is an approved, blink transaction (only for in_pool transactions or txes in recent blocks).
        /// </summary>
        [JsonPropertyName("blink")]
        public bool Blink { get; set; }
    }
}

[JsonSerializable(typeof(CommandRpcGetTransactions.Request), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(CommandRpcGetTransactions.Response), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class DaemonCommandRpcGetTransactionsContext : JsonSerializerContext
{
}