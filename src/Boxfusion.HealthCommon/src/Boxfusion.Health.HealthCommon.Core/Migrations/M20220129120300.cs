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
    [Migration(20220129120300)]
    public class M20220129120300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_ScheduleAvailabilities")
                .AddColumn("Frwk_Discriminator").AsString(150);

            Delete.Table("Fhir_ScheduleAvailabiltyForBookings");
            Delete.Table("Fhir_ScheduleAvailabiltyForWalkins");

            Alter.Table("Fhir_ScheduleAvailabilities")
                .AddColumn("SlotDuration").AsInt32().Nullable()
                .AddColumn("SlotRegularCapacity").AsInt32().Nullable()
                .AddColumn("SlotOverflowCapacity").AsInt32().Nullable()
                .AddColumn("BreakIntervalAfterSlot").AsInt32().Nullable()
                .AddColumn("BookingHorizon").AsInt32().Nullable()
                .AddColumn("SlotGeneratioModeLkp").AsInt64().Nullable()
                .AddColumn("MaxNumWalkIns").AsInt32().Nullable()
                .AddColumn("LatestWalkInTimeTicks").AsInt64().Nullable();
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

