using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet
{
    public class CommandRpcGetAccounts
    {
        public class Request
        {
            /// <summary>
            /// Tag for filtering accounts.
            /// </summary>
            [JsonProperty("tag", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Tag { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// Total balance of the selected accounts (locked or unlocked).
            /// </summary>
            [JsonProperty("total_balance")]
            public ulong TotalBalance { get; set; }

            /// <summary>
            /// Total unlocked balance of the selected accounts.
            /// </summary>
            [JsonProperty("total_unlocked_balance")]
            public ulong TotalUnlockedBalance { get; set; }

            /// <summary>
            /// Array of subaddress account information.
            /// </summary>
            [JsonProperty("subaddress_accounts")]
            public SubaddressAccountInfo[] SubaddressAccounts { get; set; }
        }

        public class SubaddressAccountInfo
        {
            /// <summary>
            /// Index of the account.
            /// </summary>
            [JsonProperty("account_index")]
            public uint AccountIndex { get; set; }

            /// <summary>
            /// Base64 representation of the first subaddress in the account.
            /// </summary>
            [JsonProperty("base_address")]
            public string BaseAddress { get; set; }

            /// <summary>
            /// Balance of the account (locked or unlocked).
            /// </summary>
            [JsonProperty("balance")]
            public ulong Balance { get; set; }

            /// <summary>
            /// Unlocked balance for the account.
            /// </summary>
            [JsonProperty("unlocked_balance")]
            public ulong UnlockedBalance { get; set; }

            /// <summary>
            /// Label of the account.
            /// </summary>
            [JsonProperty("label")]
            public string Label { get; set; }

            /// <summary>
            /// Tag for filtering accounts.
            /// </summary>
            [JsonProperty("tag")]
            public string Tag { get; set; }
        }
    }
}