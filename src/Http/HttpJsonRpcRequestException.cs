using System.Net.Http;
using TheDialgaTeam.Cryptonote.Rpc.Http.JsonRpc;

namespace TheDialgaTeam.Cryptonote.Rpc.Http;

public class HttpJsonRpcRequestException : HttpRequestException
{
    public Error Error { get; }

    public HttpJsonRpcRequestException(Error error) : base(error.Message)
    {
        Error = error;
    }
}