using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210721221000)]
    public class M20210721221000 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Schedule
            Create.Table("Fhir_Schedules")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Slot
            Create.Table("Fhir_Slots")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cmd.CdmServiceRequest
           Alter.Table("Fhir_ServiceRequests")
                .AddColumn("ScheduleTypeLkp").AsInt32().Nullable()
                .AddForeignKeyColumn("ServiceQueueId", "Fhir_Schedules")
                .AddColumn("ServiceQueuePostion").AsDecimal().Nullable()
                .AddColumn("ServiceQueuePriorityLkp").AsInt32().Nullable()
                .AddForeignKeyColumn("BookingSlotId", "Fhir_Slots")
                .AddColumn("ConsultServiceRequestStatusLkp").AsInt32().Nullable()
                .AddColumn("TimeJoinedQueue").AsDateTime().Nullable()
                .AddColumn("TimeCancelled").AsDateTime().Nullable()
                .AddColumn("AllocatedTime").AsDateTime().Nullable()
                .AddForeignKeyColumn("EncounterInitiatedId", "Fhir_Encounters");

        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

