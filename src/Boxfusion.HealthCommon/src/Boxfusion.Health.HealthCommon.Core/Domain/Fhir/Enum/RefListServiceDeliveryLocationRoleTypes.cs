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
	[ReferenceList("Fhir", "ServiceDeliveryLocationRoleTypes")]
	public enum RefListServiceDeliveryLocationRoleTypes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Diagnostics or therapeutics unit")]
		DX = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Cardiovascular diagnostics or therapeutics unit")]
		CVDX = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Cardiac catheterization lab")]
		CATH = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Echocardiography lab")]
		ECHO = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Gastroenterology diagnostics or therapeutics lab")]
		GIDX = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Endoscopy lab")]
		GENDOSIDX = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Radiology diagnostics or therapeutics unit")]
		RADDX = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Radiation oncology unit")]
		RADO = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Neuroradiology unit")]
		RNEU = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hospital")]
		HOSP = 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("Chronic Care Facility")]
		CHR = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hospitals; General Acute Care Hospital")]
		GACH = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Military Hospital")]
		MHSP = 13,
		/// <summary>
		/// 
		/// </summary>
		[Description("Psychatric Care Facility")]
		PSYCHF = 14,
		/// <summary>
		/// 
		/// </summary>
		[Description("Rehabilitation hospital")]
		RH = 15,
		/// <summary>
		/// 
		/// </summary>
		[Description("Addiction treatment center")]
		RHAT = 16,
		/// <summary>
		/// 
		/// </summary>
		[Description("Intellectual impairment center")]
		RHII = 17,
		/// <summary>
		/// 
		/// </summary>
		[Description("Parents with adjustment difficulties center")]
		RHMAD = 18,
		/// <summary>
		/// 
		/// </summary>
		[Description("Physical impairment center")]
		RHPI = 19,
		/// <summary>
		/// 
		/// </summary>
		[Description("Physical impairment - hearing center")]
		RHPIH = 20,
		/// <summary>
		/// 
		/// </summary>
		[Description("Physical impairment - motor skills center")]
		RHPIMS = 21,
		/// <summary>
		/// 
		/// </summary>
		[Description("Physical impairment - visual skills center")]
		RHPIVS = 22,
		/// <summary>
		/// 
		/// </summary>
		[Description("Youths with adjustment difficulties center")]
		RHYAD = 23,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hospital unit")]
		HU = 24,
		/// <summary>
		/// 
		/// </summary>
		[Description("Bone marrow transplant unit")]
		BMTU = 25,
		/// <summary>
		/// 
		/// </summary>
		[Description("Coronary care unit")]
		CCU = 26,
		/// <summary>
		/// 
		/// </summary>
		[Description("Chest unit")]
		CHEST = 27,
		/// <summary>
		/// 
		/// </summary>
		[Description("Epilepsy unit")]
		EPIL = 28,
		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency room")]
		ER = 29,
		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency trauma unit")]
		ETU = 30,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hemodialysis unit")]
		HD = 31,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hospital laboratory")]
		HLAB = 32,
		/// <summary>
		/// 
		/// </summary>
		[Description("Inpatient laboratory")]
		INLAB = 33,
		/// <summary>
		/// 
		/// </summary>
		[Description("Outpatient laboratory")]
		OUTLAB = 34,
		/// <summary>
		/// 
		/// </summary>
		[Description("Radiology unit")]
		HRAD = 35,
		/// <summary>
		/// 
		/// </summary>
		[Description("Specimen collection site")]
		HUSCS = 36,
		/// <summary>
		/// 
		/// </summary>
		[Description("Intensive care unit")]
		ICU = 37,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric intensive care unit")]
		PEDICU = 38,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric neonatal intensive care unit")]
		PEDNICU = 39,
		/// <summary>
		/// 
		/// </summary>
		[Description("Inpatient pharmacy")]
		INPHARM = 40,
		/// <summary>
		/// 
		/// </summary>
		[Description("Medical laboratory")]
		MBL = 41,
		/// <summary>
		/// 
		/// </summary>
		[Description("Neurology critical care and stroke unit")]
		NCCS = 42,
		/// <summary>
		/// 
		/// </summary>
		[Description("Neurosurgery unit")]
		NS = 43,

		[Description("Outpatient pharmacy")]
		OUTPHARM = 44,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric unit")]
		PEDU = 45,
		/// <summary>
		/// 
		/// </summary>
		[Description("Psychiatric hospital unit")]
		PHU = 46,
		/// <summary>
		/// 
		/// </summary>
		[Description("Rehabilitation hospital unit")]
		RHU = 47,
		/// <summary>
		/// 
		/// </summary>
		[Description("Sleep disorders unit")]
		SLEEP = 48,
		/// <summary>
		/// 
		/// </summary>
		[Description("Nursing or custodial care facility")]
		NCCF = 49,
		/// <summary>
		/// 
		/// </summary>
		[Description("Skilled nursing facility")]
		SNF = 50,
		/// <summary>
		/// 
		/// </summary>
		[Description("Outpatient facility")]
		OF = 51,
		/// <summary>
		/// 
		/// </summary>
		[Description("Allergy clinic")]
		ALL = 52,
		/// <summary>
		/// 
		/// </summary>
		[Description("Amputee clinic")]
		AMPUT = 53,
		/// <summary>
		/// 
		/// </summary>
		[Description("Bone marrow transplant clinic")]
		BMTC = 54,
		/// <summary>
		/// 
		/// </summary>
		[Description("Breast clinic")]
		BREAST = 55,
		/// <summary>
		/// 
		/// </summary>
		[Description("Child and adolescent neurology clinic")]
		CANC =56,
		/// <summary>
		/// 
		/// </summary>
		[Description("Child and adolescent psychiatry clinic")]
		CAPC = 57,
		/// <summary>
		/// 
		/// </summary>
		[Description("Ambulatory Health Care Facilities; Clinic/Center; Rehabilitation: Cardiac Facilities")]
		CARD = 58,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric cardiology clinic")]
		PEDCARD = 59,
		/// <summary>
		/// 
		/// </summary>
		[Description("Coagulation clinic")]
		COAG = 60,
		/// <summary>
		/// 
		/// </summary>
		[Description("Colon and rectal surgery clinic")]
		CRS = 61,
		/// <summary>
		/// 
		/// </summary>
		[Description("Dermatology clinic")]
		DERM = 62,
		/// <summary>
		/// 
		/// </summary>
		[Description("Endocrinology clinic")]
		ENDO = 63,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric endocrinology clinic")]
		PEDE = 64,
		/// <summary>
		/// 
		/// </summary>
		[Description("Otorhinolaryngology clinic")]
		ENT = 65,
		/// <summary>
		/// 
		/// </summary>
		[Description("Family medicine clinic")]
		FMC = 66,
		/// <summary>
		/// 
		/// </summary>
		[Description("Gastroenterology clinic")]
		GI = 67,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric gastroenterology clinic")]
		PEDGI = 68,
		/// <summary>
		/// 
		/// </summary>
		[Description("General internal medicine clinic")]
		GIM = 69,
		/// <summary>
		/// 
		/// </summary>
		[Description("Gynecology clinic")]
		GYN = 70,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hematology clinic")]
		HEM = 71,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric hematology clinic")]
		PEDHEM = 72,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hypertension clinic")]
		HTN = 73,
		/// <summary>
		/// 
		/// </summary>
		[Description("Impairment evaluation center")]
		IEC = 74,
		/// <summary>
		/// 
		/// </summary>
		[Description("Infectious disease clinic")]
		INFD = 75,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric infectious disease clinic")]
		PEDID = 76,
		/// <summary>
		/// 
		/// </summary>
		[Description("Infertility clinic")]
		INV = 77,
		/// <summary>
		/// 
		/// </summary>
		[Description("Lympedema clinic")]
		LYMPH = 78,
		/// <summary>
		/// 
		/// </summary>
		[Description("Medical genetics clinic")]
		MGEN = 79,
		/// <summary>
		/// 
		/// </summary>
		[Description("Nephrology clinic")]
		NEPH = 80,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric nephrology clinic")]
		PEDNEPH = 81,
		/// <summary>
		/// 
		/// </summary>
		[Description("Neurology clinic")]
		NEUR = 82,
		/// <summary>
		/// 
		/// </summary>
		[Description("Obstetrics clinic")]
		OB = 83,
		/// <summary>
		/// 
		/// </summary>
		[Description("Oral and maxillofacial surgery clinic")]
		OMS = 84,
		/// <summary>
		/// 
		/// </summary>
		[Description("Medical oncology clinic")]
		ONCL = 85,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric oncology clinic")]
		PEDHO = 86,
		/// <summary>
		/// 
		/// </summary>
		[Description("Opthalmology clinic")]
		OPH = 87,
		/// <summary>
		/// 
		/// </summary>
		[Description("Optometry clinic")]
		OPTC = 88,
		/// <summary>
		/// 
		/// </summary>
		[Description("Orthopedics clinic")]
		ORTHO = 89,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hand clinic")]
		HAND = 90,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pain clinic")]
		PAINCL = 91,
		/// <summary>
		/// 
		/// </summary>
		[Description("Primary care clinic")]
		PC = 92,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatrics clinic")]
		PEDC = 93,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pediatric rheumatology clinic")]
		PEDRHEUM = 94,
		/// <summary>
		/// 
		/// </summary>
		[Description("Podiatry clinic")]
		POD = 95,
		/// <summary>
		/// 
		/// </summary>
		[Description("Preventive medicine clinic")]
		PREV = 97,
		/// <summary>
		/// 
		/// </summary>
		[Description("Proctology clinic")]
		PROCTO = 98,
		/// <summary>
		/// 
		/// </summary>
		[Description("Provider's Office")]
		PROFF = 99,
		/// <summary>
		/// 
		/// </summary>
		[Description("Prosthodontics clinic")]
		PROS = 100,
		/// <summary>
		/// 
		/// </summary>
		[Description("Psychology clinic")]
		PSI = 101,
		/// <summary>
		/// 
		/// </summary>
		[Description("Psychiatry clinic")]
		PSY = 102,
		/// <summary>
		/// 
		/// </summary>
		[Description("Rheumatology clinic")]
		RHEUM = 103,
		/// <summary>
		/// 
		/// </summary>
		[Description("Sports medicine clinic")]
		SPMED = 104,
		/// <summary>
		/// 
		/// </summary>
		[Description("Surgery clinic")]
		SU = 105,
		/// <summary>
		/// 
		/// </summary>
		[Description("Plastic surgery clinic")]
		PLS = 106,
		/// <summary>
		/// 
		/// </summary>
		[Description("Urology clinic")]
		URO = 107,
		/// <summary>
		/// 
		/// </summary>
		[Description("Transplant clinic")]
		TR = 108,
		/// <summary>
		/// 
		/// </summary>
		[Description("Travel and geographic medicine clinic")]
		TRAVEL = 109,
		/// <summary>
		/// 
		/// </summary>
		[Description("Wound clinic")]
		WND = 110,
		/// <summary>
		/// 
		/// </summary>
		[Description("Residential treatment facility")]
		RTF = 111,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pain rehabilitation center")]
		PRC = 112,
		/// <summary>
		/// 
		/// </summary>
		[Description("Substance use rehabilitation facility")]
		SURF = 113,
		/// <summary>
		/// 
		/// </summary>
		[Description("Delivery Address")]
		DADDR = 114,
		/// <summary>
		/// 
		/// </summary>
		[Description("Mobile Unit")]
		MOBL = 115,
		/// <summary>
		/// 
		/// </summary>
		[Description("Ambulance")]
		AMB = 116,
		/// <summary>
		/// 
		/// </summary>
		[Description("Pharmacy")]
		PHARM = 117,
		/// <summary>
		/// 
		/// </summary>
		[Description("Accident site")]
		ACC = 118,
		/// <summary>
		/// 
		/// </summary>
		[Description("Community Location")]
		COMM = 119,
		/// <summary>
		/// 
		/// </summary>
		[Description("Community service center")]
		CSC = 120,
		/// <summary>
		/// 
		/// </summary>
		[Description("Patient's Residence")]
		PTRES = 121,
		/// <summary>
		/// 
		/// </summary>
		[Description("School")]
		SCHOOL = 122,
		/// <summary>
		/// 
		/// </summary>
		[Description("Underage protection center")]
		UPC = 123,
		/// <summary>
		/// 
		/// </summary>
		[Description("Work site")]
		WORK = 124,	   
	}
}
