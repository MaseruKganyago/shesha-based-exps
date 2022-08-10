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
    [Migration(20211207153300)]
    public class M20211207153300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Encounters").AddColumn("Fhir_FacilityTypeLkp").AsInt64().Nullable();
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

