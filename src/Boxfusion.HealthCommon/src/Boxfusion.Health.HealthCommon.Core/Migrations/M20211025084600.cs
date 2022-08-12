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
    [Migration(20211025084600)]
    public class M20211025084600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Organisations")
                .AddColumn("Fhir_Latitude").AsDecimal().Nullable()
                .AddColumn("Fhir_Longitude").AsDecimal().Nullable()
                .AddColumn("Fhir_Altitude").AsDecimal().Nullable()
                .AddColumn("Fhir_DistrictLkp").AsInt64().Nullable();
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
