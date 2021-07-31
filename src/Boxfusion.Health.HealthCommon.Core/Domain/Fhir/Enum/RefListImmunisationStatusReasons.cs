using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationStatusReasons")]
	public enum RefListImmunisationStatusReasons: int
	{
		[Description("Immunity (IMMUNE)")]
		immunity = 1,
		[Description("Medical Precaution (MEDPREC)")]
		medicalPrecaution = 2,
		[Description("Product Out of Stock (OSTOCK)")]
		productOutOfStock = 3,
		[Description("Patient Objection")]
		patientObjection = 4,
		[Description("No Consent-Tetanus/Low Dose Diphtheria Vaccine")]
		noConsentTetanus = 171257003,
		[Description("Pertussis Vaccine Refused")]
		pertussisVaccineRefused = 171265000,
		[Description("No Consent - Diphtheria Immunization")]
		noConsentDiphtheriaImmunization = 171266004,
		[Description("No Consent - Tetanus Immunization")]
		noConsentTetanusImmunization = 171267008,
		[Description("Polio Immunization Refused")]
		polioImmunizationRefused = 171268003,
		[Description("No Consent-Measles Immunization")]
		noConsentMeaslesImmunization = 171269006,
		[Description("No Consent-Rubella Immunization")]
		noConsentRubellaImmunization = 171270007,
		[Description("No Consent-BCG")]
		noConsentBCG = 171271006,
		[Description("No Consent Influenza Immunization")]
		noConsentInfluenzaImmunization = 171272004,
		[Description("No Consent for MMR")]
		noConsentForMMR = 171280006,
		[Description("No Consent for any Primary Immunization")]
		noConestForAnyPrimaryImmunization = 171283008,
		[Description("No Consent - Pre-school Vaccinations")]
		noConsentPreSchoolVaccinations = 171285001,
		[Description("No Consent-School Exit Vaccinations")]
		noConsentSchoolExitVaccinations = 171286000,
		[Description("No Consent-Haemophilus Influenzae Type B Immunization")]
		noConsentHaemophilusInfluenzaeTypeBImmunization = 171291004,
		[Description("No Consent Pneumococcal Immunization")]
		noConsentPneumococcalImmunization = 171292006,
		[Description("No Consent for MR-Measles/Rubella Vaccine")]
		noConsentForMRMeaslesRubellaVaccine = 171293001,
		[Description("No Consent for any Immunization")]
		noConsentForAnyImmunization = 268559007,
		[Description("No Consent for MMR1")]
		noConsentForMMR1 = 310839003,
		[Description("No Consent for Second Measles, Mumps and Rubella Vaccine")]
		noConsentForSecondMeaslesMumpsAndRubellaVaccine = 310840001,
		[Description("No Consent Diphtheria, Tetanus, Pertussis Immunization")]
		noConsentDiphtheriaTetanusPertussisImmunization = 314768003,
		[Description("No Consent Tetanus Plus Diphtheria Immunization")]
		noConsentTetanusPlusDiphtheriaImmunization = 314769006,
		[Description("No Consent for Meningitis C Immunization")]
		noConsentForMeningitisCImmunization = 314936001,
		[Description("No Consent for 3rd HIB Booster")]
		noConsentFor3rdHIBBooster = 407598009
	}
}
