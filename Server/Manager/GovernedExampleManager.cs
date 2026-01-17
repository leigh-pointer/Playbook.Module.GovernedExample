using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Interfaces;
using Oqtane.Enums;
using Oqtane.Repository;
using Playbook.Module.GovernedExample.Repository;
using System.Threading.Tasks;

namespace Playbook.Module.GovernedExample.Manager
{
    public class GovernedExampleManager : MigratableModuleBase, IInstallable, IPortable, ISearchable
    {
        private readonly IGovernedExampleRepository _GovernedExampleRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public GovernedExampleManager(IGovernedExampleRepository GovernedExampleRepository, IDBContextDependencies DBContextDependencies)
        {
            _GovernedExampleRepository = GovernedExampleRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new GovernedExampleContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new GovernedExampleContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.GovernedExample> GovernedExamples = _GovernedExampleRepository.GetGovernedExamples(module.ModuleId).ToList();
            if (GovernedExamples != null)
            {
                content = JsonSerializer.Serialize(GovernedExamples);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.GovernedExample> GovernedExamples = null;
            if (!string.IsNullOrEmpty(content))
            {
                GovernedExamples = JsonSerializer.Deserialize<List<Models.GovernedExample>>(content);
            }
            if (GovernedExamples != null)
            {
                foreach(var GovernedExample in GovernedExamples)
                {
                    _GovernedExampleRepository.AddGovernedExample(new Models.GovernedExample { ModuleId = module.ModuleId, Name = GovernedExample.Name });
                }
            }
        }

        public Task<List<SearchContent>> GetSearchContentsAsync(PageModule pageModule, DateTime lastIndexedOn)
        {
           var searchContentList = new List<SearchContent>();

           foreach (var GovernedExample in _GovernedExampleRepository.GetGovernedExamples(pageModule.ModuleId))
           {
               if (GovernedExample.ModifiedOn >= lastIndexedOn)
               {
                   searchContentList.Add(new SearchContent
                   {
                       EntityName = "PlaybookGovernedExample",
                       EntityId = GovernedExample.GovernedExampleId.ToString(),
                       Title = GovernedExample.Name,
                       Body = GovernedExample.Name,
                       ContentModifiedBy = GovernedExample.ModifiedBy,
                       ContentModifiedOn = GovernedExample.ModifiedOn
                   });
               }
           }

           return Task.FromResult(searchContentList);
        }
    }
}

