using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet
{
    public class CommandRpcCreateAccount
    {
        public class Request
        {
            /// <summary>
            /// Label for the account.
            /// </summary>
            [JsonProperty("label", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Label { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// Index of the new account.
            /// </summary>
            [JsonProperty("account_index")]
            public uint AccountIndex { get; set; }

            /// <summary>
            /// Address for this account. Base58 representation of the public keys.
            /// </summary>
            [JsonProperty("address")]
            public string Address { get; set; }
        }
    }
}