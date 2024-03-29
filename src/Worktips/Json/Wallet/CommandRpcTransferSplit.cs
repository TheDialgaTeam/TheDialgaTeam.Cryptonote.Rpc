﻿using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcTransferSplit
{
    public class Request
    {
        /// <summary>
        /// Array of destinations to receive WORKTIPS.
        /// </summary>
        [JsonPropertyName("destinations")]
        public TransferDestination[] Destinations { get; set; } = null!;

        /// <summary>
        /// (Optional) Transfer from this account index. (Defaults to 0)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("account_index")]
        public uint? AccountIndex { get; set; }

        /// <summary>
        /// (Optional) Transfer from this set of subaddresses. (Defaults to 0)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("subaddr_indices")]
        public uint[]? SubaddrIndices { get; set; }

        /// <summary>
        /// Set a priority for the transaction. Accepted values are: 1 for unimportant or 5 for blink.  (0 and 2-4 are accepted for backwards compatibility and are equivalent to 5)
        /// </summary>
        [JsonPropertyName("priority")]
        public uint Priority { get; set; }

        /// <summary>
        /// Number of blocks before the worktips can be spent (0 to not add a lock).
        /// </summary>
        [JsonPropertyName("unlock_time")]
        public ulong UnlockTime { get; set; }

        /// <summary>
        /// (Optional) Random 32-byte/64-character hex string to identify a transaction.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("payment_id")]
        public string? PaymentId { get; set; }

        /// <summary>
        /// (Optional) Return the transaction keys after sending.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("get_tx_keys")]
        public bool? GetTransactionKeys { get; set; }

        /// <summary>
        /// (Optional) If true, the newly created transaction will not be relayed to the worktips network. (Defaults to false)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("do_not_relay")]
        public bool? DoNotRelay { get; set; }

        /// <summary>
        /// Return the transactions as hex string after sending.
        /// </summary>
        [JsonPropertyName("get_tx_hex")]
        public bool GetTransactionHex { get; set; }

        /// <summary>
        /// Return list of transaction metadata needed to relay the transfer later.
        /// </summary>
        [JsonPropertyName("get_tx_metadata")]
        public bool GetTransactionMetadata { get; set; }
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

    public class TransferDestination
    {
        /// <summary>
        /// Amount to send to each destination, in atomic units.
        /// </summary>
        [JsonPropertyName("amount")]
        public ulong Amount { get; set; }

        /// <summary>
        /// Destination public address.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;
    }
}

[JsonSerializable(typeof(Request<CommandRpcTransferSplit.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcTransferSplit.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class WalletCommandRpcTransferSplitContext : JsonSerializerContext
{
}