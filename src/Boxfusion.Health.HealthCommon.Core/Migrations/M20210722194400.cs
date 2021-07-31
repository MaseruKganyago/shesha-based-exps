using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722194400)]
    public class M20210722194400 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.LocationJurisdiction
            Alter.Table("Core_Areas")
                .AddColumn("Fhir_FlagsLkp").AsInt32().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

