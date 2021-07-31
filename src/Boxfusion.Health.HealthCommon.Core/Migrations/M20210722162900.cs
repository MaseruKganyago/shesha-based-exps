using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722162900)]
    public class M20210722162900 : Migration
    {
        public override void Up()
        {
            Delete.Column("Name").FromTable("Fhir_FhirOrganisations");
            Delete.Column("ShortAlias").FromTable("Fhir_FhirOrganisations");
            Delete.ForeignKey("FK_Fhir_FhirOrganisations_ParentId_Fhir_FhirOrganisations_Id").OnTable("Fhir_FhirOrganisations");
            Delete.ForeignKey("FK_Fhir_FhirOrganisations_PrimaryAddressId_Fhir_FhirAddresses_Id").OnTable("Fhir_FhirOrganisations");

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
