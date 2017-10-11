using GreenPipes;

namespace AzureFunctions.GreenPipes
{
    public class FunctionRequestContext : BasePipeContext, PipeContext
    {
        public string FunctionName { get; }

        public FunctionRequestContext(string functionName)
        {
            FunctionName = functionName;
        }
    }
}
