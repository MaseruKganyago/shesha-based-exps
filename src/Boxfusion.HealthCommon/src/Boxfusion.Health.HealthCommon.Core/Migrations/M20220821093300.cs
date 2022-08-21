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
    [Migration(20220821093300)]
    public class M20220821093300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_PatientContact")
                 .WithFullAuditColumns()
                 .WithIdAsGuid()
                 .WithColumn("FirstName").AsString().Nullable()
                 .WithColumn("LastName").AsString().Nullable()
                 .WithColumn("RelationshipTypeLkp").AsInt64().Nullable()
                 .WithColumn("MobileNumber").AsString().Nullable()
                 .WithColumn("AlternativeNumber").AsString().Nullable()
                 .WithForeignKeyColumn("AddressId", "Core_Addresses").Nullable();

            this.Shesha().ReferenceListCreate("Cdm", "RelationshipTypes");
            
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

