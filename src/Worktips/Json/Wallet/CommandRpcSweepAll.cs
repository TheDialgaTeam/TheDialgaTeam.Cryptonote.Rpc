using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcSweepAll
{
    public class Request
    {
        /// <summary>
        /// Destination public address.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        /// <summary>
        /// Sweep transactions from this account.
        /// </summary>
        [JsonPropertyName("account_index")]
        public uint AccountIndex { get; set; }

        /// <summary>
        /// (Optional) Sweep from this set of subaddresses in the account.
        /// </summary>
        [JsonPropertyName("subaddr_indices")]
        public uint[]? SubaddressIndexes { get; set; }

        /// <summary>
        /// Set a priority for the transaction. Accepted values are: 1 for unimportant or 5 for blink.  (0 and 2-4 are accepted for backwards compatibility and are equivalent to 5)
        /// </summary>
        [JsonPropertyName("priority")]
        public uint Priority { get; set; }

        [JsonPropertyName("outputs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ulong? Outputs { get; set; }

        /// <summary>
        /// Number of blocks before the worktips can be spent (0 to not add a lock).
        /// </summary>
        [JsonPropertyName("unlock_time")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ulong? UnlockTime { get; set; }

        /// <summary>
        /// (Optional) 64-character hex string to identify a transaction.
        /// </summary>
        [JsonPropertyName("payment_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? PaymentId { get; set; }

        /// <summary>
        /// (Optional) Return the transaction keys after sending.
        /// </summary>
        [JsonPropertyName("get_tx_keys")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GetTransactionKeys { get; set; }

        /// <summary>
        /// (Optional) Include outputs below this amount.
        /// </summary>
        [JsonPropertyName("below_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ulong? BelowAmount { get; set; }

        /// <summary>
        /// (Optional) If true, do not relay this sweep transfer. (Defaults to false)
        /// </summary>
        [JsonPropertyName("do_not_relay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DoNotRelay { get; set; }

        /// <summary>
        /// (Optional) return the transactions as hex encoded string. (Defaults to false)
        /// </summary>
        [JsonPropertyName("get_tx_hex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GetTransactionHex { get; set; }

        /// <summary>
        /// (Optional) return the transaction metadata as a string. (Defaults to false)
        /// </summary>
        [JsonPropertyName("get_tx_metadata")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GetTransactionMetaData { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// The tx hashes of every transaction.
        /// </summary>
        [JsonPropertyName("tx_hash_list")]
        public string[] TransactionHashList { get; set; } = null!;

        /// <summary>
        /// The transaction keys for every transaction.
        /// </summary>
        [JsonPropertyName("tx_key_list")]
        public string[] TransactionKeyList { get; set; } = null!;

        /// <summary>
        /// The amount transferred for every transaction.
        /// </summary>
        [JsonPropertyName("amount_list")]
        public ulong[] AmountList { get; set; } = null!;

        /// <summary>
        /// The amount of fees paid for every transaction.
        /// </summary>
        [JsonPropertyName("fee_list")]
        public ulong[] FeeList { get; set; } = null!;

        /// <summary>
        /// The tx as hex string for every transaction.
        /// </summary>
        [JsonPropertyName("tx_blob_list")]
        public string[] TransactionBlobList { get; set; } = null!;

        /// <summary>
        /// List of transaction metadata needed to relay the transactions later.
        /// </summary>
        [JsonPropertyName("tx_metadata_list")]
        public string[] TransactionMetadataList { get; set; } = null!;

        /// <summary>
        /// The set of signing keys used in a multisig transaction (empty for non-multisig).
        /// </summary>
        [JsonPropertyName("multisig_txset")]
        public string MultisigTransactionSet { get; set; } = null!;

        /// <summary>
        /// Set of unsigned tx for cold-signing purposes.
        /// </summary>
        [JsonPropertyName("unsigned_txset")]
        public string UnsignedTransactionSet { get; set; } = null!;
    }
}

[JsonSerializable(typeof(Request<CommandRpcSweepAll.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcSweepAll.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
public partial class WalletCommandRpcSweepAllContext : JsonSerializerContext
{
}