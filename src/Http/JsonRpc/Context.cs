using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

[JsonSerializable(typeof(Request), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Response), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class Context : JsonSerializerContext
{
}