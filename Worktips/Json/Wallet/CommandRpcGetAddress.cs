using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet
{
    public class CommandRpcGetAddress
    {
        public class Request
        {
            /// <summary>
            /// Return subaddresses for this account.
            /// </summary>
            [JsonProperty("account_index")]
            public uint AccountIndex { get; set; }

            /// <summary>
            /// List of subaddresses to return from an account.
            /// </summary>
            [JsonProperty("address_index", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public uint[] AddressIndex { get; set; }
        }

        public class AddressInfo
        {
            /// <summary>
            /// The 95-character hex (sub)address string.
            /// </summary>
            [JsonProperty("address")]
            public string Address { get; set; }

            /// <summary>
            /// Label of the (sub)address
            /// </summary>
            [JsonProperty("label")]
            public string Label { get; set; }

            /// <summary>
            /// Index of the subaddress.
            /// </summary>
            [JsonProperty("address_index")]
            public uint AddressIndex { get; set; }

            /// <summary>
            /// States if the (sub)address has already received funds.
            /// </summary>
            [JsonProperty("used")]
            public bool Used { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// The 95-character hex address string of the monero-wallet-rpc in session.
            /// </summary>
            [JsonProperty("address")]
            public string Address;

            /// <summary>
            /// Array of addresses information.
            /// </summary>
            [JsonProperty("addresses")]
            public AddressInfo[] Addresses;
        }
    }
}