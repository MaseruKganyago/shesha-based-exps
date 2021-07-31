using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210721221600)]
    public class M20210721221600 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirOrganisation
            Create.Table("Fhir_FhirOrganisations")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.LocationJurisdiction
            Create.Table("Fhir_LocationJurisdictions")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.HealthcareService
            Create.Table("Fhir_HealthcareServices")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("ProvidedById", "Fhir_FhirOrganisations")
                .WithColumn("CategoryLkp").AsInt32().Nullable()
                .WithColumn("TypeLkp").AsInt32().Nullable()
                .WithColumn("SpecialityLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("LocationId", "Fhir_FhirLocations")
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Comment").AsString().Nullable()
                .WithColumn("ExtraServiceDetail").AsString().Nullable()
                .WithForeignKeyColumn("PhotoId", "Frwk_StoredFiles")
                .WithForeignKeyColumn("CoverageAreaId", "Fhir_LocationJurisdictions")
                .WithColumn("ServiceProvisionCodeLkp").AsInt32().Nullable()
                .WithColumn("EligibilityComment").AsString().Nullable()
                .WithColumn("CommunicationLkp").AsInt32().Nullable()
                .WithColumn("ReferralMethodLkp").AsInt32().Nullable()
                .WithColumn("AppointmentRequired").AsBoolean()
                .WithColumn("AvailabilityException").AsString().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

