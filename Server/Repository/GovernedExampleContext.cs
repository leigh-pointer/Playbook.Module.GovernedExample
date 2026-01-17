using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Playbook.Module.GovernedExample.Repository
{
    public class GovernedExampleContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.GovernedExample> GovernedExample { get; set; }

        public GovernedExampleContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.GovernedExample>().ToTable(ActiveDatabase.RewriteName("PlaybookGovernedExample"));
        }
    }
}

