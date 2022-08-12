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
    [Migration(20220811103200)]
    public class M20220811103200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir
            Create.Table("Fhir_Classes")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable();

            //Boxfusion.Health.Cdm.Domain.Domain.Fhir
            Create.Table("Fhir_Coverages")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("StatusLkp").AsInt32().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("SubscriberPersonId", "Core_Persons").Nullable()
                .WithColumn("SubscriberId").AsString().Nullable()
                .WithForeignKeyColumn("BeneficiaryId", "Core_Persons").Nullable()
                .WithColumn("Dependent").AsString().Nullable()
                .WithColumn("RelationShipLkp").AsInt64().Nullable()
                .WithColumn("PeriodStart").AsDateTime().Nullable()
                .WithColumn("PeriodEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("PayorOrganisationId", "Core_Organisations").Nullable()
                .WithForeignKeyColumn("PayorPersonId", "Core_Persons").Nullable()
                .WithForeignKeyColumn("ClassId", "Fhir_Classes").Nullable()
                .WithColumn("Order").AsInt32().Nullable();

            //Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir
            Create.Table("Fhir_Items")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("CategoryLkp").AsInt64().Nullable()
                .WithColumn("ProductOrServiceLkp").AsInt64().Nullable()
                .WithColumn("Excluded").AsBoolean().Nullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("UnitLkp").AsInt64().Nullable()
                .WithColumn("TermLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("BenefitId", "Fhir_Benefits")
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable();

            //Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir
            Create.Table("Fhir_Insurances")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("CoverageId", "Fhir_Coverages").Nullable()
                .WithColumn("Inforce").AsBoolean().Nullable()
                .WithColumn("BenefitPeriodStart").AsDateTime().Nullable()
                .WithColumn("BenefitPeriodEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("ItemId", "Fhir_Items").Nullable()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable();


            //Boxfusion.Health.Cdm.Domain.Domain.Fhir
            Create.Table("Fhir_CoverageEligibilityResponses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("CoverageEligibilityResponseStatus").AsInt64().Nullable()
                .WithColumn("CoverageEligibilityResponsePurpose").AsInt64().Nullable()
                .WithForeignKeyColumn("PatientId", "Core_Persons").Nullable()
                .WithColumn("ServicedStartDate").AsDateTime().Nullable()
                .WithColumn("ServicedEndDate").AsDateTime().Nullable()
                .WithColumn("OutComeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("InsurerId", "Core_Organisations").Nullable()
                .WithForeignKeyColumn("InsuranceId", "Fhir_Insurances").Nullable()
                .WithColumn("PreAuthRef").AsString().Nullable();
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

