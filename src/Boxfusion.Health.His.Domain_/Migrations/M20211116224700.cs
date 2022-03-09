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
    [Migration(20211116224700)]
    public class M20211116224700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("TransferToHospitalId").OnTable("Fhir_Encounters").To("His_TransferToHospitalId");
            Rename.Column("TransferFroHospitalId").OnTable("Fhir_Encounters").To("His_TransferFroHospitalId");
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
