using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    
    [Migration(20221003102300)]
    public class M20221003102300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

			#region Delete AccountId ForeignKey column
			Delete.ForeignKey("FK_Fhir_ChargeItems_AccountId_entpr_FinancialTransactions_Id").OnTable("Fhir_ChargeItems");
			Delete.Index("IX_Fhir_ChargeItems_AccountId").OnTable("Fhir_ChargeItems");
			Delete.Column("AccountId").FromTable("Fhir_ChargeItems");
            #endregion

            Alter.Table("Fhir_ChargeItems").AddForeignKeyColumn("AccountId", "entpr_Accounts");
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
