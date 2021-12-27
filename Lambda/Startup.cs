using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StyleDemocracy.Lambda
{
    internal static class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //Other injected services. 
        }
    }
}
