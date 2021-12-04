using System.Text.Json.Serialization;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Wallet;

public class CommandRpcGetHeight
{
    public class Response
    {
        /// <summary>
        /// The current wallet's blockchain height. If the wallet has been offline for a long time, it may need to catch up with the daemon.
        /// </summary>
        [JsonPropertyName("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// The latest height in the blockchain that can not be reorganized from (backed by atleast 2 Service Node, or 1 hardcoded checkpoint, 0 if N/A).
        /// </summary>
        [JsonPropertyName("immutable_height")]
        public ulong ImmutableHeight { get; set; }
    }
}

[JsonSerializable(typeof(Response<CommandRpcGetHeight.Response>), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class WalletCommandRpcGetHeightContext : JsonSerializerContext
{
}