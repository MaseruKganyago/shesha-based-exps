using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210728114000)]
    public class M20210728114000 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.LocationJurisdiction
            Alter.Table("Core_Persons")
                .AddColumn("Fhir_MobilePin").AsString().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

