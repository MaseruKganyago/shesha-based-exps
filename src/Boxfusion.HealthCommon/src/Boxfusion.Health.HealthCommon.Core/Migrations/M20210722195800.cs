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

