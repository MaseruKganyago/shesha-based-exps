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
    [Migration(20220820160500)]
    public class M20220820160500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			Alter.Table("Core_Persons")
				.AddForeignKeyColumn("His_ProofOfResidentsId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_PaySlipId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_MedicalAidDocumentId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_RefferalNoteId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_MotivationLetterId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_AffidavitUnemployedId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_AffidavitLostDocumentsId", "Frwk_StoredFiles")
				.AddForeignKeyColumn("His_OtherDocumentsId", "Frwk_StoredFiles");
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
