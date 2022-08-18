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
    [Migration(20220819001300)]
    public class M20220819001300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("NumberOfDependents").OnTable("Core_Persons").To("Fhir_NumberOfDependents");
            Rename.Column("Occupation").OnTable("Core_Persons").To("Fhir_Occupation");
            Rename.Column("NameOfEmployer").OnTable("Core_Persons").To("Fhir_NameOfEmployer");
            Rename.Column("WorkTelephone").OnTable("Core_Persons").To("Fhir_WorkTelephone");
            
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

