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
    [Migration(20211007222000)]
    public class M20211007222000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete foreign keys from Fhir_DocumentReferences
            Delete.ForeignKey("FK_Fhir_DocumentReferences_SubjectId_Core_Persons_Id").OnTable("Fhir_DocumentReferences");
            Delete.ForeignKey("FK_Fhir_DocumentReferences_PractitionerId_Core_Persons_Id").OnTable("Fhir_DocumentReferences");

            //Delete indexes from Fhir_DocumentReferences
            Delete.Index("IX_Fhir_DocumentReferences_SubjectId").OnTable("Fhir_DocumentReferences");
            Delete.Index("IX_Fhir_DocumentReferences_PractitionerId").OnTable("Fhir_DocumentReferences");

            //Delete columns from Fhir_DocumentReferences
            Delete.Column("SubjectId").FromTable("Fhir_DocumentReferences");
            Delete.Column("PractitionerId").FromTable("Fhir_DocumentReferences");

            //Add sub class columns to Fhir_DocumentReferences
            Alter.Table("Frwk_StoredFiles")
                .AddForeignKeyColumn("Fhir_SubjectId", "Core_Persons")
                .AddForeignKeyColumn("Fhir_PractitionerId", "Core_Persons")
                .AddForeignKeyColumn("Fhir_EnconterId", "Fhir_Encounters")
                .AddColumn("Fhir_TypeLkp").AsInt64().Nullable();
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

