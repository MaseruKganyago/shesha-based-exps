using Abp.Extensions;
using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220907222900)]
    public class M20220907222900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Table("Fhir_ImmunisationReactions");

            Create.Table("Fhir_ImmunisationReactions")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Date").AsString().Nullable()
                .WithForeignKeyColumn("DetailId", "Fhir_Observations").Nullable()
                .WithColumn("Reported").AsBoolean()
                .WithForeignKeyColumn("ImmunisationId", "Fhir_Immunisations").Nullable();

            Rename.Table("Fhir_RelatesTos").To("Fhir_RelatesToes");
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

