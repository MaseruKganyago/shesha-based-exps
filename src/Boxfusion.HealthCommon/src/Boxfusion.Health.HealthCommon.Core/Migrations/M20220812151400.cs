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
    [Migration(20220812151400)]
    public class M20220812151400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("AccountStatusLkp").FromTable("entpr_FinancialTransactions");
            Delete.Column("AccountTypeLkp").FromTable("entpr_FinancialTransactions");
            Delete.Column("ServiceStartDate").FromTable("entpr_FinancialTransactions");
            Delete.Column("ServiceStartEnd").FromTable("entpr_FinancialTransactions");

            Delete.ForeignKey("FK_entpr_FinancialTransactions_CoverageId_Fhir_Coverages_Id").OnTable("entpr_FinancialTransactions");
            Delete.Index("IX_entpr_FinancialTransactions_CoverageId").OnTable("entpr_FinancialTransactions");
            Delete.Column("CoverageId").FromTable("entpr_FinancialTransactions");

            Delete.ForeignKey("FK_entpr_FinancialTransactions_OwnerId_Core_Organisations_Id").OnTable("entpr_FinancialTransactions");
            Delete.Index("IX_entpr_FinancialTransactions_OwnerId").OnTable("entpr_FinancialTransactions");
            Delete.Column("OwnerId").FromTable("entpr_FinancialTransactions");

            Delete.ForeignKey("FK_entpr_FinancialTransactions_PartOfId_entpr_FinancialTransactions_Id").OnTable("entpr_FinancialTransactions");
            Delete.Index("IX_entpr_FinancialTransactions_PartOfId").OnTable("entpr_FinancialTransactions");
            Delete.Column("PartOfId").FromTable("entpr_FinancialTransactions");

            Alter.Table("entpr_FinancialTransactions")
                .AddColumn("Fhir_AccountStatusLkp").AsInt64().Nullable()
                .AddColumn("Fhir_AccountTypeLkp").AsInt64().Nullable()
                .AddColumn("Fhir_ServiceStartDate").AsDateTime().Nullable()
                .AddColumn("Fhir_ServiceStartEnd").AsDateTime().Nullable()
                .AddForeignKeyColumn("Fhir_CoverageId", "Fhir_Coverages").Nullable()
                .AddForeignKeyColumn("Fhir_OwnerId", "Core_Organisations").Nullable()
                .AddForeignKeyColumn("Fhir_PartOfId", "entpr_FinancialTransactions").Nullable();

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

