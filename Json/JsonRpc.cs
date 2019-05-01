using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Json
{
    public class JsonRpc
    {
        public class Request : Request<string[]>
        {
        }

        public class Request<TRequest>
        {
            [JsonProperty("jsonrpc", Required = Required.Always)]
            public string JsonRpc { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("method", Required = Required.Always)]
            public string Method { get; set; }

            [JsonProperty("params")]
            public TRequest Parameters { get; set; }
        }

        public class Error
        {
            [JsonProperty("code")]
            public ulong Code { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public class Response<TResponse>
        {
            [JsonProperty("jsonrpc")]
            public string JsonRpc { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("result")]
            public TResponse Result { get; set; }

            [JsonProperty("error")]
            public Error Error { get; set; }
        }
    }
}