using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220818074800)]
    public class M20220818074800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            #region Change Medication ForeignKey in MedicationStatements
            Delete.ForeignKey("FK_Fhir_MedicationStatements_MedicationReferenceId_Fhir_Medications_Id").OnTable("Fhir_MedicationStatements");
            Delete.Index("IX_Fhir_MedicationStatements_MedicationReferenceId").OnTable("Fhir_MedicationStatements");
            Delete.Column("MedicationReferenceId").FromTable("Fhir_MedicationStatements");

            Alter.Table("Fhir_MedicationStatements")
                .AddForeignKeyColumn("MedicationReferenceId", "entpr_Products");
			#endregion

			Delete.Table("Fhir_Medications");

			Alter.Table("Fhir_Procedures")
				.AddForeignKeyColumn("MedicationReferenceId", "entpr_Products")
				.AddForeignKeyColumn("PerformerId", "Core_Persons");
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
