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
    [Migration(20220821094100)]
    public class M20220821094100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			Delete.ForeignKey("FK_Core_Persons_ProofOfResidentsId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_ProofOfResidentsId").OnTable("Core_Persons");
			Delete.Column("ProofOfResidentsId").FromTable("Core_Persons");

            Delete.ForeignKey("FK_Core_Persons_PaySlipId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_PaySlipId").OnTable("Core_Persons");
			Delete.Column("PaySlipId").FromTable("Core_Persons");

            Delete.ForeignKey("FK_Core_Persons_MedicalAidDocumentId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_MedicalAidDocumentId").OnTable("Core_Persons");
			Delete.Column("MedicalAidDocumentId").FromTable("Core_Persons");

            Delete.ForeignKey("FK_Core_Persons_RefferalNoteId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_RefferalNoteId").OnTable("Core_Persons");
			Delete.Column("RefferalNoteId").FromTable("Core_Persons");

            Delete.ForeignKey("FK_Core_Persons_MotivationLetterId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_MotivationLetterId").OnTable("Core_Persons");
			Delete.Column("MotivationLetterId").FromTable("Core_Persons");

            Delete.ForeignKey("FK_Core_Persons_AffidavitLostDocumentsId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_AffidavitLostDocumentsId").OnTable("Core_Persons");
			Delete.Column("AffidavitLostDocumentsId").FromTable("Core_Persons");

            Delete.ForeignKey("FK_Core_Persons_OtherDocumentsId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_OtherDocumentsId").OnTable("Core_Persons");
			Delete.Column("OtherDocumentsId").FromTable("Core_Persons");

			Delete.ForeignKey("FK_Core_Persons_AffidavitUnemployedId_Frwk_StoredFiles_Id").OnTable("Core_Persons");
			Delete.Index("IX_Core_Persons_AffidavitUnemployedId").OnTable("Core_Persons");
			Delete.Column("AffidavitUnemployedId").FromTable("Core_Persons");

            Alter.Column("His_AffidavitUnemployedId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_OtherDocumentsId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_AffidavitLostDocumentsId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_MotivationLetterId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_RefferalNoteId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_MedicalAidDocumentId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_PaySlipId").OnTable("Core_Persons").AsGuid().Nullable();
			Alter.Column("His_ProofOfResidentsId").OnTable("Core_Persons").AsGuid().Nullable();
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
