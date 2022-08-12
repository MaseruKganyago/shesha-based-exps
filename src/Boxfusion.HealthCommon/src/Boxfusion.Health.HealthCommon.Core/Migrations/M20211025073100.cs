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
    [Migration(20211025073100)]
    public class M20211025073100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("WardId").OnTable("Core_ShaRoleAppointments").To("Fhir_WardId");
            Rename.Column("HospitalId").OnTable("Core_ShaRoleAppointments").To("Fhir_HospitalId");
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
