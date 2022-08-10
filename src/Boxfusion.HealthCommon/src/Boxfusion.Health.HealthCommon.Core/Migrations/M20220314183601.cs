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
    [Migration(20220314183601)]
    public class M20220314183601 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_Appointments_ScheduleId_Fhir_Schedules_Id").OnTable("Fhir_Appointments");

            //Delete Index
            Delete.Index("IX_Fhir_Appointments_ScheduleId").OnTable("Fhir_Appointments");

            //Delete AssignerId Column
            Delete.Column("ScheduleId").FromTable("Fhir_Appointments");
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

