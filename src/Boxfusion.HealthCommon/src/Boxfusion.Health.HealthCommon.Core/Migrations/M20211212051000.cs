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
    [Migration(20211212051000)]
    public class M20211212051000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Conditions")
                 .AddForeignKeyColumn("FhirEncounterId", "Fhir_Encounters");
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

