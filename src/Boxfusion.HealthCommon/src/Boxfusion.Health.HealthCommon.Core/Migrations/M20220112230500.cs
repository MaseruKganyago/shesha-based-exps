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
    [Migration(20220112230500)]
    public class M20220112230500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_ScheduleAvailabilities")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithForeignKeyColumn("ScheduleId", "Fhir_Schedules")
               .WithColumn("Active").AsBoolean()
               .WithColumn("ValidFromDate").AsDateTime().Nullable()
               .WithColumn("ValidToDaTe").AsDateTime().Nullable()
               .WithColumn("TicketPrefix").AsString(30).Nullable()
               .WithColumn("ApplicableDaysLkp").AsInt64().Nullable()
               .WithColumn("StartTimeTicks").AsInt64().Nullable()
               .WithColumn("EndTimeTicks").AsInt64().Nullable()
               .WithColumn("LastGeneratedSlotDate").AsDateTime().Nullable();

            Create.Table("Fhir_ScheduleAvailabiltyForBookings")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("SlotDuration").AsInt32().Nullable()
                .WithColumn("SlotRegularCapacity").AsInt32().Nullable()
                .WithColumn("SlotOverflowCapacity").AsInt32().Nullable()
                .WithColumn("BreakIntervalAfterSlot").AsInt32().Nullable()
                .WithColumn("BookingHorizon").AsInt32().Nullable()
                .WithColumn("SlotGeneratioModeLkp").AsInt64().Nullable();

            Create.Table("Fhir_ScheduleAvailabiltyForWalkins")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("MaxNumWalkIns").AsInt32().Nullable()
                .WithColumn("LatestWalkInTimeTicks").AsInt64().Nullable();

            Create.Table("Fhir_CdmSlots")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("IsGeneratedFromId", "Fhir_ScheduleAvailabilities")
                .WithColumn("CapacityTypeLkp").AsInt64().Nullable()
                .WithColumn("Capacity").AsInt32().Nullable()
                .WithColumn("RemainingCapacity").AsInt32().Nullable();

            Create.Table("Fhir_CdmAppointments")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("Patient", "Core_Persons")
                .WithForeignKeyColumn("Practitioner", "Core_Persons")
                .WithColumn("ArrivalTime").AsDateTime().Nullable()
                .WithColumn("RefNnumber").AsString(100).Nullable()
                .WithColumn("ContactName").AsString(150).Nullable()
                .WithColumn("ContactCellphone").AsString(30).Nullable()
                .WithColumn("IssuedTicketNumber").AsString(30).Nullable()
                .WithColumn("QueuePosition").AsDouble().Nullable()
                .WithColumn("QueuePriority").AsInt32().Nullable()
                .WithColumn("DropOutTime").AsDateTime().Nullable()
                .WithColumn("FirstTimeCalled").AsDateTime().Nullable()
                .WithColumn("LastTimeCalled").AsDateTime().Nullable()
                .WithColumn("NumTimesCalled").AsInt32().Nullable()
                .WithColumn("FulfilledTime").AsDateTime().Nullable()
                .WithColumn("WaitingTimeTicks").AsInt64().Nullable()
                .WithColumn("AlternateContactName").AsString(100).Nullable()
                .WithColumn("AlternateContactCellphone").AsString(30).Nullable();

            Create.Table("Fhir_ScheduleRoleAppointments")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("ScheduleId", "Fhir_Schedules");
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
