using FluentMigrator;
using Shesha;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211217013600)]
    public class M20211217013600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Delete.ForeignKey("FK_Core_ShaRoleAppointments_WardId_Core_Facilities_Id").OnTable("Core_ShaRoleAppointments");
            Delete.Index("IX_Core_ShaRoleAppointments_WardId").OnTable("Core_ShaRoleAppointments");
            Rename.Column("Fhir_WardId").OnTable("Core_ShaRoleAppointments").To("His_WardId");
            Alter.Table("Core_ShaRoleAppointments").AlterColumn("His_WardId").AsGuid().ForeignKey("Core_Facilities", SheshaDatabaseConsts.IdColumn).Indexed().Nullable().Nullable();
            
            Delete.ForeignKey("FK_Core_ShaRoleAppointments_Fhir_HospitalId_Core_Organisations_Id").OnTable("Core_ShaRoleAppointments");
            Delete.Index("IX_Core_ShaRoleAppointments_Fhir_HospitalId").OnTable("Core_ShaRoleAppointments");
            Rename.Column("Fhir_HospitalId").OnTable("Core_ShaRoleAppointments").To("His_HospitalId");
            Alter.Table("Core_ShaRoleAppointments").AlterColumn("His_HospitalId").AsGuid().ForeignKey("Core_Organisations", SheshaDatabaseConsts.IdColumn).Indexed().Nullable().Nullable();
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
