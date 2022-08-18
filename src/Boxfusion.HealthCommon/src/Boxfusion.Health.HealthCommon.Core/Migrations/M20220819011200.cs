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
    [Migration(20220819011200)]
    public class M20220819011200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("ReligionLkp").OnTable("Core_Persons").To("Fhir_ReligionLkp");
            Rename.Column("EducationLevelLkp").OnTable("Core_Persons").To("Fhir_EducationLevelLkp");
            
            
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

