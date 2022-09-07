using Abp.Extensions;
using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220907170900)]
    public class M20220907170900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("CoverageEligibilityResponseStatus").OnTable("Fhir_CoverageEligibilityResponses").To("CoverageEligibilityResponseStatusLkp");
            Rename.Column("CoverageEligibilityResponsePurpose").OnTable("Fhir_CoverageEligibilityResponses").To("CoverageEligibilityResponsePurposeLkp");

            Alter.Table("Fhir_CoverageEligibilityResponses")
                .AddColumn("ItemDescription").AsString(510).Nullable();

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

