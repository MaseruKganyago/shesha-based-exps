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
    [Migration(20210721221600)]
    public class M20210721221600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            ////Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirOrganisation
            //Create.Table("Fhir_FhirOrganisations")
            //    .WithIdAsGuid()
            //    .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.LocationJurisdiction
            Create.Table("Fhir_LocationJurisdictions")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.HealthcareService
            Create.Table("Fhir_HealthcareServices")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("ProvidedById", "Core_Organisations")
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("SpecialityLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Comment").AsString().Nullable()
                .WithColumn("ExtraServiceDetail").AsString().Nullable()
                .WithForeignKeyColumn("PhotoId", "Frwk_StoredFiles")
                .WithForeignKeyColumn("CoverageAreaId", "Fhir_LocationJurisdictions")
                .WithColumn("ServiceProvisionCodeLkp").AsInt64().Nullable()
                .WithColumn("EligibilityComment").AsString().Nullable()
                .WithColumn("CommunicationLkp").AsInt64().Nullable()
                .WithColumn("ReferralMethodLkp").AsInt64().Nullable()
                .WithColumn("AppointmentRequired").AsBoolean()
                .WithColumn("AvailabilityException").AsString().Nullable();
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

