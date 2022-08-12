using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20210727133400)]
    public class M20210727133400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_Identifiers_AssignerId_Core_Organisations_Id").OnTable("Fhir_Identifiers");

            //Delete Index
            Delete.Index("IX_Fhir_Identifiers_AssignerId").OnTable("Fhir_Identifiers");

            //Delete AssignerId Column
            Delete.Column("AssignerId").FromTable("Fhir_Identifiers");

            //Delete
            Delete.Table("Fhir_Identifiers");

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Identifier
            Create.Table("Fhir_Identifiers")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("UseLkp").AsInt64().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("System").AsString().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("PeriodStart").AsDateTime().Nullable()
                .WithColumn("PeriodEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("AssignerId", "Core_Organisations");
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

