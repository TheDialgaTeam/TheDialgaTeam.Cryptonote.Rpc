using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

public class Request : Request<string[]>
{
}

public class Request<TRequest> where TRequest : class
{
    [JsonPropertyName("jsonrpc")]
    public string JsonRpc { get; set; } = null!;

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("method")]
    public string Method { get; set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("params")]
    public TRequest? Parameters { get; set; }
}