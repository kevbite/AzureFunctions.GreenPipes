using System.Net.Http;

namespace AzureFunctions.GreenPipes
{
    public class HttpFunctionRequestContext : FunctionRequestContext
    {
        public HttpFunctionRequestContext(string functionName, HttpRequestMessage httpRequestMessage) : base(
            functionName)
        {
            HttpRequestMessage = httpRequestMessage;
        }

        public HttpRequestMessage HttpRequestMessage { get; }

        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
