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
    [Migration(20211025155700)]
    public class M20211025155700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_PractitionerRoles")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString(30).Nullable()
                .WithColumn("Active").AsBoolean().Nullable()
                .WithColumn("PeriodStart").AsDateTime().Nullable()
                .WithColumn("PeriodEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("PractitionerId", "Core_Persons")
                .WithForeignKeyColumn("OrganizationId", "Core_Organisations")
                .WithColumn("CodeLkp").AsInt64().Nullable()
                .WithColumn("SpecialityLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithForeignKeyColumn("HealthcareServiceId", "Fhir_HealthcareServices")
                .WithColumn("AvailabilityExceptions").AsString(150).Nullable();
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
