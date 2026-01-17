using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Playbook.Module.GovernedExample.Migrations.EntityBuilders
{
    public class GovernedExampleEntityBuilder : AuditableBaseEntityBuilder<GovernedExampleEntityBuilder>
    {
        private const string _entityTableName = "PlaybookGovernedExample";
        private readonly PrimaryKey<GovernedExampleEntityBuilder> _primaryKey = new("PK_PlaybookGovernedExample", x => x.GovernedExampleId);
        private readonly ForeignKey<GovernedExampleEntityBuilder> _moduleForeignKey = new("FK_PlaybookGovernedExample_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public GovernedExampleEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override GovernedExampleEntityBuilder BuildTable(ColumnsBuilder table)
        {
            GovernedExampleId = AddAutoIncrementColumn(table,"GovernedExampleId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> GovernedExampleId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}

