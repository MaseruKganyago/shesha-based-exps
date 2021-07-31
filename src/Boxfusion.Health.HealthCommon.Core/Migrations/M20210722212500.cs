using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722212500)]
    public class M20210722212500 : Migration
    {
        public override void Up()
        {
            Delete.Table("Fhir_FhirAddresses");
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

