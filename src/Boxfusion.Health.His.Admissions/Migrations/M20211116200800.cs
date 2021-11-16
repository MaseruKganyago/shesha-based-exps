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
    [Migration(20211116200800)]
    public class M20211116200800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("HisAdmis_HospitalisationPatientNumber").FromTable("Core_Persons");
            Delete.Column("HisAdmis_ProvinceLkp").FromTable("Core_Persons");
            Delete.Column("HisAdmis_ClassificationLkp").FromTable("Core_Persons");
            Delete.Column("HisAdmis_OtherCategoriesLkp").FromTable("Core_Persons");
            Delete.Column("AdmissionTypeLkp").FromTable("Core_Persons");
            Delete.Column("HisAdmis_AdmissionTypeLkp").FromTable("Core_Persons");
            Delete.Column("HisAdmis_AdmissionStatusLkp").FromTable("Core_Persons");
            Delete.Column("HisAdmis_IdentificationTypeLkp").FromTable("Core_Persons");
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

