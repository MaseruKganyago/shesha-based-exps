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
    [Migration(20210811001200)]
    public class M20210811001200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ServiceRequest
            Delete.Column("IsSampleCollection").FromTable("Fhir_ServiceRequests");
            Delete.Column("IsMedicationDelivery").FromTable("Fhir_ServiceRequests");
            Delete.Column("DiagnosticTestRequired").FromTable("Fhir_ServiceRequests");

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.ChwVisitServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("IsSampleCollection").AsBoolean().WithDefaultValue(false)
                .AddColumn("IsMedicationDelivery").AsBoolean().WithDefaultValue(false)
                .AddColumn("DiagnosticTestRequired").AsBoolean().WithDefaultValue(false);


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

