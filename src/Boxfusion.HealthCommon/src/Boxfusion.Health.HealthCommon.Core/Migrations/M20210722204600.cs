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
    [Migration(20210722204600)]
    public class M20210722204600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
        //    Delete.Column("LocationId").FromTable("Fhir_HealthcareServices");
        //    Delete.Column("ProvidedById").FromTable("Fhir_HealthcareServices");

        //    //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.HealthcareServices
        //    Alter.Table("Fhir_HealthcareServices")
        //         .AddForeignKeyColumn("LocationId", "Core_Facilities")
        //         .AddForeignKeyColumn("ProvidedById", "Core_Organisations");
        //}
        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

