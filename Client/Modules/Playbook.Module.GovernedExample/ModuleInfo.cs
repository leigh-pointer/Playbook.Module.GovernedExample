using Oqtane.Models;
using Oqtane.Modules;

namespace Playbook.Module.GovernedExample
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "GovernedExample",
            Description = "Playbook GovernedExample",
            Version = "1.0.0",
            ServerManagerType = "Playbook.Module.GovernedExample.Manager.GovernedExampleManager, Playbook.Module.GovernedExample.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Playbook.Module.GovernedExample.Shared.Oqtane",
            PackageName = "Playbook.Module.GovernedExample" 
        };
    }
}

