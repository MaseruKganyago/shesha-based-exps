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
    [Migration(20220907214900)]
    public class M20220907214900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("SummeryLkp").OnTable("Fhir_Stages").To("SummaryLkp");

            Rename.Column("Severity").OnTable("Fhir_Reactions").To("SeverityLkp");
            Rename.Column("ExposureRoute").OnTable("Fhir_Reactions").To("ExposureRouteLkp");

            Rename.Table("Fhir_ProtocolApplications").To("Fhir_ProtocolApplieds");
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

