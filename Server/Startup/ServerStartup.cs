using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using Playbook.Module.GovernedExample.Repository;
using Playbook.Module.GovernedExample.Services;

namespace Playbook.Module.GovernedExample.Startup
{
    public class ServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGovernedExampleService, ServerGovernedExampleService>();
            services.AddDbContextFactory<GovernedExampleContext>(opt => { }, ServiceLifetime.Transient);
        }
    }
}

