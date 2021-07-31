using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722191700)]
    public class M20210722191700 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirLocation
            Alter.Table("Fhir_FhirLocations")
                .AddColumn("NumberOfBeds").AsInt32().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

