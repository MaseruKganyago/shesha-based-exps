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
    [Migration(20211010115500)]
    public class M20211010115500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete foreign keys from Fhir_DocumentReferences
            Delete.ForeignKey("FK_Frwk_StoredFiles_Fhir_EnconterId_Fhir_Encounters_Id").OnTable("Frwk_StoredFiles");
            Delete.ForeignKey("FK_Frwk_StoredFiles_Fhir_PractitionerId_Core_Persons_Id").OnTable("Frwk_StoredFiles");
            Delete.ForeignKey("FK_Frwk_StoredFiles_Fhir_SubjectId_Core_Persons_Id").OnTable("Frwk_StoredFiles");

            //Delete indexes from Fhir_DocumentReferences
            Delete.Index("IX_Frwk_StoredFiles_Fhir_EnconterId").OnTable("Frwk_StoredFiles");
            Delete.Index("IX_Frwk_StoredFiles_Fhir_PractitionerId").OnTable("Frwk_StoredFiles");
            Delete.Index("IX_Frwk_StoredFiles_Fhir_SubjectId").OnTable("Frwk_StoredFiles");

            //Delete columns from Fhir_DocumentReferences
            Delete.Column("Fhir_SubjectId").FromTable("Frwk_StoredFiles");
            Delete.Column("Fhir_PractitionerId").FromTable("Frwk_StoredFiles");
            Delete.Column("Fhir_EnconterId").FromTable("Frwk_StoredFiles");

            //Create a table called Fhir_Documents
            Create.Table("Fhir_Documents")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("SubjectId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithForeignKeyColumn("PractitionerId", "Core_Persons")
                .WithForeignKeyColumn("StoredFileId", "Frwk_StoredFiles")
                .WithColumn("TypeLkp").AsInt64().Nullable();
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

