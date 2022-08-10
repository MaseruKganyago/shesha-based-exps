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
	[ReferenceList("Fhir", "ImmunisationStatusReasons")]
	public enum RefListImmunisationStatusReasons: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Immunity (IMMUNE)")]
		immunity = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Medical Precaution (MEDPREC)")]
		medicalPrecaution = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Product Out of Stock (OSTOCK)")]
		productOutOfStock = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Patient Objection")]
		patientObjection = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent-Tetanus/Low Dose Diphtheria Vaccine")]
		noConsentTetanus = 171257003,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pertussis Vaccine Refused")]
		pertussisVaccineRefused = 171265000,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent - Diphtheria Immunization")]
		noConsentDiphtheriaImmunization = 171266004,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent - Tetanus Immunization")]
		noConsentTetanusImmunization = 171267008,
		/// <summary>
		/// 
		/// </summary>
		[Description("Polio Immunization Refused")]
		polioImmunizationRefused = 171268003,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent-Measles Immunization")]
		noConsentMeaslesImmunization = 171269006,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent-Rubella Immunization")]
		noConsentRubellaImmunization = 171270007,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent-BCG")]
		noConsentBCG = 171271006,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent Influenza Immunization")]
		noConsentInfluenzaImmunization = 171272004,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for MMR")]
		noConsentForMMR = 171280006,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for any Primary Immunization")]
		noConestForAnyPrimaryImmunization = 171283008,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent - Pre-school Vaccinations")]
		noConsentPreSchoolVaccinations = 171285001,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent-School Exit Vaccinations")]
		noConsentSchoolExitVaccinations = 171286000,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent-Haemophilus Influenzae Type B Immunization")]
		noConsentHaemophilusInfluenzaeTypeBImmunization = 171291004,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent Pneumococcal Immunization")]
		noConsentPneumococcalImmunization = 171292006,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for MR-Measles/Rubella Vaccine")]
		noConsentForMRMeaslesRubellaVaccine = 171293001,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for any Immunization")]
		noConsentForAnyImmunization = 268559007,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for MMR1")]
		noConsentForMMR1 = 310839003,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for Second Measles, Mumps and Rubella Vaccine")]
		noConsentForSecondMeaslesMumpsAndRubellaVaccine = 310840001,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent Diphtheria, Tetanus, Pertussis Immunization")]
		noConsentDiphtheriaTetanusPertussisImmunization = 314768003,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent Tetanus Plus Diphtheria Immunization")]
		noConsentTetanusPlusDiphtheriaImmunization = 314769006,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for Meningitis C Immunization")]
		noConsentForMeningitisCImmunization = 314936001,
		/// <summary>
		/// 
		/// </summary>
		[Description("No Consent for 3rd HIB Booster")]
		noConsentFor3rdHIBBooster = 407598009
	}
}
