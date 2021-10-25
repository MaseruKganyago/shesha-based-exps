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
    [Migration(20211013110700)]
    public class M20211013110700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Specimens")
                .AddColumn("Identifier").AsString(30).Nullable()
                .AddColumn("AccessionIdentifier").AsString(30).Nullable()
                .AddColumn("StatusLkp").AsInt64().Nullable()
                .AddColumn("TypeLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("SubjectId", "Core_Persons")
                .AddColumn("ReceivedTime").AsDateTime().Nullable()
                .AddForeignKeyColumn("ParentId", "Fhir_Specimens")
                .AddForeignKeyColumn("RequestId", "Fhir_ServiceRequests")
                .AddColumn("ConditionLkp").AsInt64().Nullable();

            Create.Table("Fhir_Substances")
             .WithIdAsGuid()
             .WithFullAuditColumns()
             .WithColumn("Identifier").AsString(30).Nullable()
             .WithColumn("StatusLkp").AsInt64().Nullable()
             .WithColumn("CategoryLkp").AsInt64().Nullable()
             .WithColumn("CodeLkp").AsInt64().Nullable()
             .WithColumn("Description").AsString(250).Nullable();

            Create.Table("Fhir_Processings")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithColumn("Description").AsString(250).Nullable()
               .WithColumn("ProcedureLkp").AsInt64().Nullable()
               .WithForeignKeyColumn("AdditiveId", "Fhir_Substances")
               .WithColumn("TimeDateTime").AsDateTime().Nullable()
               .WithColumn("TimePeriodStart").AsDateTime().Nullable()
               .WithColumn("TimePeriodEnd").AsDateTime().Nullable()
               .WithForeignKeyColumn("SpecimenId", "Fhir_Specimens");


            Create.Table("Fhir_SubstanceIngredients")
             .WithIdAsGuid()
             .WithFullAuditColumns()
             .WithColumn("QuantityRatioNumerator").AsDecimal().Nullable()
             .WithColumn("QuantityRatioDenominator").AsDecimal().Nullable()
             .WithColumn("SubstanceCodeableConceptLkp").AsInt64().Nullable()
             .WithForeignKeyColumn("SubstanceReferenceId", "Fhir_Substances");

            Create.Table("Fhir_Instances")
             .WithIdAsGuid()
             .WithFullAuditColumns()
             .WithColumn("Identifier").AsString(30).Nullable()
             .WithColumn("Expiry").AsDateTime().Nullable()
             .WithColumn("Quantity").AsDecimal().Nullable()
             .WithForeignKeyColumn("SubstanceId", "Fhir_Substances");


            Create.Table("Fhir_Containers")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString(30).Nullable()
                .WithColumn("Description").AsString(250).Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("Capacity").AsDecimal().Nullable()
                .WithColumn("SpecimenQuantity").AsDecimal().Nullable()
                .WithColumn("AdditiveCodeableConceptLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("AdditiveReferenceId", "Fhir_Substances")
                .WithForeignKeyColumn("SpecimenId", "Fhir_Specimens");


            Create.Table("Fhir_Collections")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("CollectorOwnerId").AsString(30).Nullable()
                .WithColumn("CollerctorOwnerType").AsString(100).Nullable()
                .WithColumn("CollectedDateTime").AsDateTime().Nullable()
                .WithColumn("CollectedStartDateTime").AsDateTime().Nullable()
                .WithColumn("CollectedEndDateTime").AsDateTime().Nullable()
                .WithColumn("DurationStart").AsDateTime().Nullable()
                .WithColumn("DurationEnd").AsDateTime().Nullable()
                .WithColumn("Quantity").AsDecimal().Nullable()
                .WithColumn("MethodLkp").AsInt64().Nullable()
                .WithColumn("BodySiteLkp").AsInt64().Nullable()
                .WithColumn("FastingStatusCodeableConceptLkp").AsInt64().Nullable()
                .WithColumn("FastingStatusStartDateTime").AsDateTime().Nullable()
                .WithColumn("FastingStatusEndDateTime").AsDateTime().Nullable()
                .WithForeignKeyColumn("SpecimenId", "Fhir_Specimens");
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
