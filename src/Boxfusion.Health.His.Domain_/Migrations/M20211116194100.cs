using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211116194100)]
    public class M20211116194100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            ////Rename.Column("TransferFroHospitalId").OnTable("Fhir_Encounters").To("His_TransferFroHospitalId");
            ////Rename.Column("TransferToHospitalId").OnTable("Fhir_Encounters").To("His_TransferToHospitalId");
            ////Rename.Column("HisAdmissionId").OnTable("Fhir_Encounters").To("His_HisAdmissionId");

            Alter.Table("Fhir_Encounters")
                .AddForeignKeyColumn("His_WardId", "Core_Facilities");
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
