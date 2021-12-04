using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class CommandRpcGetHeight
{
    public class Response
    {
        /// <summary>
        /// The current blockchain height according to the queried daemon.
        /// </summary>
        [JsonPropertyName("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// General RPC error code. "OK" means everything looks good.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// If the result is obtained using bootstrap mode, and therefore not trusted, or otherwise false.
        /// </summary>
        [JsonPropertyName("untrusted")]
        public bool Untrusted { get; set; }

        /// <summary>
        /// Hash of the block at the current height.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = null!;

        /// <summary>
        /// The latest height in the blockchain that can not be reorganized from (backed by at least 2 Service Node, or 1 hardcoded checkpoint, 0 if N/A).
        /// </summary>
        [JsonPropertyName("immutable_height")]
        public ulong ImmutableHeight { get; set; }

        /// <summary>
        /// Hash of the highest block in the chain that can not be reorganized.
        /// </summary>
        [JsonPropertyName("immutable_hash")]
        public string ImmutableHash { get; set; } = null!;
    }
}

[JsonSerializable(typeof(CommandRpcGetHeight.Response), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class DaemonCommandRpcGetHeightContext : JsonSerializerContext
{
}