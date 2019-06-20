using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet
{
    public class CommandRpcGetBalance
    {
        public class Request
        {
            /// <summary>
            /// Return balance for this account.
            /// </summary>
            [JsonProperty("account_index")]
            public uint AccountIndex { get; set; }

            /// <summary>
            /// Return balance detail for those subaddresses.
            /// </summary>
            [JsonProperty("address_indices", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public uint[] AddressIndices { get; set; }
        }

        public class PerSubaddressInfo
        {
            /// <summary>
            /// Index of the subaddress in the account.
            /// </summary>
            [JsonProperty("account_index")]
            public uint AddressIndex { get; set; }

            /// <summary>
            /// Address at this index. Base58 representation of the public keys.
            /// </summary>
            [JsonProperty("address")]
            public string Address { get; set; }

            /// <summary>
            /// Balance for the subaddress (locked or unlocked).
            /// </summary>
            [JsonProperty("balance")]
            public ulong Balance { get; set; }

            /// <summary>
            /// Unlocked balance for the subaddress.
            /// </summary>
            [JsonProperty("unlocked_balance")]
            public ulong UnlockedBalance { get; set; }

            /// <summary>
            /// Label for the subaddress.
            /// </summary>
            [JsonProperty("label")]
            public string Label { get; set; }

            /// <summary>
            /// Number of unspent outputs available for the subaddress.
            /// </summary>
            [JsonProperty("num_unspent_outputs")]
            public ulong NumUnspentOutputs { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// The total balance of the current monero-wallet-rpc in session.
            /// </summary>
            [JsonProperty("balance")]
            public ulong Balance { get; set; }

            /// <summary>
            /// Unlocked funds are those funds that are sufficiently deep enough in the Monero blockchain to be considered safe to spend.
            /// </summary>
            [JsonProperty("unlocked_balance")]
            public ulong UnlockedBalance { get; set; }

            /// <summary>
            /// True if importing multisig data is needed for returning a correct balance.
            /// </summary>
            [JsonProperty("multisig_import_needed")]
            public bool MultisigImportNeeded { get; set; }

            /// <summary>
            /// Array of subaddress information; Balance information for each subaddress in an account. 
            /// </summary>
            [JsonProperty("per_subaddress")]
            public PerSubaddressInfo[] PerSubaddress { get; set; }
        }
    }
}