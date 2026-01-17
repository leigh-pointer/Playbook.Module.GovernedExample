using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using Playbook.Module.GovernedExample.Repository;

namespace Playbook.Module.GovernedExample.Services
{
    public class ServerGovernedExampleService : IGovernedExampleService
    {
        private readonly IGovernedExampleRepository _GovernedExampleRepository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public ServerGovernedExampleService(IGovernedExampleRepository GovernedExampleRepository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _GovernedExampleRepository = GovernedExampleRepository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public Task<List<Models.GovernedExample>> GetGovernedExamplesAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_GovernedExampleRepository.GetGovernedExamples(ModuleId).ToList());
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public Task<Models.GovernedExample> GetGovernedExampleAsync(int GovernedExampleId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_GovernedExampleRepository.GetGovernedExample(GovernedExampleId));
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Get Attempt {GovernedExampleId} {ModuleId}", GovernedExampleId, ModuleId);
                return null;
            }
        }

        public Task<Models.GovernedExample> AddGovernedExampleAsync(Models.GovernedExample GovernedExample)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, GovernedExample.ModuleId, PermissionNames.Edit))
            {
                GovernedExample = _GovernedExampleRepository.AddGovernedExample(GovernedExample);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "GovernedExample Added {GovernedExample}", GovernedExample);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Add Attempt {GovernedExample}", GovernedExample);
                GovernedExample = null;
            }
            return Task.FromResult(GovernedExample);
        }

        public Task<Models.GovernedExample> UpdateGovernedExampleAsync(Models.GovernedExample GovernedExample)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, GovernedExample.ModuleId, PermissionNames.Edit))
            {
                GovernedExample = _GovernedExampleRepository.UpdateGovernedExample(GovernedExample);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "GovernedExample Updated {GovernedExample}", GovernedExample);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Update Attempt {GovernedExample}", GovernedExample);
                GovernedExample = null;
            }
            return Task.FromResult(GovernedExample);
        }

        public Task DeleteGovernedExampleAsync(int GovernedExampleId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                _GovernedExampleRepository.DeleteGovernedExample(GovernedExampleId);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "GovernedExample Deleted {GovernedExampleId}", GovernedExampleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Delete Attempt {GovernedExampleId} {ModuleId}", GovernedExampleId, ModuleId);
            }
            return Task.CompletedTask;
        }
    }
}

