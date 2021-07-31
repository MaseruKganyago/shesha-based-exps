using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210727225600)]
    public class M20210727225600 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.LocationJurisdiction
            Alter.Table("Fhir_LocationJurisdictions")
                .AddColumn("FlagsLkp").AsInt64().Nullable()
                .AddColumn("Coordinates").AsString().Nullable()
                .AddColumn("Polygon").AsString().Nullable()
                .AddColumn("Center").AsString().Nullable()
                .AddColumn("AreaCategory").AsInt64().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

