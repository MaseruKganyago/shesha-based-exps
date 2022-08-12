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
    [Migration(20210811005200)]
    public class M20210811005200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("DepartmentLkp").OnTable("Fhir_ServiceRequests").To("Fhir_DepartmentLkp");
            Rename.Column("ReferralReason").OnTable("Fhir_ServiceRequests").To("Fhir_ReferralReason");
            Rename.Column("Comment").OnTable("Fhir_ServiceRequests").To("Fhir_Comment");
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

