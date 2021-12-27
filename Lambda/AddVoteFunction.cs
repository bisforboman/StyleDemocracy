using Microsoft.Extensions.DependencyInjection;

namespace StyleDemocracy.Lambda
{
    public class AddVoteFunction : FunctionBase<AddVoteCommand>
    {
        public AddVoteFunction() : base(
            Startup.Initialize()
                .ConfigureServices()
                .BuildServiceProvider())
        {
        }
    }
}
