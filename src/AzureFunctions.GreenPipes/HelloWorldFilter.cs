using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using GreenPipes;

namespace AzureFunctions.GreenPipes
{
    public class HelloWorldFilter<TContext> : IFilter<TContext>
        where TContext : HttpFunctionRequestContext
    {
        public void Probe(ProbeContext context)
        {
            context.CreateScope("HelloWorld");
        }

        public async Task Send(TContext context, IPipe<TContext> next)
        {
            context.HttpResponseMessage
                = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent($"Hello World from {context.FunctionName}")
                };

            await next.Send(context)
                .ConfigureAwait(false);
        }
    }
}
