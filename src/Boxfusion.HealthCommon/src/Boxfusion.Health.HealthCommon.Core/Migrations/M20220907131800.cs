using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220907131800)]
    public class M20220907131800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			#region Delete Insurance ForeignKey
			Delete.ForeignKey("FK_Fhir_CoverageEligibilityResponses_InsuranceId_Fhir_Insurances_Id").OnTable("Fhir_CoverageEligibilityResponses");
			Delete.Index("IX_Fhir_CoverageEligibilityResponses_InsuranceId").OnTable("Fhir_CoverageEligibilityResponses");
			Delete.Column("InsuranceId").FromTable("Fhir_CoverageEligibilityResponses");
            #endregion

            Alter.Table("Fhir_CoverageEligibilityResponses")
                .AddForeignKeyColumn("InsuranceCoverageId", "Fhir_Coverages").Nullable()
                .AddColumn("InsuranceInForce").AsBoolean()
                .AddColumn("InsuranceBenefitPeriodStart").AsDateTime().Nullable()
                .AddColumn("InsuranceBenefitPeriodEnd").AsDateTime().Nullable()
                .AddColumn("ItemCategoryLkp").AsInt64().Nullable()
                .AddColumn("ItemProductOrServiceLkp").AsInt64().Nullable()
                .AddColumn("ItemExcluded").AsBoolean()
                .AddColumn("ItemName").AsString(510).Nullable()
                .AddColumn("ItemUnitLkp").AsInt64().Nullable()
                .AddColumn("ItemTermLkp").AsInt64().Nullable()
                .AddColumn("BenefitTypeLkp").AsInt64().Nullable()
                .AddColumn("BenefitAllowedMoney").AsDecimal().Nullable();

            this.Shesha().ReferenceListCreate("Fhir", "CoverageEligibilityResponseStatus");
            this.Shesha().ReferenceListCreate("Fhir", "CoverageEligibilityResponsePurpose");
            this.Shesha().ReferenceListCreate("Fhir", "CoverageEligibilityResponseOutcome");
            this.Shesha().ReferenceListCreate("Fhir", "ItemCategory");
            this.Shesha().ReferenceListCreate("Fhir", "ItemProductOrService");
            this.Shesha().ReferenceListCreate("Fhir", "ItemUnit");
            this.Shesha().ReferenceListCreate("Fhir", "ItemTerm");
            this.Shesha().ReferenceListCreate("Fhir", "BenefitType");

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

