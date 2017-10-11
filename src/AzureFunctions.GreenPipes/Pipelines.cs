using System.Net;
using System.Net.Http;
using GreenPipes;

namespace AzureFunctions.GreenPipes
{
    public static class Pipelines
    {
        public static IPipe<AuthorizationFailureContext<HttpFunctionRequestContext>> AuthorizationFailurePipe =
            Pipe.New<AuthorizationFailureContext<HttpFunctionRequestContext>>(cfg => cfg.UseInlineFilter(async (cxt, next) =>
            {
               cxt.WrappedContext.HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
               {
                   Content = new StringContent("🗣 Get lost!")
               }; 
            }));


        public static IPipe<HttpFunctionRequestContext> Default =
            Pipe.New<HttpFunctionRequestContext>(cfg =>
            {
                cfg.AddPipeSpecification(new AuthorizationSpecification<HttpFunctionRequestContext>(AuthorizationFailurePipe, "abc-token"));
                cfg.AddPipeSpecification(new HelloWorldSpecification<HttpFunctionRequestContext>());
            });
    }
}
