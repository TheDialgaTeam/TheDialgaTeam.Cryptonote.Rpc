using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class CommandRpcGetBlock
{
    public class Request
    {
        /// <summary>
        /// The block's hash.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// The block's height.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("height")]
        public ulong? Height { get; set; }

        /// <summary>
        /// Tell the daemon if it should fill out pow_hash field.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("fill_pow_hash")]
        public bool? FillPowHash { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// General RPC error code. "OK" means everything looks good.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// A structure containing block header information. See get_last_block_header.
        /// </summary>
        [JsonPropertyName("block_header")]
        public BlockHeaderResponse BlockHeader { get; set; } = null!;

        /// <summary>
        /// Miner transaction information.
        /// </summary>
        [JsonPropertyName("miner_tx_hash")]
        public string MinerTransactionHash { get; set; } = null!;

        /// <summary>
        /// List of hashes of non-coinbase transactions in the block. If there are no other transactions, this will be an empty list.
        /// </summary>
        [JsonPropertyName("tx_hashes")]
        public string[]? TransactionHashes { get; set; }

        /// <summary>
        /// Hexadecimal blob of block information.
        /// </summary>
        [JsonPropertyName("blob")]
        public string Blob { get; set; } = null!;

        /// <summary>
        /// JSON formatted block details.
        /// </summary>
        [JsonPropertyName("json")]
        public string Json { get; set; } = null!;

        /// <summary>
        /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
        /// </summary>
        [JsonPropertyName("untrusted")]
        public bool Untrusted { get; set; }
    }
}

[JsonSerializable(typeof(Request<CommandRpcGetBlock.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcGetBlock.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class DaemonCommandRpcGetBlockContext : JsonSerializerContext
{
}