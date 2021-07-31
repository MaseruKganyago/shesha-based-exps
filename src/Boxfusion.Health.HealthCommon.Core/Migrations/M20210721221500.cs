using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210721221500)]
    public class M20210721221500 : Migration
    {
        public override void Up()
        {         
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirOrganisation
            Create.Table("Fhir_FhirLocations")
                .WithIdAsGuid()
                .WithFullAuditColumns();

        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

