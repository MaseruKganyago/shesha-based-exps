using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "MedicationRequestStatusReasonCodes")]
	public enum RefListMedicationRequestStatusReasonCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Try Another Treatment First")]
		tryAnotherTreatmentFirst = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Prescription Requires Clarification")]
		prescriptionRequiresClarification = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Drug Level too High")]
		drugLevelTooHigh = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Admissions to Hospital")]
		admissionsToHospital = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Lab Interference Issues")]
		labInterferenceIssues = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Patient not Available")]
		patientNotAvailable = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Parent is Pregnant/Breast Feeding")]
		parentPregnantOrBreastFeeding = 7,
		[Description("Allergy")]
		allergy = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Drug Interacts with Another Drug")]
		drugInteractsWithAnotherDrug = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Duplicate Therapy")]
		duplicateTherapy= 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("Suspected Intolerance")]
		suspectedIntolerance = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Patient Scheduled for Surgery")]
		patientScheduledForSurgery = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Waiting for old Drug to Wash out")]
		waitingForOldDrugToWashOut = 13
	}
}
