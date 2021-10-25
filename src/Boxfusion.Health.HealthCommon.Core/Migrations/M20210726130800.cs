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
    [Migration(20210726130800)]
    public class M20210726130800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.AllergyIntolerance
            Create.Table("Fhir_Reactions")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("SubstanceLkp").AsInt64().Nullable()
                .WithColumn("ManifestationLkp").AsInt64().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("OnSet").AsDateTime().Nullable()
                .WithColumn("Severity").AsInt64().Nullable()
                .WithColumn("ExposureRoute").AsInt64().Nullable()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable();


            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.AllergyIntolerance
            Create.Table("Fhir_AllergyIntolerances")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("ClinicalStatusLkp").AsInt64().Nullable()
                .WithColumn("VerificationStatusLkp").AsInt64().Nullable()
                .WithColumn("AllergyTypeLkp").AsInt64().Nullable()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("CriticalityLkp").AsInt64().Nullable()
                .WithColumn("CodeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("PatientId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("OnsetDateTime").AsDateTime().Nullable()
                .WithColumn("OnsetAge").AsInt32().Nullable()
                .WithColumn("OnsetPeriodStart").AsDateTime().Nullable()
                .WithColumn("OnsetPeriodEnd").AsDateTime().Nullable()
                .WithColumn("OnsetRangeLow").AsDecimal().Nullable()
                .WithColumn("OnsetRangeHigh").AsDecimal().Nullable()
                .WithColumn("OnsetString").AsString().Nullable()
                .WithColumn("RecordedDate").AsDateTime().Nullable()
                .WithForeignKeyColumn("RecorderId", "Core_Persons")
                .WithForeignKeyColumn("AsserterId", "Core_Persons")
                .WithColumn("LastOccurence").AsDateTime().Nullable()
                .WithForeignKeyColumn("ReactionId", "Fhir_Reactions")
                ;

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.MedicationStatement
            Create.Table("Fhir_MedicationStatements")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("BasedOnOwnerId").AsString().Nullable()
                .WithColumn("BasedOnOwnerType").AsString().Nullable()
                .WithColumn("PartOfOwnerId").AsString().Nullable()
                .WithColumn("PartOfOwnerType").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("StatusReasonLkp").AsInt64().Nullable()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("MedicationCodeableConceptLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("MedicationReferenceId", "Fhir_Medications")
                .WithColumn("MedicationText").AsString().Nullable()
                .WithForeignKeyColumn("SubjectId", "Core_Persons")
                .WithColumn("ContextOwnerId").AsString().Nullable()
                .WithColumn("ContextOwnerType").AsString().Nullable()
                .WithColumn("EffectiveDateTime").AsDateTime().Nullable()
                .WithColumn("EffectivePeriodStart").AsDateTime().Nullable()
                .WithColumn("EffectivePeriodEnd").AsDateTime().Nullable()
                .WithColumn("DateAsserted").AsDateTime().Nullable()
                .WithForeignKeyColumn("InformationSourceId", "Core_Persons")
                .WithColumn("DerivedFromOwnerId").AsString().Nullable()
                .WithColumn("DerivedFromOwnerType").AsString().Nullable()
                .WithColumn("ReasonCode").AsInt64().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("DosageId", "Fhir_Dosages");
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

