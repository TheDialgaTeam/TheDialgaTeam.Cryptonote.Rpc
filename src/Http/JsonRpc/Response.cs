using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

public class Error
{
    [JsonPropertyName("code")]
    public long Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;
}

public class Response : Response<string[]>
{
}

public class Response<TResponse> where TResponse : class
{
    [JsonPropertyName("jsonrpc")]
    public string JsonRpc { get; set; } = null!;

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("result")]
    public TResponse? Result { get; set; }

    [JsonPropertyName("error")]
    public Error? Error { get; set; }
}