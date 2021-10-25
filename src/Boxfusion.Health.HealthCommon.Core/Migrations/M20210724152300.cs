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
    [Migration(20210724152300)]
    public class M20210724152300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.EpisodeOfCare
            Create.Table("Fhir_EpisodeOfCares")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Appointment
            Create.Table("Fhir_Appointments")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.B.Fhir.Condition
            Create.Table("Fhir_Conditions")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Encounter
            Alter.Table("Fhir_Encounters")
                .AddColumn("Identifier").AsString().Nullable()
                .AddColumn("StatusLkp").AsInt64().Nullable()
                .AddColumn("ClassLkp").AsInt64().Nullable()
                .AddColumn("TypeLkp").AsInt64().Nullable()
                .AddColumn("ServiceTypeLkp").AsInt64().Nullable()
                .AddColumn("PriorityLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("SubjectId", "Core_Persons")
                .AddForeignKeyColumn("EpisodeOfCareId", "Fhir_EpisodeOfCares")
                .AddForeignKeyColumn("BasedOnId", "Fhir_ServiceRequests")
                .AddForeignKeyColumn("PerformerId", "Core_Persons")
                .AddColumn("StartDateTime").AsDateTime().Nullable()
                .AddColumn("EndDateTime").AsDateTime().Nullable()
                .AddColumn("ReasonCodeLkp").AsInt64().Nullable()
                .AddColumn("ReasonReferenceOwnerId").AsString().Nullable()
                .AddColumn("ReasonReferenceOwnerType").AsString().Nullable()
                .AddForeignKeyColumn("ServiceProviderId", "Core_Organisations")
                .AddForeignKeyColumn("PartOfId", "Fhir_Encounters")
                .AddColumn("Rating").AsDecimal().Nullable()
                .AddColumn("RatingComment").AsString().Nullable()
                .AddColumn("RatingTime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Participant
            Create.Table("Fhir_Participants")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithForeignKeyColumn("IndividualId", "Core_Persons")
                .WithColumn("RequiredLkp").AsInt64().Nullable()
                .WithColumn("StatusLkp").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Diagnosis
            Create.Table("Fhir_Diagnoses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithForeignKeyColumn("ConditionId", "Fhir_Conditions")
                .WithColumn("UseLkp").AsInt64().Nullable()
                .WithColumn("Rank").AsInt32().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.EncounterLocations
            Create.Table("Fhir_EncounterLocations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithForeignKeyColumn("LocationId", "Core_Facilities")
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("PhysicalTypeLkp").AsInt64().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();
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

