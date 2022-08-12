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
    [Migration(20211207170100)]
    public class M20211207170100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("Fhir_FacilityTypeLkp").FromTable("Fhir_Encounters");
            Alter.Table("Core_Organisations").AddColumn("Fhir_FacilityTypeLkp").AsInt64().Nullable();
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

