namespace TheDialgaTeam.Cryptonote.Rpc.Http;

public class HttpRpcClientOptions
{
    /// <summary>
    /// Get/Set json rpc version.
    /// </summary>
    public string JsonRpcVersion { get; set; } = "2.0";

    /// <summary>
    /// Get/Set json rpc id.
    /// </summary>
    public int JsonRpcId { get; set; } = 1;
}