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
    [Migration(20210906134600)]
    public class M20210906134600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ServiceRequest
            Alter.Column("StatusLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("IntentLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("CategoryLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("PriorityLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("CodeLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("OrderDetailLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("AsNeededCodeableConceptLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("PerformerTypeLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("LocationCodeLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("ReasonCodeLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("BodySiteLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.CdmServiceRequest
            //Alter.Column("ScheduleTypeLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("ServiceQueuePriorityLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("ConsultServiceRequestStatusLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.MedicationRequest
            Alter.Column("StatusLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("StatusReasonLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("IntentLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();            
            Alter.Column("MedicationCodeableConceptLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("PerformerTypeLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("ReasonCodeLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("CourseOfTherapyTypeLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("AllowCodeableConceptLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();
            Alter.Column("ReasonLkp").OnTable("Fhir_MedicationRequests").AsInt64().Nullable();

            Delete.Column("CategoryLkpk").FromTable("Fhir_MedicationRequests");
            Alter.Table("Fhir_MedicationRequests").AddColumn("CategoryLkp").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Medication
            Alter.Column("CodeLkp").OnTable("Fhir_Medications").AsInt64().Nullable();
            Alter.Column("StatusLkp").OnTable("Fhir_Medications").AsInt64().Nullable();
            Alter.Column("FormLkp").OnTable("Fhir_Medications").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.AmbulanceServiceRequest
            Alter.Column("ProvisionalConditionLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.ReferralServiceRequest
            Alter.Column("DepartmentLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.DiagnosticTestServiceRequest
            Alter.Column("ExaminationTypeLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();
            Alter.Column("BodyPartLkp").OnTable("Fhir_ServiceRequests").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Observation
            Alter.Column("StatusLkp").OnTable("Fhir_Observations").AsInt64().Nullable();
            Alter.Column("CategoryLkp").OnTable("Fhir_Observations").AsInt64().Nullable();
            Alter.Column("CodeLkp").OnTable("Fhir_Observations").AsInt64().Nullable();
            Alter.Column("DataAbsentReasonLkp").OnTable("Fhir_Observations").AsInt64().Nullable();
            Alter.Column("InterpretationLkp").OnTable("Fhir_Observations").AsInt64().Nullable();
            Alter.Column("BodySiteLkp").OnTable("Fhir_Observations").AsInt64().Nullable();
            Alter.Column("MethodLkp").OnTable("Fhir_Observations").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Component
            Alter.Column("ValueCodeableConceptLkp").OnTable("Fhir_Components").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Immunisation
            Alter.Column("StatusLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("StatusReasonLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("VaccineCodeLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("ReportOriginLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("SiteLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("RouteLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("PerformerFunctionLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("ReasonCodeLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("SubpotentReasonLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("ProgramEligibilityLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
            Alter.Column("FundingSourceLkp").OnTable("Fhir_Immunisations").AsInt64().Nullable();
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

