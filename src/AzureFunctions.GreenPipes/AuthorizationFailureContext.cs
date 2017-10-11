using GreenPipes;

namespace AzureFunctions.GreenPipes
{
    public class AuthorizationFailureContext<TWrappedContext> :
        BasePipeContext, PipeContext
        where TWrappedContext : PipeContext
    {
        public AuthorizationFailureContext(TWrappedContext wrappedContext)
        {
            WrappedContext = wrappedContext;
        }

        public TWrappedContext WrappedContext { get; }
    }
}