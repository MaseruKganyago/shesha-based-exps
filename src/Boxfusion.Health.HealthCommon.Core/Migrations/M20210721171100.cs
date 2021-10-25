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
    [Migration(20210721171100)]
    public class M20210721171100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Encounter
            Create.Table("Fhir_Encounters")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Specimen
            Create.Table("Fhir_Specimens")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Provenance
            Create.Table("Fhir_Provenances")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ServiceRequest
            Create.Table("Fhir_ServiceRequests")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("BasedOnOwnerId").AsString().Nullable()
                .WithColumn("BasedOnOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("ReplacesId", "Fhir_ServiceRequests")
                .WithColumn("Requisition").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("IntentLkp").AsInt64().Nullable()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("Priority").AsInt64().Nullable()
                .WithColumn("DoNotPerform").AsBoolean().Nullable()
                .WithColumn("CodeLkp").AsInt64().Nullable()
                .WithColumn("OderDetailLkp").AsInt64().Nullable()
                .WithColumn("QuantityQuantity").AsDecimal().Nullable()
                .WithColumn("QuantityRatioNumerator").AsDecimal().Nullable()
                .WithColumn("QuantityRationDenominator").AsDecimal().Nullable()
                .WithColumn("QuantityRangeLow").AsDecimal().Nullable()
                .WithColumn("QuantityRangeHigh").AsDecimal().Nullable()
                .WithForeignKeyColumn("PatientId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("OccurenceDateTime").AsDateTime().Nullable()
                .WithColumn("OccurencePeriodStart").AsDateTime().Nullable()
                .WithColumn("OccurencePeriodEnd").AsDateTime().Nullable()
                .WithColumn("AsNeededBoolean").AsBoolean().Nullable()
                .WithColumn("AsNeededCodeableConceptLkp").AsInt64().Nullable()
                .WithColumn("AutheredOn").AsDateTime().Nullable()
                .WithColumn("RequestedOwnerId").AsString().Nullable()
                .WithColumn("RequestedOwnerType").AsString().Nullable()
                .WithColumn("PerformerTypeLkp").AsInt64().Nullable()
                .WithColumn("PerformerOwnderId").AsString().Nullable()
                .WithColumn("PerformerOwnerType").AsString().Nullable()
                .WithColumn("LocationCodeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithColumn("ReasonCodeLkp").AsInt64().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .WithColumn("InsuranceOwnerId").AsString().Nullable()
                .WithColumn("InsuranceOwnerType").AsString().Nullable()
                .WithColumn("SupportingInfoOwnerId").AsString().Nullable()
                .WithColumn("SupportingInfoOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("SpecimenId", "Fhir_Specimens")
                .WithColumn("BodySiteLkp").AsInt64().Nullable()
                .WithColumn("PatientInstruction").AsString().Nullable()
                .WithForeignKeyColumn("RelevantHistoryId", "Fhir_Provenances");

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

