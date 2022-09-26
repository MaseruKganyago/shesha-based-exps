using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220907152800)]
    public class M20220907152800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			#region Delete ProductionMedicationId ForeignKey
			Delete.ForeignKey("FK_Fhir_ChargeItems_ProductionMedicationId_entpr_Products_Id").OnTable("Fhir_ChargeItems");
			Delete.Index("IX_Fhir_ChargeItems_ProductionMedicationId").OnTable("Fhir_ChargeItems");
			Delete.Column("ProductionMedicationId").FromTable("Fhir_ChargeItems");
            #endregion

            Alter.Table("Fhir_ChargeItems")
                .AddForeignKeyColumn("ProductMedicationId", "entpr_Products").Nullable()
                .AddForeignKeyColumn("PartOfId", "Fhir_ChargeItems");
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

