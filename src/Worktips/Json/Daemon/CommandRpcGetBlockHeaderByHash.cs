using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class CommandRpcGetBlockHeaderByHash
{
    public class Request
    {
        /// <summary>
        /// The block's SHA256 hash.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = null!;

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
        /// A structure containing block header information.
        /// </summary>
        [JsonPropertyName("block_header")]
        public BlockHeaderResponse BlockHeader { get; set; } = null!;

        /// <summary>
        /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
        /// </summary>
        [JsonPropertyName("untrusted")]
        public bool Untrusted { get; set; }
    }
}

[JsonSerializable(typeof(Request<CommandRpcGetBlockHeaderByHash.Request>), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response<CommandRpcGetBlockHeaderByHash.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class DaemonCommandRpcGetBlockHeaderByHashContext : JsonSerializerContext
{
}