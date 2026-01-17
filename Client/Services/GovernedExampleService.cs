using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.Shared;

namespace Playbook.Module.GovernedExample.Services
{
    public interface IGovernedExampleService 
    {
        Task<List<Models.GovernedExample>> GetGovernedExamplesAsync(int ModuleId);

        Task<Models.GovernedExample> GetGovernedExampleAsync(int GovernedExampleId, int ModuleId);

        Task<Models.GovernedExample> AddGovernedExampleAsync(Models.GovernedExample GovernedExample);

        Task<Models.GovernedExample> UpdateGovernedExampleAsync(Models.GovernedExample GovernedExample);

        Task DeleteGovernedExampleAsync(int GovernedExampleId, int ModuleId);
    }

    public class GovernedExampleService : ServiceBase, IGovernedExampleService
    {
        public GovernedExampleService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("GovernedExample");

        public async Task<List<Models.GovernedExample>> GetGovernedExamplesAsync(int ModuleId)
        {
            List<Models.GovernedExample> GovernedExamples = await GetJsonAsync<List<Models.GovernedExample>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.GovernedExample>().ToList());
            return GovernedExamples.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.GovernedExample> GetGovernedExampleAsync(int GovernedExampleId, int ModuleId)
        {
            return await GetJsonAsync<Models.GovernedExample>(CreateAuthorizationPolicyUrl($"{Apiurl}/{GovernedExampleId}/{ModuleId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.GovernedExample> AddGovernedExampleAsync(Models.GovernedExample GovernedExample)
        {
            return await PostJsonAsync<Models.GovernedExample>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, GovernedExample.ModuleId), GovernedExample);
        }

        public async Task<Models.GovernedExample> UpdateGovernedExampleAsync(Models.GovernedExample GovernedExample)
        {
            return await PutJsonAsync<Models.GovernedExample>(CreateAuthorizationPolicyUrl($"{Apiurl}/{GovernedExample.GovernedExampleId}", EntityNames.Module, GovernedExample.ModuleId), GovernedExample);
        }

        public async Task DeleteGovernedExampleAsync(int GovernedExampleId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{GovernedExampleId}/{ModuleId}", EntityNames.Module, ModuleId));
        }
    }
}

