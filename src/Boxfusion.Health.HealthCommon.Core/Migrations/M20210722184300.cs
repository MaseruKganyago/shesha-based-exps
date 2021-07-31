using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722184300)]
    public class M20210722184300 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirLocation
            Alter.Table("Fhir_FhirLocations")
                .AddColumn("StatusLkp").AsInt32().Nullable()
                .AddColumn("OperationalStatusLkp").AsInt32().Nullable()
                .AddColumn("Alias").AsString().Nullable()
                .AddColumn("ModeLkp").AsInt32().Nullable()
                .AddColumn("TypeLkp").AsInt32().Nullable()
                .AddColumn("PrimaryContactEmail").AsString().Nullable()
                .AddColumn("PrimaryContactTelephone").AsString().Nullable()
                .AddColumn("PhysicalTypeLkp").AsInt32().Nullable()
                .AddColumn("AvailabilityExceptions").AsString().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

