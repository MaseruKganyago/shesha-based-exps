using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "DocumentReferenceFormatCodeSets")]
	public enum RefListDocumentReferenceFormatCodeSets: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Personal Health Records. Also known as HL7 CCD and HITSP C32")]
		personalHealthRecords = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("IHE Antepartum Summary")]
		iheAntepartumSummary = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("XDS Medical Summaries")]
		xdsMedicalSummaries = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency Department Referral (EDR)")]
		emergencyDepartmentReferral = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency Department Encounter Summary (EDES)")]
		emergencyDepartmentEncounterSummary = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Antepartum Record (APR) - History and Physical")]
		antepartumRecordHisoryPhysical = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Antepartum Record (APR) - Laboratory")]
		antepartumRecordLaboratory = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Antepartum Record (APR) - Education")]
		antepartumRecordEducation = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Cancer Registry Content (CRC)")]
		cancerRegistryContent = 9,

		/// <summary>
		/// 
		/// </summary>
		[Description("Care Management (CM)")]
		careManagement = 10,

		/// <summary>
		/// 
		/// </summary>
		[Description("Immunization Content (IC)")]
		immunizationContent = 11,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC TN")]
		pccTN = 12,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC NN")]
		pccNN = 13,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC CTN")]
		pccCTN = 14,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC EDPN")]
		pccEDPN = 15,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC HP")]
		pccHP = 16,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC LDHP")]
		pccLDHP = 17,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC LDS")]
		pccLDS = 18,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC MDS")]
		pccMDS = 19,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC NDS")]
		pccNDS = 20,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC PPVS")]
		pccPPVS = 21,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC TRS")]
		pccTRS = 22,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC ETS")]
		pccETS = 23,

		/// <summary>
		/// 
		/// </summary>
		[Description("PCC ITS")]
		pccITS = 24,

		/// <summary>
		/// 
		/// </summary>
		[Description("Routine Interfacility Patient Transport (RIPT)")]
		routineInterfacilityPatientTransport = 25,

		/// <summary>
		/// 
		/// </summary>
		[Description("Basic Patient Privacy Consents")]
		basicPatientPrivacyConsents = 26,

		/// <summary>
		/// 
		/// </summary>
		[Description("Basic Patient Privacy Consents with Scanned Document")]
		basicPatientPrivacyConsentsWithScannedDocument = 27
	}
}
