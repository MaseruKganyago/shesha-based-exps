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
    [Migration(20220311090301)]
    public class M20220311090301 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Appointments")
                .AddForeignKeyColumn("ScheduleId", "Fhir_Schedules");
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

