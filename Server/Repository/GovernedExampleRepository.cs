using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

namespace Playbook.Module.GovernedExample.Repository
{
    public interface IGovernedExampleRepository
    {
        IEnumerable<Models.GovernedExample> GetGovernedExamples(int ModuleId);
        Models.GovernedExample GetGovernedExample(int GovernedExampleId);
        Models.GovernedExample GetGovernedExample(int GovernedExampleId, bool tracking);
        Models.GovernedExample AddGovernedExample(Models.GovernedExample GovernedExample);
        Models.GovernedExample UpdateGovernedExample(Models.GovernedExample GovernedExample);
        void DeleteGovernedExample(int GovernedExampleId);
    }

    public class GovernedExampleRepository : IGovernedExampleRepository, ITransientService
    {
        private readonly IDbContextFactory<GovernedExampleContext> _factory;

        public GovernedExampleRepository(IDbContextFactory<GovernedExampleContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.GovernedExample> GetGovernedExamples(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.GovernedExample.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.GovernedExample GetGovernedExample(int GovernedExampleId)
        {
            return GetGovernedExample(GovernedExampleId, true);
        }

        public Models.GovernedExample GetGovernedExample(int GovernedExampleId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.GovernedExample.Find(GovernedExampleId);
            }
            else
            {
                return db.GovernedExample.AsNoTracking().FirstOrDefault(item => item.GovernedExampleId == GovernedExampleId);
            }
        }

        public Models.GovernedExample AddGovernedExample(Models.GovernedExample GovernedExample)
        {
            using var db = _factory.CreateDbContext();
            db.GovernedExample.Add(GovernedExample);
            db.SaveChanges();
            return GovernedExample;
        }

        public Models.GovernedExample UpdateGovernedExample(Models.GovernedExample GovernedExample)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(GovernedExample).State = EntityState.Modified;
            db.SaveChanges();
            return GovernedExample;
        }

        public void DeleteGovernedExample(int GovernedExampleId)
        {
            using var db = _factory.CreateDbContext();
            Models.GovernedExample GovernedExample = db.GovernedExample.Find(GovernedExampleId);
            db.GovernedExample.Remove(GovernedExample);
            db.SaveChanges();
        }
    }
}

