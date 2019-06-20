using System;
using System.Net;
using System.Net.Http;

namespace TheDialgaTeam.Cryptonote.Rpc.Http
{
    public class HttpRpcRequestException : HttpRequestException
    {
        public override string Message { get; }

        public HttpRpcRequestException(HttpResponseMessage httpResponseMessage, Exception exception)
        {
            switch (httpResponseMessage?.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    Message = "Invalid RPC endpoint.";
                    break;

                case HttpStatusCode.InternalServerError:
                    Message = httpResponseMessage.ReasonPhrase;
                    break;

                case HttpStatusCode.Unauthorized:
                    Message = "Authentication is required for this RPC request.";
                    break;

                default:
                    Message = exception.Message;
                    break;
            }
        }
    }
}