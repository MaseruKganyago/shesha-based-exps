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
	[ReferenceList("Fhir", "ImmunisationFunctionCodes")]
	public enum RefListImmunisationFunctionCodes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Admitting (AD)")]
		admitting = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Assistant/Alternate Interpreter (AI)")]
		assistantAlternateInterpreter = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Administering Provider (AP)")]
		administeringProvider = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Attending (AT)")]
		attending = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Collecting Provider (CLP)")]
		collectingProvider = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Consulting Provider (CP)")]
		consultingProvider = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Dispensing Provider (DP)")]
		dispensingProvider = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Entering Provider (Probably not the same as transcriptionist?) EP")]
		enteringProvider = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Family Health Care Professional (FHCP)")]
		familyHealthCareProfessional = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Initiating Provider (As in action by) IP")]
		initiatingProvider = 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("Medical Director (MDIR)")]
		medicalDirector = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Ordering Provider (OP)")]
		oderingProvider = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pharmacist (Not sure how to dissect Pharmacist/Treatment Supplier's Verifier ID) PH")]
		pharmacist = 13,
		/// <summary>
		/// 
		/// </summary>
		[Description("Primary Interpreter (PI)")]
		primaryInterpreter = 14,
		/// <summary>
		/// 
		/// </summary>
		[Description("Primary Care Provider (PP)")]
		primaryCareProvider = 15,
		/// <summary>
		/// 
		/// </summary>
		[Description("Responsible Observer (RO)")]
		responsibleObserver = 16,
		/// <summary>
		/// 
		/// </summary>
		[Description("Referring Provider (RP)")]
		referringProvider = 17,
		/// <summary>
		/// 
		/// </summary>
		[Description("Referred to Provider (RT)")]
		referredToProvider = 18,
		/// <summary>
		/// 
		/// </summary>
		[Description("Technician (TN)")]
		technician = 19,
		/// <summary>
		/// 
		/// </summary>
		[Description("Transcriptionist (TR)")]
		transcriptionist = 20,
		/// <summary>
		/// 
		/// </summary>
		[Description("Verifying Provider (VP)")]
		verifyingProvider = 21,
		/// <summary>
		/// 
		/// </summary>
		[Description("Verifying Pharmaceutical Supplier (Not sure how to dissect/Treatment Supplier's Verifier ID) VPS")]
		verifyingPharmaceuticalSupplier = 22,
		/// <summary>
		/// 
		/// </summary>
		[Description("Verifying Treatment Supplier (Not sure how dissect/Treatment Supplier's Verifier ID) VTS")]
		verifyTreatmentSupplier = 23
	}
}
