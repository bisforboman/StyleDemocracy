using Microsoft.Extensions.DependencyInjection;

namespace StyleDemocracy.Lambda
{
    public class SampleFunction : FunctionBase
    {
        public SampleFunction() : base(
            new ServiceCollection()
                .BuildServiceProvider())
        {
        }
    }
}
