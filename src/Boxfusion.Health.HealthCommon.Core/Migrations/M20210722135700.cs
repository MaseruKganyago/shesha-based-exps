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
    [Migration(20210722135700)]
    public class M20210722135700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.AmbulanceServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddForeignKeyColumn("PickUpAddressId", "Core_Addresses")
                .AddColumn("ProvisionalCondition").AsString().Nullable()
                .AddColumn("Comment").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.RefferalServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("DepartmentLkp").AsInt64().Nullable()
                .AddColumn("ReferralReason").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.ChwVisitServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("VisitTypeLkp").AsInt64().Nullable()
                .AddColumn("IsSampleCollection").AsBoolean()
                .AddColumn("IsMedicationDelivery").AsBoolean()
                .AddColumn("VisitDate").AsDateTime().Nullable()
                .AddColumn("VisitTime").AsTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.DiagnosticTestServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("ScheduledVisitDate").AsDateTime().Nullable()
                .AddColumn("ScheduledVisitTime").AsTime().Nullable()
                .AddColumn("DiagnosticTestRequired").AsBoolean()
                .AddColumn("ExaminationTypeLkp").AsInt64().Nullable()
                .AddColumn("BodyPartLkp").AsInt64().Nullable()
                .AddColumn("ExamReason").AsString().Nullable();

        }
        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
    [Migration(20210816121400)]
    public class M20210816121400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.ChwVisitServiceRequest
            Delete.Column("VisitTimeTicks").FromTable("Fhir_ServiceRequests");
            Alter.Table("Fhir_ServiceRequests").AddColumn("VisitTimeTicks").AsInt64().Nullable();
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

