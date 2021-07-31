using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210721224800)]
    public class M20210721224800 : Migration
    {
        public override void Up()
        {
            Rename.Column("Priority").OnTable("Fhir_ServiceRequests").To("PriorityLkp");

            Delete.Column("AsNeededBoolean").FromTable("Fhir_ServiceRequests");
            Delete.Column("DoNotPerform").FromTable("Fhir_ServiceRequests");

            Alter.Table("Fhir_ServiceRequests").AddColumn("AsNeededBoolean").AsBoolean();
            Alter.Table("Fhir_ServiceRequests").AddColumn("DoNotPerform").AsBoolean();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

