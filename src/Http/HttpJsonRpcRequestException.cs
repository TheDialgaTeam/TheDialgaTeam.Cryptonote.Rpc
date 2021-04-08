using System.Net.Http;
using TheDialgaTeam.Cryptonote.Rpc.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    public class HttpJsonRpcRequestException : HttpRequestException
    {
        public JsonRpc.Error Error { get; }

        public HttpJsonRpcRequestException(JsonRpc.Error error) : base(error.Message)
        {
            Error = error;
        }
    }
}