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
    [Migration(20210722184300)]
    public class M20210722184300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirLocation
            Alter.Table("Fhir_FhirLocations")
                .AddColumn("StatusLkp").AsInt64().Nullable()
                .AddColumn("OperationalStatusLkp").AsInt64().Nullable()
                .AddColumn("Alias").AsString().Nullable()
                .AddColumn("ModeLkp").AsInt64().Nullable()
                .AddColumn("TypeLkp").AsInt64().Nullable()
                .AddColumn("PrimaryContactEmail").AsString().Nullable()
                .AddColumn("PrimaryContactTelephone").AsString().Nullable()
                .AddColumn("PhysicalTypeLkp").AsInt64().Nullable()
                .AddColumn("AvailabilityExceptions").AsString().Nullable();
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

