using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcGetBalance
{
    public class Request
    {
        /// <summary>
        /// Return balance for this account.
        /// </summary>
        [JsonPropertyName("account_index")]
        public uint AccountIndex { get; set; }

        /// <summary>
        /// Return balance detail for those subaddresses.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("address_indices")]
        public uint[]? AddressIndices { get; set; }

        /// <summary>
        /// If true, return balance for all accounts, subaddr_indices and account_index are ignored.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("all_accounts")]
        public bool? AllAccounts { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// The total balance (atomic units) of the currently opened wallet.
        /// </summary>
        [JsonPropertyName("balance")]
        public ulong Balance { get; set; }

        /// <summary>
        /// Unlocked funds are those funds that are sufficiently deep enough in the worktips blockchain to be considered safe to spend.
        /// </summary>
        [JsonPropertyName("unlocked_balance")]
        public ulong UnlockedBalance { get; set; }

        /// <summary>
        /// True if importing multisig data is needed for returning a correct balance.
        /// </summary>
        [JsonPropertyName("multisig_import_needed")]
        public bool MultisigImportNeeded { get; set; }

        /// <summary>
        /// Balance information for each subaddress in an account.
        /// </summary>
        [JsonPropertyName("per_subaddress")]
        public PerSubaddressInfo[] PerSubaddress { get; set; } = null!;

        /// <summary>
        /// The number of blocks remaining for the balance to unlock.
        /// </summary>
        [JsonPropertyName("blocks_to_unlock")]
        public ulong BlocksToUnlock { get; set; }
    }

    public class PerSubaddressInfo
    {
        /// <summary>
        /// Index of the account in the wallet.
        /// </summary>
        [JsonPropertyName("account_index")]
        public uint AccountIndex { get; set; }

        /// <summary>
        /// Index of the subaddress in the account.
        /// </summary>
        [JsonPropertyName("address_index")]
        public uint AddressIndex { get; set; }

        /// <summary>
        /// Address at this index. Base58 representation of the public keys.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        /// <summary>
        /// Balance for the subaddress (locked or unlocked).
        /// </summary>
        [JsonPropertyName("balance")]
        public ulong Balance { get; set; }

        /// <summary>
        /// Unlocked balance for the subaddress.
        /// </summary>
        [JsonPropertyName("unlocked_balance")]
        public ulong UnlockedBalance { get; set; }

        /// <summary>
        /// Label for the subaddress.
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = null!;

        /// <summary>
        /// Number of unspent outputs available for the subaddress.
        /// </summary>
        [JsonPropertyName("num_unspent_outputs")]
        public ulong NumberOfUnspentOutputs { get; set; }

        /// <summary>
        /// The number of blocks remaining for the balance to unlock.
        /// </summary>
        [JsonPropertyName("blocks_to_unlock")]
        public ulong BlocksToUnlock { get; set; }
    }
}

[JsonSerializable(typeof(Request<CommandRpcGetBalance.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcGetBalance.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class WalletCommandRpcGetBalanceContext : JsonSerializerContext
{
}