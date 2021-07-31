using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722135700)]
    public class M20210722135700 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.AmbulanceServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddForeignKeyColumn("PickUpAddressId", "Core_Addresses")
                .AddColumn("ProvisionalCondition").AsString().Nullable()
                .AddColumn("Comment").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.RefferalServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("DepartmentLkp").AsInt32().Nullable()
                .AddColumn("ReferralReason").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.ChwVisitServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("VisitTypeLkp").AsInt32().Nullable()
                .AddColumn("IsSampleCollection").AsBoolean()
                .AddColumn("IsMedicationDelivery").AsBoolean()
                .AddColumn("VisitDate").AsDateTime().Nullable()
                .AddColumn("VisitTime").AsTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.DiagnosticTestServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("ScheduledVisitDate").AsDateTime().Nullable()
                .AddColumn("ScheduledVisitTime").AsTime().Nullable()
                .AddColumn("DiagnosticTestRequired").AsBoolean()
                .AddColumn("ExaminationTypeLkp").AsInt32().Nullable()
                .AddColumn("BodyPartLkp").AsInt32().Nullable()
                .AddColumn("ExamReason").AsString().Nullable();

        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

