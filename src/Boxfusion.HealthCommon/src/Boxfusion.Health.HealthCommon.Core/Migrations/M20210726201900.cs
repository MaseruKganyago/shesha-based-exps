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
    [Migration(20210726201900)]
    public class M20210726201900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
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
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("StatusReasonLkp").AsInt64().Nullable()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("CodingSystemLkp").AsInt64().Nullable()
                .WithColumn("CodeValueLkp").AsInt64().Nullable()
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
                .WithColumn("PerformerFunctionLkp").AsInt64().Nullable()
                .WithColumn("PerformerActorOwnerId").AsString().Nullable()
                .WithColumn("PerformerActorOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("PerformerOnBehalfOfId", "Core_Organisations")
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithColumn("ReasonCodeLkp").AsInt64().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .WithColumn("BodySiteLkp").AsInt64().Nullable()
                .WithColumn("OutcomeLkp").AsInt64().Nullable()
                .WithColumn("ReportOwnerId").AsString().Nullable()
                .WithColumn("ReportOwnerType").AsString().Nullable()
                .WithColumn("ComplicationLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("ComplicationDetailId", "Fhir_Conditions")
                .WithColumn("FollowUpLkp").AsInt64().Nullable();           
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

