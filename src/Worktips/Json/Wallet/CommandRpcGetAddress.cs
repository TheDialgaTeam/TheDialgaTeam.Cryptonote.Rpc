using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcGetAddress
{
    public class Request
    {
        /// <summary>
        /// Get the wallet addresses for the specified account.
        /// </summary>
        [JsonPropertyName("account_index")]
        public uint AccountIndex { get; set; }

        /// <summary>
        /// (Optional) List of subaddresses to return from the aforementioned account.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("address_index")]
        public uint[]? AddressIndex { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// Array of addresses information.
        /// </summary>
        [JsonPropertyName("addresses")]
        public AddressInfo[] Addresses { get; set; } = null!;
    }

    public class AddressInfo
    {
        /// <summary>
        /// The (sub)address string.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        /// <summary>
        /// Label of the (sub)address
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = null!;

        /// <summary>
        /// Index of the subaddress.
        /// </summary>
        [JsonPropertyName("address_index")]
        public uint AddressIndex { get; set; }

        /// <summary>
        /// True if the (sub)address has received funds before.
        /// </summary>
        [JsonPropertyName("used")]
        public bool Used { get; set; }
    }
}

[JsonSerializable(typeof(Request<CommandRpcGetAddress.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcGetAddress.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class WalletCommandRpcGetAddressContext : JsonSerializerContext
{
}