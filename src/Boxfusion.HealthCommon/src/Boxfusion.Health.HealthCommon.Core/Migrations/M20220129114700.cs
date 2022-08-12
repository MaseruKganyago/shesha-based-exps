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
    [Migration(20220129114700)]
    public class M20220129114700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_ScheduleRoleAppointments_ScheduleId_Fhir_Schedules_Id").OnTable("Fhir_ScheduleRoleAppointments");

            //Delete Index
            Delete.Index("IX_Fhir_ScheduleRoleAppointments_ScheduleId").OnTable("Fhir_ScheduleRoleAppointments");

            //Delete AssignerId Column
            Delete.Column("ScheduleId").FromTable("Fhir_ScheduleRoleAppointments");

            Delete.Table("Fhir_ScheduleRoleAppointments");

            Alter.Table("Core_ShaRoleAppointments")
                .AddForeignKeyColumn("Fhir_ScheduleId", "Fhir_Schedules");
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

