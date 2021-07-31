using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722170000)]
    public class M20210722170000 : Migration
    {
        public override void Up()
        {
            Delete.Index("IX_Fhir_FhirOrganisations_ParentId").OnTable("Fhir_FhirOrganisations");
            Delete.Index("IX_Fhir_FhirOrganisations_PrimaryAddressId").OnTable("Fhir_FhirOrganisations");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
