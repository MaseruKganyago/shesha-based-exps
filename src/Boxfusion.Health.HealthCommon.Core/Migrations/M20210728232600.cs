﻿using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210728232600)]
    public class M20210728232600 : Migration
    {
        public override void Up()
        {
            Alter.Column("Fhir_Polygon").OnTable("Core_Areas").AsString(4000).Nullable();
            Alter.Column("Fhir_Coordinates").OnTable("Core_Areas").AsString(4000).Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
