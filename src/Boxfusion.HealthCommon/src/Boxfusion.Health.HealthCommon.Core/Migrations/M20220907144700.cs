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
    [Migration(20220907144700)]
    public class M20220907144700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			#region Delete MedicationReferenceId ForeignKey
			Delete.ForeignKey("FK_Fhir_Procedures_MedicationReferenceId_entpr_Products_Id").OnTable("Fhir_Procedures");
			Delete.Index("IX_Fhir_Procedures_MedicationReferenceId").OnTable("Fhir_Procedures");
			Delete.Column("MedicationReferenceId").FromTable("Fhir_Procedures");
            #endregion

            Alter.Table("Fhir_Procedures")
                .AddForeignKeyColumn("ProcedureMedicationId", "entpr_Products");
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

