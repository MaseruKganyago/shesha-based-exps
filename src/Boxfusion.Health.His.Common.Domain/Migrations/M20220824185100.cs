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
    [Migration(20220824185100)]
    public class M20220824185100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			Alter.Table("entpr_Accounts")
	            .AddColumn("Fhir_AccountStatusLkp").AsInt64().Nullable()
	            .AddColumn("Fhir_AccountTypeLkp").AsInt64().Nullable()
	            .AddColumn("Fhir_ServiceStartDate").AsDateTime().Nullable()
	            .AddColumn("Fhir_ServiceStartEnd").AsDateTime().Nullable()
	            .AddForeignKeyColumn("Fhir_CoverageId", "Fhir_Coverages").Nullable()
	            .AddForeignKeyColumn("Fhir_OwnerId", "Core_Organisations").Nullable()
	            .AddForeignKeyColumn("Fhir_PartOfId", "entpr_FinancialTransactions").Nullable();

            Delete.Column("Fhir_AccountStatusLkp").FromTable("entpr_FinancialTransactions");
            Delete.Column("Fhir_AccountTypeLkp").FromTable("entpr_FinancialTransactions");
            Delete.Column("Fhir_ServiceStartDate").FromTable("entpr_FinancialTransactions");
            Delete.Column("Fhir_ServiceStartEnd").FromTable("entpr_FinancialTransactions");

            Delete.ForeignKey("FK_entpr_FinancialTransactions_Fhir_CoverageId_Fhir_Coverages_Id").OnTable("entpr_FinancialTransactions");
            Delete.Index("IX_entpr_FinancialTransactions_Fhir_CoverageId").OnTable("entpr_FinancialTransactions");
            Delete.Column("Fhir_CoverageId").FromTable("entpr_FinancialTransactions");

			Delete.ForeignKey("FK_entpr_FinancialTransactions_Fhir_OwnerId_Core_Organisations_Id").OnTable("entpr_FinancialTransactions");
			Delete.Index("IX_entpr_FinancialTransactions_Fhir_OwnerId").OnTable("entpr_FinancialTransactions");
			Delete.Column("Fhir_OwnerId").FromTable("entpr_FinancialTransactions");

			Delete.ForeignKey("FK_entpr_FinancialTransactions_Fhir_PartOfId_entpr_FinancialTransactions_Id").OnTable("entpr_FinancialTransactions");
			Delete.Index("IX_entpr_FinancialTransactions_Fhir_PartOfId").OnTable("entpr_FinancialTransactions");
			Delete.Column("Fhir_PartOfId").FromTable("entpr_FinancialTransactions");
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
