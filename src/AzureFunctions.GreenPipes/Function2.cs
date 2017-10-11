using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;

namespace AzureFunctions.GreenPipes
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequestMessage req, TraceWriter log)
        {
            var context = new HttpFunctionRequestContext(nameof(Function1), req);

            await Pipelines.Default.Send(context)
                .ConfigureAwait(false);

            return context.HttpResponseMessage;
        }
    }
}
