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
    [Migration(20210722004000)]
    public class M20210722004000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ContactPoint
            Create.Table("Fhir_ContactPoints")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("SystemLkp").AsInt64().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("UseLkp").AsInt64().Nullable()
                .WithColumn("Rank").AsInt32().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.HoursOfOperation
            Create.Table("Fhir_HoursOfOperations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("DaysOfWeekLkp").AsInt64().Nullable()
                .WithColumn("AllDay").AsBoolean()
                .WithColumn("AvailableStartTime").AsDateTime().Nullable()
                .WithColumn("AvailableEndime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.NotAvailablePeriod
            Create.Table("Fhir_NotAvailablePeriods")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();
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

