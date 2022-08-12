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
    [Migration(20210722210400)]
    public class M20210722210400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirAddress
            Alter.Table("Core_Addresses")
                .AddColumn("Fhir_OwnerId").AsString().Nullable()
                .AddColumn("Fhir_OwnerType").AsString().Nullable()
                .AddColumn("Fhir_UseLkp").AsInt64().Nullable()
                .AddColumn("Fhir_TypeLkp").AsInt64().Nullable()
                .AddColumn("Fhir_District").AsString().Nullable()
                .AddColumn("Fhir_State").AsString().Nullable()
                .AddColumn("Fhir_Country").AsString().Nullable()
                .AddColumn("Fhir_StartDateTime").AsDateTime().Nullable()
                .AddColumn("Fhir_EndDateTime").AsDateTime().Nullable();
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

