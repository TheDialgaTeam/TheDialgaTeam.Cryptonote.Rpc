using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcCreateAccount
{
    public class Request
    {
        /// <summary>
        /// (Optional) Label for the account.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("label")]
        public string? Label { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// Index of the new account.
        /// </summary>
        [JsonPropertyName("account_index")]
        public uint AccountIndex { get; set; }

        /// <summary>
        /// The primary address of the new account.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;
    }
}

[JsonSerializable(typeof(Request<CommandRpcCreateAccount.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcCreateAccount.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class WalletCommandRpcCreateAccountContext : JsonSerializerContext
{
}