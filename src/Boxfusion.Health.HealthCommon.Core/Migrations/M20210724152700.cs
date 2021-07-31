using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210724152700)]
    public class M20210724152700 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Immunisation
            Create.Table("Fhir_Immunisations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt32().Nullable()
                .WithColumn("StatusReasonLkp").AsInt32().Nullable()
                .WithColumn("VaccineCodeLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("PatientId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("OccurenceDateTime").AsDateTime().Nullable()
                .WithColumn("OccurenceString").AsString().Nullable()
                .WithColumn("Recorded").AsDateTime().Nullable()
                .WithColumn("PrimarySource").AsBoolean()
                .WithColumn("ReportOriginLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithForeignKeyColumn("ManufactureId", "Core_Organisations")
                .WithColumn("LotNumber").AsString().Nullable()
                .WithColumn("ExpirationDate").AsDateTime().Nullable()
                .WithColumn("SiteLkp").AsInt32().Nullable()
                .WithColumn("RouteLkp").AsInt32().Nullable()
                .WithColumn("DoseQuantity").AsDecimal().Nullable()
                .WithColumn("PerformerFunctionLkp").AsInt32().Nullable()
                .WithColumn("PerformerActorOwnerId").AsString().Nullable()
                .WithColumn("PerformerActorOwnerType").AsString().Nullable()
                .WithColumn("ReasonCodeLkp").AsInt32().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .WithColumn("IsSubpotent").AsBoolean()
                .WithColumn("SubpotentReasonLkp").AsInt32().Nullable()
                .WithColumn("ProgramEligibilityLkp").AsInt32().Nullable()
                .WithColumn("FundingSourceLkp").AsInt32().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Education
            Create.Table("Fhir_Educations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("DocumentType").AsString().Nullable()
                .WithColumn("Reference").AsString()
                .WithColumn("PublicationDate").AsDateTime().Nullable()
                .WithColumn("PresentationDate").AsDateTime().Nullable()
                .WithForeignKeyColumn("ImmunisationId", "Fhir_Immunisations");

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Immnunisation
            Create.Table("Fhir_ImmunizationReaction")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Date").AsDateTime().Nullable()
                .WithForeignKeyColumn("DetailId", "Fhir_Observations")
                .WithColumn("Reported").AsBoolean()
                .WithForeignKeyColumn("ImmunisationId", "Fhir_Immunisations");

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.ProtocolApplied
            Create.Table("Fhir_ProtocolApplications")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Series").AsString().Nullable()
                .WithForeignKeyColumn("AuthorityId", "Core_Organisations")
                .WithColumn("TargetDiseaseLkp").AsInt32().Nullable()
                .WithColumn("DoseNumberPositiveInt").AsInt16().Nullable()
                .WithColumn("DoseNumberString").AsString().Nullable()
                .WithColumn("SeriesDosesPositiveInt").AsInt16().Nullable()
                .WithColumn("SeriesDosesString").AsString().Nullable()
                .WithForeignKeyColumn("ImmunisationId", "Fhir_Immunisations");
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

