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
    [Migration(20211026135700)]
    public class M20211026135700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Appointments")
                .AddColumn("Identifier").AsString(30).Nullable()
                .AddColumn(" StatusLkp").AsInt64().Nullable()
                .AddColumn(" CancelationReasonLkp").AsInt64().Nullable()
                .AddColumn(" ServiceCategoryLkp").AsInt64().Nullable()
                .AddColumn(" ServiceTypeLkp").AsInt64().Nullable()
                .AddColumn(" SpecialityLkp").AsInt64().Nullable()
                .AddColumn(" AppointmentTypeLkp").AsInt64().Nullable()
                .AddColumn(" ReasonCodeLkp").AsInt64().Nullable()
                .AddColumn("ReasonReferenceOwnerId").AsString(30).Nullable()
                .AddColumn("ReasonReferenceOwnerType").AsString(150).Nullable()
                .AddColumn("Priority").AsInt32().Nullable()
                .AddColumn(" Description").AsString(250).Nullable()
                .AddColumn(" SupportingInformationOwnerId").AsString(30).Nullable()
                .AddColumn(" SupportingInformationOwnerType").AsString(150).Nullable()
                .AddColumn("Start").AsDateTime().Nullable()
                .AddColumn("End").AsDateTime().Nullable()
                .AddColumn("MinutesDuration").AsInt32().Nullable()
                .AddForeignKeyColumn("SlotId", "Fhir_Slots")
                .AddColumn("Created").AsDateTime().Nullable()
                .AddColumn("Comment").AsString(400).Nullable()
                .AddColumn("PatientInstruction").AsString(250).Nullable()
                .AddForeignKeyColumn("BasedOnId", "Fhir_ServiceRequests")
                .AddColumn("RequestedPeriodStart").AsDateTime().Nullable()
                .AddColumn("RequestedPeriodEnd").AsDateTime().Nullable();
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
