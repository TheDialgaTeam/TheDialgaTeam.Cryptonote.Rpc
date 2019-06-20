using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet
{
    public class CommandRpcTransferSplit
    {
        public class TransferDestination
        {
            /// <summary>
            /// Amount to send to each destination, in atomic units.
            /// </summary>
            [JsonProperty("amount")]
            public ulong Amount { get; set; }

            /// <summary>
            /// Destination public address.
            /// </summary>
            [JsonProperty("address")]
            public string Address { get; set; }
        }

        public class Request
        {
            /// <summary>
            /// Array of destinations to receive XMR.
            /// </summary>
            [JsonProperty("destinations")]
            public TransferDestination[] Destinations { get; set; }

            /// <summary>
            /// Transfer from this account index.
            /// </summary>
            [JsonProperty("account_index", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public uint AccountIndex { get; set; }

            /// <summary>
            /// Transfer from this set of subaddresses.
            /// </summary>
            [JsonProperty("subaddr_indices", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public uint[] SubaddrIndices { get; set; }

            /// <summary>
            /// Set a priority for the transactions. Accepted Values are: 0-3 for: default, unimportant, normal, elevated, priority.
            /// </summary>
            [JsonProperty("priority")]
            public uint Priority { get; set; }

            /// <summary>
            /// Number of outputs from the blockchain to mix with (0 means no mixing).
            /// </summary>
            [JsonProperty("mixin")]
            public ulong Mixin { get; set; }

            /// <summary>
            /// Sets ringsize to n (mixin + 1).
            /// </summary>
            [JsonProperty("ring_size")]
            public ulong RingSize { get; set; }

            /// <summary>
            /// Number of blocks before the monero can be spent (0 to not add a lock).
            /// </summary>
            [JsonProperty("unlock_time")]
            public ulong UnlockTime { get; set; }

            /// <summary>
            /// Random 32-byte/64-character hex string to identify a transaction.
            /// </summary>
            [JsonProperty("payment_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string PaymentId { get; set; }

            /// <summary>
            /// Return the transaction keys after sending.
            /// </summary>
            [JsonProperty("get_tx_keys", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool GetTxKeys { get; set; }

            /// <summary>
            /// If true, the newly created transaction will not be relayed to the monero network.
            /// </summary>
            [JsonProperty("do_not_relay", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool DoNotRelay { get; set; }

            /// <summary>
            /// Return the transactions as hex string after sending.
            /// </summary>
            [JsonProperty("get_tx_hex")]
            public bool GetTxHex { get; set; }

            /// <summary>
            /// Return list of transaction metadata needed to relay the transfer later.
            /// </summary>
            [JsonProperty("get_tx_metadata")]
            public bool GetTxMetadata { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// The tx hashes of every transaction.
            /// </summary>
            [JsonProperty("tx_hash_list")]
            public string[] TxHashList { get; set; }

            /// <summary>
            /// The transaction keys for every transaction.
            /// </summary>
            [JsonProperty("tx_key_list")]
            public string[] TxKeyList { get; set; }

            /// <summary>
            /// The amount transferred for every transaction.
            /// </summary>
            [JsonProperty("amount_list")]
            public ulong[] AmountList { get; set; }

            /// <summary>
            /// The amount of fees paid for every transaction.
            /// </summary>
            [JsonProperty("fee_list")]
            public ulong[] FeeList { get; set; }

            /// <summary>
            /// The tx as hex string for every transaction.
            /// </summary>
            [JsonProperty("tx_blob_list")]
            public string[] TxBlobList { get; set; }

            /// <summary>
            /// List of transaction metadata needed to relay the transactions later.
            /// </summary>
            [JsonProperty("tx_metadata_list")]
            public string[] TxMetadataList { get; set; }

            /// <summary>
            /// The set of signing keys used in a multisig transaction (empty for non-multisig).
            /// </summary>
            [JsonProperty("multisig_txset")]
            public string MultisigTxset { get; set; }

            /// <summary>
            /// Set of unsigned tx for cold-signing purposes.
            /// </summary>
            [JsonProperty("unsigned_txset")]
            public string UnsignedTxset { get; set; }
        }
    }
}