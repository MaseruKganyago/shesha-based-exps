using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20210722170000)]
    public class M20210722170000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete.Index("IX_Fhir_FhirOrganisations_ParentId").OnTable("Fhir_FhirOrganisations");
            //Delete.Index("IX_Fhir_FhirOrganisations_PrimaryAddressId").OnTable("Fhir_FhirOrganisations");
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
