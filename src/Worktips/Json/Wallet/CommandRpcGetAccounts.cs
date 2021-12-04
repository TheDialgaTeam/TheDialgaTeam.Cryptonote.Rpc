using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcGetAccounts
{
    public class Request
    {
        /// <summary>
        /// (Optional) Tag for filtering accounts. All accounts if empty, otherwise those accounts with this tag.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// Total balance of the selected accounts (locked or unlocked).
        /// </summary>
        [JsonPropertyName("total_balance")]
        public ulong TotalBalance { get; set; }

        /// <summary>
        /// Total unlocked balance of the selected accounts.
        /// </summary>
        [JsonPropertyName("total_unlocked_balance")]
        public ulong TotalUnlockedBalance { get; set; }

        /// <summary>
        /// Array of subaddress account information.
        /// </summary>
        [JsonPropertyName("subaddress_accounts")]
        public SubaddressAccountInfo[] SubaddressAccounts { get; set; } = null!;
    }

    public class SubaddressAccountInfo
    {
        /// <summary>
        /// Index of the account.
        /// </summary>
        [JsonPropertyName("account_index")]
        public uint AccountIndex { get; set; }

        /// <summary>
        /// The first address of the account (i.e. the primary address).
        /// </summary>
        [JsonPropertyName("base_address")]
        public string BaseAddress { get; set; } = null!;

        /// <summary>
        /// Balance of the account (locked or unlocked).
        /// </summary>
        [JsonPropertyName("balance")]
        public ulong Balance { get; set; }

        /// <summary>
        /// Unlocked balance for the account.
        /// </summary>
        [JsonPropertyName("unlocked_balance")]
        public ulong UnlockedBalance { get; set; }

        /// <summary>
        /// (Optional) Label of the account.
        /// </summary>
        [JsonPropertyName("label")]
        public string? Label { get; set; }

        /// <summary>
        /// (Optional) Tag for filtering accounts.
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
    }
}

[JsonSerializable(typeof(Request<CommandRpcGetAccounts.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcGetAccounts.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class WalletCommandRpcGetAccountsContext : JsonSerializerContext
{
}