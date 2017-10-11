using System.Collections.Generic;
using GreenPipes;

namespace AzureFunctions.GreenPipes
{
    public class AuthorizationSpecification<TContext> : IPipeSpecification<TContext>
        where TContext : HttpFunctionRequestContext
    {
        private readonly IPipe<AuthorizationFailureContext<TContext>> _authorizationFailurePipe;
        private readonly string _bearerToken;

        public AuthorizationSpecification(IPipe<AuthorizationFailureContext<TContext>> authorizationFailurePipe, string bearerToken)
        {
            _authorizationFailurePipe = authorizationFailurePipe;
            _bearerToken = bearerToken;
        }

        public IEnumerable<ValidationResult> Validate()
        {
            if (_authorizationFailurePipe == null)
                yield return this.Failure("authorizationFailurePipe", "You must provide a failure route");
        }

        public void Apply(IPipeBuilder<TContext> builder)
        {
            builder.AddFilter(new AuthorizationFilter<TContext>(_authorizationFailurePipe, _bearerToken));
        }
    }
}