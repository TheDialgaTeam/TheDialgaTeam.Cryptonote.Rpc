using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class CommandRpcGetTransactionPool
{
    public class Response
    {
        /// <summary>
        /// General RPC error code. "OK" means everything looks good.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// List of transactions in the mempool are not in a block on the main chain at the moment.
        /// </summary>
        [JsonPropertyName("transactions")]
        public TransactionInfo[]? Transactions { get; set; }

        /// <summary>
        /// List of spent output key images.
        /// </summary>
        [JsonPropertyName("spent_key_images")]
        public SpentKeyImageInfo[] SpentKeyImages { get; set; } = null!;

        /// <summary>
        /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
        /// </summary>
        [JsonPropertyName("untrusted")]
        public bool Untrusted { get; set; }
    }

    public class TransactionInfo
    {
        /// <summary>
        /// The transaction ID hash.
        /// </summary>
        [JsonPropertyName("id_hash")]
        public string IdHash { get; set; } = null!;

        /// <summary>
        /// JSON structure of all information in the transaction
        /// </summary>
        [JsonPropertyName("tx_json")]
        public string TransactionJson { get; set; } = null!;

        /// <summary>
        /// The size of the full transaction blob.
        /// </summary>
        [JsonPropertyName("blob_size")]
        public ulong BlobSize { get; set; }

        /// <summary>
        /// The weight of the transaction.
        /// </summary>
        [JsonPropertyName("weight")]
        public ulong Weight { get; set; }

        /// <summary>
        /// The amount of the mining fee included in the transaction, in atomic units.
        /// </summary>
        [JsonPropertyName("fee")]
        public ulong Fee { get; set; }

        /// <summary>
        /// Tells the hash of the most recent block with an output used in this transaction.
        /// </summary>
        [JsonPropertyName("max_used_block_id_hash")]
        public string MaxUsedBlockIdHash { get; set; } = null!;

        /// <summary>
        /// Tells the height of the most recent block with an output used in this transaction.
        /// </summary>
        [JsonPropertyName("max_used_block_height")]
        public ulong MaxUsedBlockHeight { get; set; }

        /// <summary>
        /// States if the tx was included in a block at least once (true) or not (false).
        /// </summary>
        [JsonPropertyName("kept_by_block")]
        public bool KeptByBlock { get; set; }

        /// <summary>
        /// If the transaction validation has previously failed, this tells at what height that occured.
        /// </summary>
        [JsonPropertyName("last_failed_height")]
        public ulong LastFailedHeight { get; set; }

        /// <summary>
        /// Like the previous, this tells the previous transaction ID hash.
        /// </summary>
        [JsonPropertyName("last_failed_id_hash")]
        public string LastFailedIdHash { get; set; } = null!;

        /// <summary>
        /// The Unix time that the transaction was first seen on the network by the node.
        /// </summary>
        [JsonPropertyName("receive_time")]
        public ulong ReceiveTime { get; set; }

        /// <summary>
        /// States if this transaction has been relayed.
        /// </summary>
        [JsonPropertyName("relayed")]
        public bool Relayed { get; set; }

        /// <summary>
        /// Last unix time at which the transaction has been relayed.
        /// </summary>
        [JsonPropertyName("last_relayed_time")]
        public ulong LastRelayedTime { get; set; }

        /// <summary>
        /// States if this transaction should not be relayed.
        /// </summary>
        [JsonPropertyName("do_not_relay")]
        public bool DoNotRelay { get; set; }

        /// <summary>
        /// States if this transaction has been seen as double spend.
        /// </summary>
        [JsonPropertyName("double_spend_seen")]
        public bool DoubleSpendSeen { get; set; }

        /// <summary>
        /// Hexadecimal blob representing the transaction.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public string TransactionBlob { get; set; } = null!;

        /// <summary>
        /// True if this is a signed blink transaction.
        /// </summary>
        [JsonPropertyName("blink")]
        public bool Blink { get; set; }
    }

    public class SpentKeyImageInfo
    {
        /// <summary>
        /// Key image.
        /// </summary>
        [JsonPropertyName("id_hash")]
        public string IdHash { get; set; } = null!;

        /// <summary>
        /// List of tx hashes of the txes (usually one) spending that key image.
        /// </summary>
        [JsonPropertyName("txs_hashes")]
        public string[] TransactionHashes { get; set; } = null!;
    }
}

[JsonSerializable(typeof(CommandRpcGetTransactionPool.Response), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class DaemonCommandRpcGetTransactionPoolContext : JsonSerializerContext
{
}