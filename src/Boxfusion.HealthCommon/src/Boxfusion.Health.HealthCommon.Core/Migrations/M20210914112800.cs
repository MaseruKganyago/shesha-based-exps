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
    [Migration(20210914112800)]
    public class M20210914112800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("BodyPartLkp").FromTable("Fhir_ServiceRequests");
            Alter.Column("ExamReason").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Rename.Column("ExamReason").OnTable("Fhir_ServiceRequests").To("ExamReasonLkp");

            Alter.Table("Fhir_ServiceRequests")
                 .AddColumn("FacilityTypeLkp").AsInt64().Nullable();
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

