using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	/// <summary>
	/// 
	/// </summary>
    [ReferenceList("Fhir", "QualificationCodes")]
    public enum RefListQualificationCodes
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("Associate of Arts")]
		AA = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Associate of Applied Science")]
		AAS = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Associate of Business Administration")]
		ABS = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Associate of Engineering")]
		AE = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Associate of Science")]
		ASC = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Arts")]
		BA = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Business Administration")]
		BBA = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor or Engineering")]
		BE = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Fine Arts")]
		BFA = 9,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Nursing")]
		BN = 10,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Science")]
		BS = 11,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Science - Law")]
		BLS = 12,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor on Science - Nursing")]
		BSN = 13,

		/// <summary>
		/// 
		/// </summary>
		[Description("Bachelor of Theology")]
		BT = 14,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Adult Nurse Practitioner")]
		CANP = 15,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certificate")]
		CER = 16,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Medical Assistant")]
		CMA = 17,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Nurse Midwife")]
		CNM = 18,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Nurse Practitioner")]
		CNP = 19,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Nurse Specialist")]
		CNS = 20,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Pediatric Nurse Practitioner")]
		CPNP = 21,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Registered Nurse")]
		CRN = 22,

		/// <summary>
		/// 
		/// </summary>
		[Description("Certified Tumor Registrar")]
		CTR = 23,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Business Administration")]
		DBA = 24,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Education")]
		DED = 25,

		/// <summary>
		/// 
		/// </summary>
		[Description("Diploma")]
		DIP = 26,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Osteopathy")]
		DOS = 27,

		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency Medical Technician")]
		EMT = 28,

		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency Medical Technician - Paramedic")]
		EMTP = 29,

		/// <summary>
		/// 
		/// </summary>
		[Description("Family Practice Nurse Practitioner")]
		FPNP = 30,

		/// <summary>
		/// 
		/// </summary>
		[Description("High School Graduate")]
		HS = 31,

		/// <summary>
		/// 
		/// </summary>
		[Description("Juris Doctor")]
		JD = 32,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Arts")]
		MA = 33,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Business Administration")]
		MBA = 34,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Civil Engineering")]
		MCE = 35,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Medicine")]
		MD = 36,

		/// <summary>
		/// 
		/// </summary>
		[Description("Medical Assistant")]
		MDA = 37,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Divinity")]
		MDI = 38,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Engineering")]
		ME = 39,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Education")]
		MED = 40,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Electrical Engineering")]
		MEE = 41,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Fine Arts")]
		MFA = 42,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Mechanical Engineering")]
		MME = 43,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Science")]
		MS = 44,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Science - Law")]
		MSL = 45,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Science - Nursing")]
		MSN = 46,

		/// <summary>
		/// 
		/// </summary>
		[Description("Medical Technician")]
		MT = 47,

		/// <summary>
		/// 
		/// </summary>
		[Description("Master of Theology")]
		MTH = 48,

		/// <summary>
		/// 
		/// </summary>
		[Description("Non-Graduate")]
		NG = 49,

		/// <summary>
		/// 
		/// </summary>
		[Description("Nurse Practitioner")]
		NP = 50,

		/// <summary>
		/// 
		/// </summary>
		[Description("Physician Assistant")]
		PA = 51,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Philosophy")]
		PHD = 52,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Engineering")]
		PHE = 53,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Science")]
		PHS = 54,

		/// <summary>
		/// 
		/// </summary>
		[Description("Advanced Practice Nurse")]
		PN = 55,

		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor of Pharmacy")]
		PharmD = 56,

		/// <summary>
		/// 
		/// </summary>
		[Description("Registered Medical Assistant")]
		RMA = 57,

		/// <summary>
		/// 
		/// </summary>
		[Description("Registered Nurse")]
		RN = 58,

		/// <summary>
		/// 
		/// </summary>
		[Description("Registered Pharmacist")]
		RPH = 59,

		/// <summary>
		/// 
		/// </summary>
		[Description("Secretarial Certificate")]
		SEC = 60,

		/// <summary>
		/// 
		/// </summary>
		[Description("Trade School Graduate")]
		TS = 61
	}
}
