using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211004145500)]
    public class M20211004145500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.AllergyIntoleranceCodeAssignment
            Create.Table("Fhir_AllergyIntoleranceCodeAssignments")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("AllergyIntoleranceCodeId", "Fhir_AllergyIntoleranceCodes")
                .WithForeignKeyColumn("AllergyIntoleranceId", "Fhir_AllergyIntolerances");
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

