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
    [Migration(20211026103500)]
    public class M20211026103500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.ForeignKey("FK_Core_ShaRoleAppointments_HospitalId_Core_Facilities_Id").OnTable("Core_ShaRoleAppointments");
            Delete.Index("IX_Core_ShaRoleAppointments_HospitalId").OnTable("Core_ShaRoleAppointments");
            Delete.Column("Fhir_HospitalId").FromTable("Core_ShaRoleAppointments");

            Alter.Table("Core_ShaRoleAppointments")
                .AddForeignKeyColumn("Fhir_HospitalId", "Core_Organisations");
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

