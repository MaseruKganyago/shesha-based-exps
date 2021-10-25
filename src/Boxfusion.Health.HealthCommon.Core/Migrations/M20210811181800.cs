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
    [Migration(20210811181800)]
    public class M20210811181800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("Frwk_Discriminator").AsString(150);

            Rename.Column("Fhir_DepartmentLkp").OnTable("Fhir_ServiceRequests").To("DepartmentLkp");
            Rename.Column("Fhir_ReferralReason").OnTable("Fhir_ServiceRequests").To("ReferralReason");
            Rename.Column("Fhir_Comment").OnTable("Fhir_ServiceRequests").To("Comment");
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

