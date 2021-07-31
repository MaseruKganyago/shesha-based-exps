using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722215800)]
    public class M20210722215800 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Observation
            Create.Table("Fhir_Observations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("BasedOnOwnerId").AsString().Nullable()
                .WithColumn("BasedOnOwnerType").AsString().Nullable()
                .WithColumn("PartOfOwnerId").AsString().Nullable()
                .WithColumn("PartOfOwnerType").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt32().Nullable()
                .WithColumn("CategoryLkp").AsInt32().Nullable()
                .WithColumn("CodeLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("SubjectId", "Core_Persons")
                .WithForeignKeyColumn("EncounterId", "Fhir_Encounters")
                .WithColumn("FocusOwnerId").AsString().Nullable()
                .WithColumn("FocusOwnerType").AsString().Nullable()
                .WithColumn("EffectiveDateTime").AsDateTime().Nullable()
                .WithColumn("EffectivePeriodStart").AsDateTime().Nullable()
                .WithColumn("EffectivePeriodEnd").AsDateTime().Nullable()
                .WithColumn("Issued").AsDateTime().Nullable()
                .WithColumn("PerformerOwnerId").AsString().Nullable()
                .WithColumn("PerformerOwnerType").AsString().Nullable()
                .WithColumn("DataAbsentReasonLkp").AsInt32().Nullable()
                .WithColumn("InterpretationLkp").AsInt32().Nullable()
                .WithColumn("BodySiteLkp").AsInt32().Nullable()
                .WithColumn("MethodLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("SpecimenId", "Fhir_Specimens")
                .WithColumn("DeviceOwnerId").AsString().Nullable()
                .WithColumn("DeviceOwnerType").AsString().Nullable()
                .WithColumn("HasMemberOwnerId").AsString().Nullable()
                .WithColumn("HasMemberOwnerType").AsString().Nullable()
                .WithColumn("DerivedFromOwnerId").AsString().Nullable()
                .WithColumn("DerivedFromOwnerType").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cmd.Component
            Create.Table("Fhir_Components")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("ValueQuantity").AsDecimal().Nullable()
                .WithColumn("ValueCodeableConceptLkp").AsInt32().Nullable()
                .WithColumn("ValueString").AsString().Nullable()
                .WithColumn("ValueBoolean").AsBoolean()
                .WithColumn("ValueInteger").AsInt32().Nullable()
                .WithColumn("ValueRangeLow").AsDecimal().Nullable()
                .WithColumn("ValueRangeHigh").AsDecimal().Nullable()
                .WithColumn("ValueRatioNumerator").AsDecimal().Nullable()
                .WithColumn("ValueRatioDenominator").AsDecimal().Nullable()
                .WithColumn("ValueDateTime").AsDateTime().Nullable()
                .WithColumn("ValueStartDateTime").AsDateTime().Nullable()
                .WithColumn("ValueEndDateTime").AsDateTime().Nullable()
                .WithColumn("UnitOfMeasure").AsString().Nullable()
                .WithForeignKeyColumn("ObservationId", "Fhir_Observations");

        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

