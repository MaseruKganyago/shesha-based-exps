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
    [Migration(20210726170500)]
    public class M20210726170500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Schedule
            Alter.Table("Fhir_Schedules")
                .AddColumn("IsActive").AsBoolean().Nullable()
                .AddColumn("ServiceCategoryLkp").AsInt64().Nullable()
                .AddColumn("ServiceTypeLkp").AsInt64().Nullable()
                .AddColumn("SpecialityLkp").AsInt64().Nullable()
                .AddColumn("ActorOwnerId").AsString().Nullable()
                .AddColumn("ActorOwnerType").AsString().Nullable()
                .AddColumn("PlanningHorizonStartDate").AsDateTime().Nullable()
                .AddColumn("PlanningHorizonEndDate").AsDateTime().Nullable()
                .AddColumn("Comment").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ServiceQueue
            Create.Table("Fhir_ServiceQueues")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("ServiceTypeLkp").AsInt64().Nullable()
                .WithColumn("SkillLkp").AsInt64().Nullable()
                .WithColumn("FacilityLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("Fhir_ServiceQueueCapacitiesId", "Core_Areas")
                .WithColumn("SlotSizeInMinutes").AsInt32().Nullable();
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

