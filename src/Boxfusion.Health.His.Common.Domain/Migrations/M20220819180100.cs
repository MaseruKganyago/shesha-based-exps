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
    [Migration(20220819180100)]
    public class M20220819180100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Persons")
                .AddForeignKeyColumn("ProofOfResidentsId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("PaySlipId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("MedicalAidDocumentId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("RefferalNoteId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("MotivationLetterId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("AffidavitUnemployedId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("AffidavitLostDocumentsId", "Frwk_StoredFiles")
                .AddForeignKeyColumn("OtherDocumentsId", "Frwk_StoredFiles");
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
