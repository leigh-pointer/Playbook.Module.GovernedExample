using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Playbook.Module.GovernedExample.Services;
using Oqtane.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace Playbook.Module.GovernedExample.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class GovernedExampleController : ModuleControllerBase
    {
        private readonly IGovernedExampleService _GovernedExampleService;

        public GovernedExampleController(IGovernedExampleService GovernedExampleService, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _GovernedExampleService = GovernedExampleService;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<IEnumerable<Models.GovernedExample>> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return await _GovernedExampleService.GetGovernedExamplesAsync(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}/{moduleid}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<Models.GovernedExample> Get(int id, int moduleid)
        {
            Models.GovernedExample GovernedExample = await _GovernedExampleService.GetGovernedExampleAsync(id, moduleid);
            if (GovernedExample != null && IsAuthorizedEntityId(EntityNames.Module, GovernedExample.ModuleId))
            {
                return GovernedExample;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Get Attempt {GovernedExampleId} {ModuleId}", id, moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Models.GovernedExample> Post([FromBody] Models.GovernedExample GovernedExample)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, GovernedExample.ModuleId))
            {
                GovernedExample = await _GovernedExampleService.AddGovernedExampleAsync(GovernedExample);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Post Attempt {GovernedExample}", GovernedExample);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                GovernedExample = null;
            }
            return GovernedExample;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Models.GovernedExample> Put(int id, [FromBody] Models.GovernedExample GovernedExample)
        {
            if (ModelState.IsValid && GovernedExample.GovernedExampleId == id && IsAuthorizedEntityId(EntityNames.Module, GovernedExample.ModuleId))
            {
                GovernedExample = await _GovernedExampleService.UpdateGovernedExampleAsync(GovernedExample);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Put Attempt {GovernedExample}", GovernedExample);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                GovernedExample = null;
            }
            return GovernedExample;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}/{moduleid}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task Delete(int id, int moduleid)
        {
            Models.GovernedExample GovernedExample = await _GovernedExampleService.GetGovernedExampleAsync(id, moduleid);
            if (GovernedExample != null && IsAuthorizedEntityId(EntityNames.Module, GovernedExample.ModuleId))
            {
                await _GovernedExampleService.DeleteGovernedExampleAsync(id, GovernedExample.ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GovernedExample Delete Attempt {GovernedExampleId} {ModuleId}", id, moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}

