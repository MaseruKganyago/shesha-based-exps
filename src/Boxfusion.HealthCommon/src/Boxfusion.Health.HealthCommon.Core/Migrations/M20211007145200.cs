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
    [Migration(20211007145200)]
    public class M20211007145200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("SubjectOwnerId").FromTable("Fhir_DocumentReferences");
            Delete.Column("SubjectOwnerType").FromTable("Fhir_DocumentReferences");

            Alter.Table("Fhir_DocumentReferences")
                .AddForeignKeyColumn("SubjectId", "Core_Persons")
                .AddForeignKeyColumn("PractitionerId", "Core_Persons");
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

