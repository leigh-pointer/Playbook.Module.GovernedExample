using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Oqtane.Services;
using Playbook.Module.GovernedExample.Services;

namespace Playbook.Module.GovernedExample.Startup
{
    public class ClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            if (!services.Any(s => s.ServiceType == typeof(IGovernedExampleService)))
            {
                services.AddScoped<IGovernedExampleService, GovernedExampleService>();
            }
        }
    }
}

