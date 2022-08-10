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
    [Migration(20220111154100)]
    public class M20220111154100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Slots")
                .AddColumn("Identifier").AsString(30).Nullable()
                .AddColumn("ServiceCategoryLkp").AsInt64().Nullable()
                .AddColumn("ServiceTypeLkp").AsInt64().Nullable()
                .AddColumn("SpecialityLkp").AsInt64().Nullable()
                .AddColumn("AppointmentTypeLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("ScheduleId", "Fhir_Schedules")
                .AddColumn("StatusLkp").AsInt64().Nullable()
                .AddColumn("Start").AsDateTime().Nullable()
                .AddColumn("End").AsDateTime().Nullable()
                .AddColumn("Overbooked").AsBoolean()
                .AddColumn("Comment").AsString(500).Nullable();

            Create.Table("Fhir_CdmSchedules")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithColumn("Name").AsString(150).Nullable()
               .WithColumn("PrioritisationIndex").AsInt32().Nullable()
               .WithColumn("SchedulingModelLkp").AsInt64().Nullable();
           
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
