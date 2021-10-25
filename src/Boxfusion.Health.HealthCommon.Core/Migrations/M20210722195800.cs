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
    [Migration(20210722195800)]
    public class M20210722195800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            ////Delete foreign keys from HealthcareServices
            //Delete.ForeignKey("FK_Fhir_HealthcareServices_LocationId_Fhir_FhirLocations_Id").OnTable("Fhir_HealthcareServices");
            //Delete.ForeignKey("FK_Fhir_HealthcareServices_ProvidedById_Fhir_FhirOrganisations_Id").OnTable("Fhir_HealthcareServices");

            ////Delete indexes from HealthcareServices
            //Delete.Index("IX_Fhir_HealthcareServices_LocationId").OnTable("Fhir_HealthcareServices");
            //Delete.Index("IX_Fhir_HealthcareServices_ProvidedById").OnTable("Fhir_HealthcareServices");

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirLocation
            Alter.Table("Core_Facilities")
                .AddColumn("Fhir_StatusLkp").AsInt64().Nullable()
                .AddColumn("Fhir_OperationalStatusLkp").AsInt64().Nullable()
                .AddColumn("Fhir_Alias").AsString().Nullable()
                .AddColumn("Fhir_ModeLkp").AsInt64().Nullable()
                .AddColumn("Fhir_TypeLkp").AsInt64().Nullable()
                .AddColumn("Fhir_PrimaryContactEmail").AsString().Nullable()
                .AddColumn("Fhir_PrimaryContactTelephone").AsString().Nullable()
                .AddColumn("Fhir_PhysicalTypeLkp").AsInt64().Nullable()
                .AddColumn("Fhir_AvailabilityExceptions").AsString().Nullable()
                .AddColumn("Fhir_NumberOfBeds").AsInt32().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirOrganisation
            Alter.Table("Core_Organisations")
                .AddColumn("Fhir_TypeLkp").AsInt64().Nullable()
                .AddColumn("Fhir_PrimaryContactEmail").AsString().Nullable()
                .AddColumn("Fhir_PrimaryContactTelephone").AsString().Nullable();

            //Delete.Table("Fhir_FhirLocations");
            //Delete.Table("Fhir_FhirOrganisations");
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

