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
    [Migration(20220825172500)]
    public class M20220825172500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("entpr_Accounts")
                .AddForeignKeyColumn("Fhir_EncounterId", "Fhir_Encounters")
                .AddForeignKeyColumn("Fhir_SubjectId", "Core_Persons");
            
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

