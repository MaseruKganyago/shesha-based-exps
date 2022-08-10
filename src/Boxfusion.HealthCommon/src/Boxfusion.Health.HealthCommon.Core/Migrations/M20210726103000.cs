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
    [Migration(20210726103000)]
    public class M20210726103000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Condition
            Alter.Table("Fhir_Conditions")
                .AddColumn("ClinicalStatusLkp").AsInt64().Nullable()
                .AddColumn("VerificationStatusLkp").AsInt64().Nullable()
                .AddColumn("CategoryLkp").AsInt64().Nullable()
                .AddColumn("SeverityLkp").AsInt64().Nullable()
                .AddColumn("CodingSystemLkp").AsInt64().Nullable()
                .AddColumn("CodeValue").AsString().Nullable()
                .AddColumn("CodeText").AsString().Nullable()
                .AddColumn("BodySiteLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("SubjectId", "Core_Persons")
                .AddForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .AddColumn("OnsetDateTime").AsDateTime().Nullable()
                .AddColumn("OnsetAge").AsInt32().Nullable()
                .AddColumn("OnsetPeriodStart").AsDateTime().Nullable()
                .AddColumn("OnsetPeriodEnd").AsDateTime().Nullable()
                .AddColumn("OnsetRangeLow").AsDecimal().Nullable()
                .AddColumn("OnsetRangeHigh").AsDecimal().Nullable()
                .AddColumn("OnsetString").AsString().Nullable()
                .AddColumn("AbatementDateTime").AsDateTime().Nullable()
                .AddColumn("AbatementAge").AsInt32().Nullable()
                .AddColumn("AbatementPeriodStart").AsDateTime().Nullable()
                .AddColumn("AbatementPeriodEnd").AsDateTime().Nullable()
                .AddColumn("AbatementRangeLow").AsDecimal().Nullable()
                .AddColumn("AbatementRangeHigh").AsDecimal().Nullable()
                .AddColumn("AbatementString").AsString().Nullable()
                .AddColumn("RecordedDate").AsDateTime().Nullable()
                .AddForeignKeyColumn("RecorderId", "Core_Persons")
                .AddForeignKeyColumn("AsserterId", "Core_Persons");

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Stage
            Create.Table("Fhir_Stages")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("SummeryLkp").AsInt64().Nullable()
                .WithColumn("AssessmentOwnerId").AsString().Nullable()
                .WithColumn("AssessmentOwnerType").AsString().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("ConditionId", "Fhir_Conditions")
                ;

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Stage
            Create.Table("Fhir_Evidences")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("CodeLkp").AsInt64().Nullable()
                .WithColumn("DetailOwnerId").AsString().Nullable()
                .WithColumn("DetailOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("ConditionId", "Fhir_Conditions");
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

