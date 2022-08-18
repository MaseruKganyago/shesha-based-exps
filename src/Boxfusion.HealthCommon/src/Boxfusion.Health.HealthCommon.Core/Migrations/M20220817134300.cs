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
    [Migration(20220817134300)]
    public class M20220817134300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Medication
            Alter.Table("entpr_Products")
                .AddColumn("Fhir_Code").AsInt64().Nullable()
                .AddColumn("Fhir_StatusLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("Fhir_ManufactureId", "Core_Organisations")
                .AddColumn("FormLkp").AsInt64().Nullable()
                .AddColumn("AmmountNumerator").AsDecimal().Nullable()
                .AddColumn("AmountDenominator").AsDecimal().Nullable()
                .AddColumn("BatchLotNumber").AsString().Nullable()
                .AddColumn("BatchExpirationDate").AsDateTime().Nullable();

			//Boxfusion.Health.Cdm.Domain.Domain.Fhir.ChargeItem
			Create.Table("Fhir_ChargeItems")
				.WithFullAuditColumns()
				.WithIdAsGuid()
				.WithColumn("Code").AsString().Nullable()
				.WithForeignKeyColumn("SubjectId", "Core_Persons").Nullable()
				.WithForeignKeyColumn("ContextEncounterId", "Fhir_Encounters").Nullable()
				.WithColumn("OccurenceStart").AsDateTime().Nullable()
				.WithColumn("OccurenceEnd").AsDateTime().Nullable()
				.WithForeignKeyColumn("PerformingOrganizationId", "Core_Organisations").Nullable()
				.WithForeignKeyColumn("RequestingOrganizationId", "Core_Organisations").Nullable()
				.WithForeignKeyColumn("CostCenterId", "Core_Organisations").Nullable()
				.WithColumn("QuantityValue").AsInt64().Nullable()
				.WithColumn("QuantityUoM").AsString().Nullable()
				.WithColumn("FactorOverride").AsDecimal().Nullable()
				.WithColumn("PriceOverride").AsDecimal().Nullable()
				.WithColumn("OverrideReason").AsString().Nullable()
				.WithForeignKeyColumn("EntererId", "Core_Persons").Nullable()
				.WithColumn("EnteredDate").AsDateTime().Nullable()
				.WithColumn("ServiceId").AsGuid().Nullable()
				.WithColumn("ServiceType").AsString().Nullable()
				.WithForeignKeyColumn("ProductionMedicationId", "entpr_Products").Nullable()
				.WithForeignKeyColumn("AccountId", "entpr_FinancialTransactions").Nullable();

			#region Change Medication ForeignKey in MedicationRequest
			Delete.ForeignKey("FK_Fhir_MedicationRequests_MedicationReferenceId_Fhir_Medications_Id").OnTable("Fhir_MedicationRequests");
			Delete.Index("IX_Fhir_MedicationRequests_MedicationReferenceId").OnTable("Fhir_MedicationRequests");
			Delete.Column("MedicationReferenceId").FromTable("Fhir_MedicationRequests");

            Alter.Table("Fhir_MedicationRequests")
                .AddForeignKeyColumn("MedicationReferenceId", "entpr_Products");
			#endregion

            this.Shesha().ReferenceListCreate("Fhir", "MedicationAdministrationCategories")
                .SetDescription("Type of medication usage. MedicationAdministration Category Codes");

            this.Shesha().ReferenceListCreate("Fhir", "MedicationAdministrationReasonCode")
                .SetDescription("Reason administration performed. Reason Medication Given Codes");

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.MedicationAdministration
            Create.Table("Fhir_MedicationAdministrations")
                .WithFullAuditColumns()
                .WithIdAsGuid()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("MedicationId", "entpr_Products").Nullable()
                .WithForeignKeyColumn("SubjectId", "Core_Persons").Nullable()
                .WithForeignKeyColumn("ContextEncounterId", "Fhir_Encounters").Nullable()
                .WithColumn("EffectiveStart").AsDateTime().Nullable()
                .WithColumn("EffectiveEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("PerformerId", "Core_Persons").Nullable()
                .WithColumn("ReasonCodeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("ReasonConditionId", "Fhir_Conditions").Nullable()
                .WithForeignKeyColumn("ReasonObservationId", "Fhir_Observations").Nullable()
                .WithForeignKeyColumn("RequestId", "Fhir_MedicationRequests").Nullable();

            Create.Table("Fhir_ProcedureMedications")
                .WithFullAuditColumns()
                .WithIdAsGuid()
                .WithForeignKeyColumn("ProcedureId", "Fhir_Procedures").Nullable()
                .WithForeignKeyColumn("MedicationId", "entpr_Products").Nullable();
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
