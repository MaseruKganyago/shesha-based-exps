using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210725211400)]
    public class M20210725211400 : Migration
    {
        public override void Up()
        {

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.DocumentReference
            Create.Table("Fhir_DocumentReferences")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("MasterIdentifier").AsString().Nullable()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("StatusLkp").AsInt32().Nullable()
                .WithColumn("DocStatusLkp").AsInt32().Nullable()
                .WithColumn("TypeLkp").AsInt32().Nullable()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("SubjectOwnerId").AsString().Nullable()
                .WithColumn("SubjectOwnerType").AsString().Nullable()
                .WithColumn("Date").AsDateTime().Nullable()
                .WithColumn("AuthorOwnerId").AsString().Nullable()
                .WithColumn("AuthorOwnerType").AsString().Nullable()
                .WithForeignKeyColumn("CustodianId", "Core_Organisations")
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("SecurityLabelLkp").AsInt32().Nullable()
                .WithColumn("ContextEncouterOwnerId").AsString().Nullable()
                .WithColumn("ContextEncounterOwnerType").AsString().Nullable()
                .WithColumn("ContextEventLkp").AsInt32().Nullable()
                .WithColumn("ContextPeriodStart").AsDateTime().Nullable()
                .WithColumn("ContextPeriodEnd").AsDateTime().Nullable()
                .WithColumn("ContextFacilityTypeLkp").AsInt32().Nullable()
                .WithColumn("ContextPracticeSettingLkp").AsInt32().NotNullable()
                .WithForeignKeyColumn("ContextSourcePatientInfoId", "Core_Persons")
                .WithColumn("ContextRelatedOwnerId").AsString().Nullable()
                .WithColumn("ContextRelatedOwnerType").AsString().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.RelatesTo
            Create.Table("Fhir_RelationsTo")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("CodeLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("TargetId", "Fhir_DocumentReferences");

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Content
            Create.Table("Fhir_Contents")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("FormatLkp").AsInt32().Nullable();

        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

