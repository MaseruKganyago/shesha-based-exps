using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationRequestStatusReasonCodes")]
	public enum RefListMedicationRequestStatusReasonCodes: int
	{
		[Description("Try Another Treatment First")]
		tryAnotherTreatmentFirst = 1,
		[Description("Prescription Requires Clarification")]
		prescriptionRequiresClarification = 2,
		[Description("Drug Level too High")]
		drugLevelTooHigh = 3,
		[Description("Admissions to Hospital")]
		admissionsToHospital = 4,
		[Description("Lab Interference Issues")]
		labInterferenceIssues = 5,
		[Description("Patient not Available")]
		patientNotAvailable = 6,
		[Description("Parent is Pregnant/Breast Feeding")]
		parentPregnantOrBreastFeeding = 7,
		[Description("Allergy")]
		allergy = 8,
		[Description("Drug Interacts with Another Drug")]
		drugInteractsWithAnotherDrug = 9,
		[Description("Duplicate Therapy")]
		duplicateTherapy= 10,
		[Description("Suspected Intolerance")]
		suspectedIntolerance = 11,
		[Description("Patient Scheduled for Surgery")]
		patientScheduledForSurgery = 12,
		[Description("Waiting for old Drug to Wash out")]
		waitingForOldDrugToWashOut = 13
	}
}
