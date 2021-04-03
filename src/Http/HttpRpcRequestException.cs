using System;
using System.Net;
using System.Net.Http;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    public class HttpRpcRequestException : HttpRequestException
    {
        public HttpRpcRequestException(HttpResponseMessage httpResponseMessage, Exception exception) : base(httpResponseMessage.StatusCode switch
        {
            HttpStatusCode.NotFound => "Invalid RPC endpoint.",
            HttpStatusCode.InternalServerError => httpResponseMessage.ReasonPhrase,
            HttpStatusCode.Unauthorized => "Authentication is required for this RPC request.",
            var _ => exception.Message
        })
        {
        }
    }
}