using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210723043600)]
    public class M20210723043600 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Practitioner
            Alter.Table("Core_Persons")
                .AddColumn("PracticeSANCNumber").AsString().Nullable();

            Delete.Column("PracticeSANCNumber").FromTable("Core_Persons");

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Practitioner
            Alter.Table("Core_Persons")
                .AddColumn("Fhir_PracticeSANCNumber").AsString().Nullable()
                .AddColumn("Fhir_PrimaryPractitionerRole").AsInt32().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

