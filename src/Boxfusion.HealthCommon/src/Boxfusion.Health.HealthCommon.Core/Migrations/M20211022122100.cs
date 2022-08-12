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
    [Migration(20211022122100)]
    public class M20211022122100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Persons")
                .AddColumn("IsSupervisor").AsBoolean().WithDefaultValue(false);

            Alter.Table("Core_ShaRoleAppointments")
                .AddForeignKeyColumn("WardId", "Core_Facilities")
                .AddForeignKeyColumn("HospitalId", "Core_Facilities");
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
