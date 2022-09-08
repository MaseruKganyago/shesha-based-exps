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
    [Migration(20220907220700)]
    public class M20220907220700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Table("Fhir_Payload").To("Fhir_Payloads");

            Create.Table("Fhir_ImmunisationReactions")
                .WithIdAsGuid()
                .WithAuditColumns()
                .WithColumn("Date").AsString().Nullable()
                .WithForeignKeyColumn("DetailId", "Fhir_Observations").Nullable()
                .WithColumn("Reported").AsBoolean()
                .WithForeignKeyColumn("ImmunisationId", "Fhir_Immunisations");

            Rename.Column("WhoOwnerIdType").OnTable("Fhir_Agents").To("WhoOwnerType");
            Rename.Column("OnBehalfOfOwnerIdType").OnTable("Fhir_Agents").To("OnBehalfOfOwnerType");

            Rename.Table("Fhir_RelationsTo").To("Fhir_RelatesTos");
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

