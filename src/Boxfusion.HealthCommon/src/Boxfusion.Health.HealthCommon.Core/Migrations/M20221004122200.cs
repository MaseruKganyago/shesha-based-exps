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
    
    [Migration(20221004122200)]
    public class M20221004122200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

			#region Delete AccountId ForeignKey column
			Delete.ForeignKey("FK_Fhir_ChargeItems_ProductMedicationId_entpr_Products_Id").OnTable("Fhir_ChargeItems");
			Delete.Index("IX_Fhir_ChargeItems_ProductMedicationId").OnTable("Fhir_ChargeItems");
			Delete.Column("ProductMedicationId").FromTable("Fhir_ChargeItems");
            #endregion

            Alter.Table("Fhir_ChargeItems").AddForeignKeyColumn("ChargeableProductId", "entpr_Products").Nullable();
            Alter.Column("QuantityValue").OnTable("Fhir_ChargeItems").AsDecimal().Nullable();
			Alter.Column("AccountId").OnTable("Fhir_ChargeItems").AsGuid().Nullable();
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
