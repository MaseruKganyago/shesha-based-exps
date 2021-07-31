using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationFunctionCodes")]
	public enum RefListImmunisationFunctionCodes : int
	{
		[Description("Admitting (AD)")]
		admitting = 1,
		[Description("Assistant/Alternate Interpreter (AI)")]
		assistantAlternateInterpreter = 2,
		[Description("Administering Provider (AP)")]
		administeringProvider = 3,
		[Description("Attending (AT)")]
		attending = 4,
		[Description("Collecting Provider (CLP)")]
		collectingProvider = 5,
		[Description("Consulting Provider (CP)")]
		consultingProvider = 6,
		[Description("Dispensing Provider (DP)")]
		dispensingProvider = 7,
		[Description("Entering Provider (Probably not the same as transcriptionist?) EP")]
		enteringProvider = 8,
		[Description("Family Health Care Professional (FHCP)")]
		familyHealthCareProfessional = 9,
		[Description("Initiating Provider (As in action by) IP")]
		initiatingProvider = 10,
		[Description("Medical Director (MDIR)")]
		medicalDirector = 11,
		[Description("Ordering Provider (OP)")]
		oderingProvider = 12,
		[Description("Pharmacist (Not sure how to dissect Pharmacist/Treatment Supplier's Verifier ID) PH")]
		pharmacist = 13,
		[Description("Primary Interpreter (PI)")]
		primaryInterpreter = 14,
		[Description("Primary Care Provider (PP)")]
		primaryCareProvider = 15,
		[Description("Responsible Observer (RO)")]
		responsibleObserver = 16,
		[Description("Referring Provider (RP)")]
		referringProvider = 17,
		[Description("Referred to Provider (RT)")]
		referredToProvider = 18,
		[Description("Technician (TN)")]
		technician = 19,
		[Description("Transcriptionist (TR)")]
		transcriptionist = 20,
		[Description("Verifying Provider (VP)")]
		verifyingProvider = 21,
		[Description("Verifying Pharmaceutical Supplier (Not sure how to dissect/Treatment Supplier's Verifier ID) VPS")]
		verifyingPharmaceuticalSupplier = 22,
		[Description("Verifying Treatment Supplier (Not sure how dissect/Treatment Supplier's Verifier ID) VTS")]
		verifyTreatmentSupplier = 23
	}
}
