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
    [Migration(20211108021400)]
    public class M20211108021400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.His.Admissions.Application.Domain.AdmissionsPatient
            Alter.Table("Core_Persons")
                .AddColumn("HisAdmis_HospitalisationPatientNumber").AsString().Nullable()
                .AddColumn("HisAdmis_ProvinceLkp").AsInt64().Nullable()
                .AddColumn("HisAdmis_ClassificationLkp").AsInt64().Nullable()
                .AddColumn("HisAdmis_OtherCategoriesLkp").AsInt64().Nullable();
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

