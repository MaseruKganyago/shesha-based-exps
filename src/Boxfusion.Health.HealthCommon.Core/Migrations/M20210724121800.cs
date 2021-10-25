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
    [Migration(20210724121800)]
    public class M20210724121800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Patient
            Alter.Table("Core_Persons")
                .AddColumn("Fhir_IsDisabled").AsBoolean().WithDefaultValue(0)
                .AddColumn("Fhir_IsEmployed").AsBoolean().WithDefaultValue(0)
                .AddColumn("Fhir_HasMedicalAid").AsBoolean().WithDefaultValue(0)
                .AddColumn("Fhir_MedicalAidName").AsString().Nullable()
                .AddColumn("Fhir_MedicalAidNumber").AsString().Nullable();
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

