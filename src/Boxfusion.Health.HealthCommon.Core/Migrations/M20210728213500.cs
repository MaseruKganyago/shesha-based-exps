using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210728213500)]
    public class M20210728213500 : Migration
    {
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_HealthcareServices_CoverageAreaId_Fhir_LocationJurisdictions_Id").OnTable("Fhir_HealthcareServices");

            //Delete Index
            Delete.Index("IX_Fhir_HealthcareServices_CoverageAreaId").OnTable("Fhir_HealthcareServices");

            //Delete CoverageAreaId Column
            Delete.Column("CoverageAreaId").FromTable("Fhir_HealthcareServices");

            Delete.Table("Fhir_LocationJurisdictions");

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.LocationJurisdiction
            Alter.Table("Core_Areas")
                .AddColumn("Fhir_Coordinates").AsString().Nullable()
                .AddColumn("Fhir_Polygon").AsString().Nullable()
                .AddColumn("Fhir_Center").AsString().Nullable()
                .AddColumn("Fhir_AreaCategoryLkp").AsInt64().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

