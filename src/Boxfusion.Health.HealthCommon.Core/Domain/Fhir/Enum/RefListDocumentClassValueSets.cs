using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "DocumentClassValueSets")]
	public enum RefListDocumentClassValueSets: UInt64
	{
		[Description("History of Immunization")]
		historyOfImmunization = 1,
		[Description("Anesthesia records")]
		anesthesiaRecords = 2,
		[Description("Chemotherapy records")]
		chemotherapyRecords = 4,
		[Description("Consult Note")]
		consultNote = 8,
		[Description("Provider-unspecified progress note")]
		providerUnspecifiedProgressNot = 16,
		[Description("Nursery records")]
		nurseryRecords = 32,
		[Description("Labor and delivery records")]
		laborAndDeliveryRecords = 64,
		[Description("Radiology studies (set)")]
		radiologyStudies = 128,
		[Description("Provider-unspecified transfer summary")]
		providerUnspecifiedTransferSummary = 256,
		[Description("Discharge summary")]
		dischargeSummary = 512,
		[Description("Laboratory Studies (set)")]
		laboratoryStudies = 1024,
		[Description("Cardiology studies (set)")]
		cardiologyStudies = 2048,
		[Description("Obstetrical studies (set)")]
		obstetricalStudies = 4096,
		[Description("Gastroenterology endoscopy studies (set)")]
		gastroenterologyEndoscopyStudies = 8192,
		[Description("Pulmonary studies (set)")]
		pulmonaryStudies = 16384,
		[Description("Neuromuscular electrophysiology studies (set)")]
		neuromuscularElectrophysiologyStudies = 32768,
		[Description("Pathology studies (set)")]
		pathologyStudies = 65536,
		[Description("Provider-unspecified procedure note")]
		providerUnspecifiedProcedureNote = 131072,
		[Description("Ophthalmology/optometry studies (set)")]
		ophthalmologyOptometryStudies = 262144,
		[Description("Miscellaneous studies (set)")]
		miscellaneousStudies = 524288,
		[Description("Dialysis records")]
		dialysisRecords = 1084576,
		[Description("Neonatal intensive care records")]
		neonatalIntensiveCareRecords = 2097152,
		[Description("Critical care records")]
		criticalCareRecords = 4194304,
		[Description("Perioperative records")]
		perioperativeRecords = 8388608,
		[Description("Evaluation and management note")]
		evaluationAndManagentNote = 16777216,
		[Description("Provider-unspecified, History and physical note")]
		providerUnspecifiedHistoryAndPhysicalNote = 33554432,
		[Description("Interventional procedure note")]
		interventionalProcedureNote = 67108864,
		[Description("Pathology procedure note")]
		pathologyProcedureNote = 134217728,
		[Description("Summarization of episode note")]
		summarizationOfEpisodeNote = 268435456,
		[Description("Transfer of care referral note")]
		transferOfCareReferralNote = 536870912,
		[Description("Telephone encounter note")]
		telephoneEncounterNote = 1073741824,
		[Description("General surgery Pre-operative evaluation and management note")]
		generalSurgeryPreoperativeEvaluationAndManagementNote = 2147483648,
		[Description("Inpatient Admission history and physical note")]
		inpatientAdmissionHistoryAndPhysicalNote = 4294967296,
		[Description("Counseling note")]
		counselingNote = 8589934592,
		[Description("Study Report Document")]
		studyReportDocument = 17179869184,
		[Description("Summary of death")]
		summaryOfDeath = 34359738368,
		[Description("Non-patient Communication")]
		nonPatientCommunication = 68719476736,
		[Description("Privacy Policy Organization Document")]
		privacyPolicyOrganizationDocument = 137438953472,
		[Description("Privacy Policy Acknowledgment Document")]
		privacyPolicyAcknowledgmentDocument = 274877906944,
		[Description("Medication Summary Document")]
		medicationSummaryDocument = 549755813888,
		[Description("Personal Health Monitoring Report Document")]
		personalHealthMonitoringReportDocument = 1099511627776,
		[Description("Plan of care note")]
		planOfCareNote = 2199023255552,
		[Description("Diagnostic imaging study")]
		diagnosticImagingStudy = 4398046511104,
		[Description("Surgical operation note")]
		surgicalOperationNote = 8796093022208,
		[Description("Referral note")]
		referralNote = 17592186044416
	}
}
