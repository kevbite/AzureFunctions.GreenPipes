using System.Linq;
using System.Threading.Tasks;
using GreenPipes;

namespace AzureFunctions.GreenPipes
{
    public class AuthorizationFilter<TContext> : IFilter<TContext>
        where TContext : HttpFunctionRequestContext
    {
        private readonly IPipe<AuthorizationFailureContext<TContext>> _authorizationFailurePipe;
        private readonly string _bearerToken;

        public AuthorizationFilter(IPipe<AuthorizationFailureContext<TContext>> authorizationFailurePipe, string bearerToken)
        {
            _authorizationFailurePipe = authorizationFailurePipe;
            _bearerToken = bearerToken;
        }

        public void Probe(ProbeContext context)
        {
            var probeContext = context.CreateScope("Authorization");

            _authorizationFailurePipe.Probe(probeContext);
        }

        public async Task Send(TContext context, IPipe<TContext> next)
        {
            var bearerToken = context.HttpRequestMessage.Headers.Contains("Authorization") ?
                context.HttpRequestMessage.Headers.GetValues("Authorization").FirstOrDefault() : null;

            if (bearerToken != _bearerToken)
            {
                await _authorizationFailurePipe.Send(new AuthorizationFailureContext<TContext>(context))
                    .ConfigureAwait(false);
            }
            else
            {
                await next.Send(context)
                    .ConfigureAwait(false);
            }
        }
    }
}
