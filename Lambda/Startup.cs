using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StyleDemocracy.Lambda
{
    internal static class Startup
    {
        public static IServiceCollection Initialize() => new ServiceCollection();

        public static IServiceCollection ConfigureServices(this IServiceCollection services) => 
            services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
