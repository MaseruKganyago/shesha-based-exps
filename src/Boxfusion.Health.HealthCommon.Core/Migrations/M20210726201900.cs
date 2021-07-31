using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210726201900)]
    public class M20210726201900 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.CoditionIcdTenCode
            Create.Table("Fhir_ConditionIcdTenCodes")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("ConditionId", "Fhir_Conditions")
                .WithForeignKeyColumn("IcdTenCodeId", "Fhir_IcdTenCodes");

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Procedure
            Create.Table("Fhir_Procedures")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("BasedOnOwnerId").AsString().Nullable()
                .WithColumn("BasedOnOwnerType").AsString().Nullable()
                .WithColumn("PartOfOwnerId").AsString().Nullable()
                .WithColumn("PartOfOwnerType").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt32().Nullable()
                .WithColumn("StatusReasonLkp").AsInt32().Nullable()
                .WithColumn("CategoryLkp").AsInt32().Nullable()
                .WithColumn("CodingSystemLkp").AsInt32().Nullable()
                .WithColumn("CodeValueLkp").AsInt32().Nullable()
                .WithColumn("CodeText").AsString().Nullable()
                .WithForeignKeyColumn("SubjectId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("PerformedDateTime").AsDateTime().Nullable()
                .WithColumn("PerformedPeriodStart").AsDateTime().Nullable()
                .WithColumn("PerformedString").AsString().Nullable()
                .WithColumn("PerformedAge").AsInt32().Nullable()
                .WithColumn("PerformedRangeLow").AsDecimal().Nullable()
                .WithColumn("PerformedRangeHigh").AsDecimal().Nullable()
                .WithForeignKeyColumn("RecorderId", "Core_Persons")
                .WithForeignKeyColumn("AsserterId", "Core_Persons")
                .WithColumn("PerformerFunctionLkp").AsInt32().Nullable()
                .WithColumn("PerformerActorOwnerId").AsString().Nullable()
                .WithColumn("PerformerActorOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("PerformerOnBehalfOfId", "Core_Organisations")
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithColumn("ReasonCodeLkp").AsInt32().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .WithColumn("BodySiteLkp").AsInt32().Nullable()
                .WithColumn("OutcomeLkp").AsInt32().Nullable()
                .WithColumn("ReportOwnerId").AsString().Nullable()
                .WithColumn("ReportOwnerType").AsString().Nullable()
                .WithColumn("ComplicationLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("ComplicationDetailId", "Fhir_Conditions")
                .WithColumn("FollowUpLkp").AsInt32().Nullable();
                
                
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

