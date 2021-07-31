using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210725115600)]
    public class M20210725115600 : Migration
    {
        public override void Up()
        {


            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Ingredient
            Create.Table("Fhir_Ingredients")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("ItemCodeableConceptLkp").AsInt32().Nullable()
                .WithColumn("ItemReferenceOwnerId").AsString().Nullable()
                .WithColumn("ItemReferenceOwnerType").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean()
                .WithColumn("StrengthNumerator").AsDecimal().Nullable()
                .WithColumn("StrengthDenominator").AsDecimal().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Payload
            Create.Table("Fhir_Payload")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("ContentString").AsString().Nullable()
                .WithColumn("ContentReferenceOwnerId").AsString().Nullable()
                .WithColumn("ContentReferenceOwnerType").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Communication
            Create.Table("Fhir_Communications")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("BasedOnOwnerId").AsString().Nullable()
                .WithColumn("BasedOnOwnerType").AsString().Nullable()
                .WithColumn("PartOfOwnerId").AsString().Nullable()
                .WithColumn("PartOfOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("InResponseToId", "Fhir_Communications")
                .WithColumn("StatusLkp").AsInt32().Nullable()
                .WithColumn("StatusReasonLkp").AsInt32().Nullable()
                .WithColumn("CategoryLkp").AsInt32().Nullable()
                .WithColumn("PriorityLkp").AsInt32().Nullable()
                .WithColumn("MediumLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("SubjectId", "Core_Persons")
                .WithColumn("TopicLkp").AsInt32().Nullable()
                .WithColumn("AboutOwnerId").AsString().Nullable()
                .WithColumn("AboutOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("Sent").AsDateTime().Nullable()
                .WithColumn("Recieved").AsDateTime().Nullable()
                .WithColumn("RecipientOwnerId").AsString().Nullable()
                .WithColumn("RecipientOwnerType").AsString().Nullable()
                .WithColumn("SenderOwnerId").AsString().Nullable()
                .WithColumn("SenderOwnerType").AsString().Nullable()
                .WithColumn("ReasonCodeLkp").AsInt32().Nullable()
                .WithColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .WithColumn("ReasonReferenceOwnerType").AsString().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

