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
    [Migration(20220831142100)]
    public class M20220831142100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_Payee")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("PayeeTypeLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("PayeePersonId", "Core_Persons").Nullable()
                .WithForeignKeyColumn("PayeeOrganisationId", "Core_Organisations");

            this.Shesha().ReferenceListCreate("Fhir", "PayeeType");

            Create.Table("Fhir_Claims")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("SubTypeLkp").AsInt64().Nullable()
                .WithColumn("UseLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("PatientId", "Core_Persons").Nullable()
                .WithColumn("BillablePeriodStart").AsDateTime().Nullable()
                .WithColumn("BillablePeriodEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("InsurerId", "Fhir_Organisations").Nullable()
                .WithForeignKeyColumn("ProviderId", "Core_Persons").Nullable()
                .WithColumn("PriorityLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("PayeeId", "Fhir_Payee")
                .WithForeignKeyColumn("FacilityId", "Core_Facilities")
                .WithForeignKeyColumn("InsuranceId", "Fhir_Insurances");

            this.Shesha().ReferenceListCreate("Fhir", "ClaimType");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimSubType");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimUse");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimPriority");

            Create.Table("Fhir_ClaimResponses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("SubTypeLkp").AsInt64().Nullable()
                .WithColumn("UseLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("PatientId", "Core_Persons").Nullable()
                .WithColumn("Created").AsDateTime().Nullable()
                .WithForeignKeyColumn("InsurerId", "Core_Organisations").Nullable()
                .WithForeignKeyColumn("RequestorOrganisationId", "Core_Organisations").Nullable()
                .WithForeignKeyColumn("RequestorPractitionerId", "Core_Organisations").Nullable()
                .WithForeignKeyColumn("ClaimId", "Fhir_Claims").Nullable()
                .WithColumn("OutComeLkp").AsInt64().Nullable()
                .WithColumn("Disposition").AsString().Nullable()
                .WithColumn("PreAuthRef").AsString().Nullable()
                .WithColumn("PreAuthDateStart").AsDateTime().Nullable()
                .WithColumn("PreAuthDateEnd").AsDateTime().Nullable()
                .WithColumn("PayeeTypeLkp").AsInt64().Nullable();

            this.Shesha().ReferenceListCreate("Fhir", "ClaimResponseType");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimResponseSubType");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimUse");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimResponsePayeeType");

            Create.Table("Fhir_ClaimInsurances")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Focal").AsBoolean().Nullable()
                .WithForeignKeyColumn("CoverageId", "Fhir_Coverages").Nullable()
                .WithColumn("PreAuthRef").AsString().Nullable()
                .WithForeignKeyColumn("ClaimResponseId", "Fhir_ClaimResponses")
                .WithColumn("Total").AsDecimal().Nullable()
                .WithForeignKeyColumn("InvoiceId", "entpr_Invoices").Nullable()
                .WithColumn("ClaimSubmissionMethodLkp").AsInt64().Nullable()
                .WithColumn("AmountExcluded").AsDecimal().Nullable()
                .WithColumn("PaidToProvider").AsDecimal().Nullable()
                .WithColumn("PaidToMember").AsDecimal().Nullable()
                .WithColumn("RemarksCode").AsString(2000).Nullable()
                .WithColumn("Remarks").AsString(2000).Nullable()
                .WithColumn("ResponseSystemMessage").AsStringMax().Nullable()
                .WithColumn("ResponseMessage").AsStringMax().Nullable()
                .WithForeignKeyColumn("ResponseAttachmentsId", "Frwk_StoredFiles").Nullable()
                .WithColumn("ResponseDate").AsDateTime().Nullable()
                .WithColumn("ResponseOutComeLkp").AsInt64().Nullable();

            this.Shesha().ReferenceListCreate("Fhir", "ClaimSubmissionedMethod");
            this.Shesha().ReferenceListCreate("Fhir", "ClaimResponseOutCome");
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

