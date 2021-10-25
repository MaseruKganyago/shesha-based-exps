﻿using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20210725092500)]
    public class M20210725092500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {


            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Medication
            Create.Table("Fhir_Medications")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("CodeLkp").AsInt64().Nullable()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("ManufactureId", "Core_Organisations")
                .WithColumn("FormLkp").AsInt64().Nullable()
                .WithColumn("AmmountNumerator").AsDecimal().Nullable()
                .WithColumn("AmountDenominator").AsDecimal().Nullable()
                .WithColumn("BatchLotNumber").AsDecimal().Nullable()
                .WithColumn("BatchExpirationDate").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Dosage
            Create.Table("Fhir_Dosages")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Sequence").AsInt32().Nullable()
                .WithColumn("Text").AsString().Nullable()
                .WithColumn("AdditionalInstructionLkp").AsInt64().Nullable()
                .WithColumn("ParentInstruction").AsString().Nullable()
                .WithColumn("TimingEventLkp").AsInt64().Nullable()
                .WithColumn("TimingRepeatBoundsDuration").AsTime().Nullable()
                .WithColumn("TimingRepeatBoundsRangeLow").AsDecimal().Nullable()
                .WithColumn("TimingRepeatBoundsRangeHigh").AsDecimal().Nullable()
                .WithColumn("TimingRepeatBoundsPeriodStart").AsDateTime().Nullable()
                .WithColumn("TimingRepeatBoundsPeriodEnd").AsDateTime().Nullable()
                .WithColumn("TimingRepeatCount").AsInt16().Nullable()
                .WithColumn("TimingRepeatCountMax").AsInt16().Nullable()
                .WithColumn("TimingRepeatDuration").AsDecimal().Nullable()
                .WithColumn("TimingRepeatDurationMax").AsDecimal().Nullable()
                .WithColumn("TimingRepeatDurationUnitLkp").AsInt64().Nullable()
                .WithColumn("TimingRepeatFrequency").AsInt16().Nullable()
                .WithColumn("TimingRepeatFrequencyMax").AsInt16().Nullable()
                .WithColumn("TimingRepeatPeriodUnitLkp").AsInt64().Nullable()
                .WithColumn("TimingRepeatDayOfWeekLkp").AsInt64().Nullable()
                .WithColumn("TimingRepeatTimeOfDayLkp").AsInt64().Nullable()
                .WithColumn("TimingRepeatWhenLkp").AsInt64().Nullable()
                .WithColumn("TimingRepeatOffSetLkp").AsInt64().Nullable()
                .WithColumn("TimingCodeLkp").AsInt64().Nullable()
                .WithColumn("AsNeeded").AsString().Nullable()
                .WithColumn("AsNeededBoolean").AsBoolean()
                .WithColumn("AsNeededCodeableConceptLkp").AsInt64().Nullable()
                .WithColumn("SiteLkp").AsInt64().Nullable()
                .WithColumn("RouteLkp").AsInt64().Nullable()
                .WithColumn("MethodLkp").AsInt64().Nullable()
                .WithColumn("DosageAndRateTypeLkp").AsInt64().Nullable()
                .WithColumn("DosageAndRateDoseRangeStart").AsDecimal().Nullable()
                .WithColumn("DosageAndRateDoseRangeEnd").AsDecimal().Nullable()
                .WithColumn("DosageAndRateDoseQuantity").AsDecimal().Nullable()
                .WithColumn("DosageAndRateRateRationNumerator").AsDecimal().Nullable()
                .WithColumn("DosageAndRateRateRatioDenominator").AsDecimal().Nullable()
                .WithColumn("DosageAndRateRangeStart").AsDecimal().Nullable()
                .WithColumn("DosageAndRateRangeEnd").AsDecimal().Nullable()
                .WithColumn("DosageAndRateRateQuantity").AsDecimal().Nullable()
                .WithColumn("MaxDosePerPeriodStart").AsDecimal().Nullable()
                .WithColumn("MaxDosePerPeriodEnd").AsDecimal().Nullable()
                .WithColumn("MaxDosePerAdministration").AsDecimal().Nullable()
                .WithColumn("MaxDosePerLifetime").AsDecimal().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.MedicationRequest
            Create.Table("Fhir_MedicationRequests")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("StatusReasonLkp").AsInt64().Nullable()
                .WithColumn("IntentLkp").AsInt64().Nullable()
                .WithColumn("CategoryLkpk").AsInt32().Nullable()
                .WithColumn("PriorityLkp").AsInt64().Nullable()
                .WithColumn("DoNotPerform").AsBoolean()
                .WithColumn("ReportedBoolean").AsBoolean()
                .WithColumn("ReportedReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReportedReferenceOwnerType").AsString().Nullable()
                .WithColumn("MedicationCodeableConceptLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("MedicationReferenceId", "Fhir_Medications")
                .WithForeignKeyColumn("SubjectId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("SupportingInformationOwnerId").AsString().Nullable()
                .WithColumn("SupportingInformationOwnerType").AsString().Nullable()
                .WithColumn("AuthoredOn").AsDateTime().Nullable()
                .WithColumn("RequestOwnerId").AsString().Nullable()
                .WithColumn("RequestOwnerType").AsString().Nullable()
                .WithColumn("PerformerOwnerId").AsString().Nullable()
                .WithColumn("PerformerOwnerType").AsString().Nullable()
                .WithColumn("PerformerTypeLkp").AsInt64().Nullable()
                .WithColumn("RecordedOwnerId").AsString().Nullable()
                .WithColumn("RecordedOwnerType").AsString().Nullable()
                .WithColumn("ReasonCodeLkp").AsInt64().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .WithColumn("BasedOnOwnerId").AsString().Nullable()
                .WithColumn("BasedOnOwnerType").AsString().Nullable()
                .WithColumn("GroupIdentifier").AsString().Nullable()
                .WithColumn("CourseOfTherapyTypeLkp").AsInt64().Nullable()
                .WithColumn("InsuranceOwnerId").AsString().Nullable()
                .WithColumn("InsuranceOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("DosageInstructionId", "Fhir_Dosages")
                .WithColumn("InitialFillQuantity").AsDateTime().Nullable()
                .WithColumn("InitialFillDuration").AsTime().Nullable()
                .WithColumn("DispenseInterval").AsTime().Nullable()
                .WithColumn("ValidityPeriodStart").AsDateTime().Nullable()
                .WithColumn("ValidityPeriodEnd").AsDateTime().Nullable()
                .WithColumn("NumberOfRepeatsAllowed").AsInt16().Nullable()
                .WithColumn("Quantity").AsDecimal().Nullable()
                .WithColumn("ExpectedSupplyDuration").AsTime().Nullable()
                .WithColumn("AllowBoolean").AsBoolean()
                .WithColumn("AllowCodeableConceptLkp").AsInt64().Nullable()
                .WithColumn("ReasonLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("PriorPrescriptionId", "Fhir_MedicationRequests")
                .WithForeignKeyColumn("EventHistoryId", "Fhir_Provenances");
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

