using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211221155200)]
    public class M20211221155200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("His_HisAdmissionAuditTrails")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("InitiatorId", "Core_Persons")
                .WithForeignKeyColumn("AdmissionId", "Fhir_Encounters")
                .WithColumn("AuditTime").AsDateTime().Nullable()
                .WithColumn("AdmissionStatusLkp").AsInt64().Nullable()                
                ;            
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
