using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ServiceDeliveryLocationRoleTypes")]
	public enum RefListServiceDeliveryLocationRoleTypes: int
	{
		[Description("Diagnostics or therapeutics unit")]
		DX = 1,

		[Description("Cardiovascular diagnostics or therapeutics unit")]
		CVDX = 2,

		[Description("Cardiac catheterization lab")]
		CATH = 3,

		[Description("Echocardiography lab")]
		ECHO = 4,

		[Description("Gastroenterology diagnostics or therapeutics lab")]
		GIDX = 5,

		[Description("Endoscopy lab")]
		GENDOSIDX = 6,

		[Description("Radiology diagnostics or therapeutics unit")]
		RADDX = 7,

		[Description("Radiation oncology unit")]
		RADO = 8,

		[Description("Neuroradiology unit")]
		RNEU = 9,

		[Description("Hospital")]
		HOSP = 10,

		[Description("Chronic Care Facility")]
		CHR = 11,

		[Description("Hospitals; General Acute Care Hospital")]
		GACH = 12,

		[Description("Military Hospital")]
		MHSP = 13,

		[Description("Psychatric Care Facility")]
		PSYCHF = 14,

		[Description("Rehabilitation hospital")]
		RH = 15,

		[Description("Addiction treatment center")]
		RHAT = 16,

		[Description("Intellectual impairment center")]
		RHII = 17,

		[Description("Parents with adjustment difficulties center")]
		RHMAD = 18,

		[Description("Physical impairment center")]
		RHPI = 19,

		[Description("Physical impairment - hearing center")]
		RHPIH = 20,

		[Description("Physical impairment - motor skills center")]
		RHPIMS = 21,

		[Description("Physical impairment - visual skills center")]
		RHPIVS = 22,

		[Description("Youths with adjustment difficulties center")]
		RHYAD = 23,

		[Description("Hospital unit")]
		HU = 24,

		[Description("Bone marrow transplant unit")]
		BMTU = 25,

		[Description("Coronary care unit")]
		CCU = 26,

		[Description("Chest unit")]
		CHEST = 27,

		[Description("Epilepsy unit")]
		EPIL = 28,

		[Description("Emergency room")]
		ER = 29,

		[Description("Emergency trauma unit")]
		ETU = 30,

		[Description("Hemodialysis unit")]
		HD = 31,

		[Description("Hospital laboratory")]
		HLAB = 32,

		[Description("Inpatient laboratory")]
		INLAB = 33,

		[Description("Outpatient laboratory")]
		OUTLAB = 34,

		[Description("Radiology unit")]
		HRAD = 35,

		[Description("Specimen collection site")]
		HUSCS = 36,

		[Description("Intensive care unit")]
		ICU = 37,

		[Description("Pediatric intensive care unit")]
		PEDICU = 38,

		[Description("Pediatric neonatal intensive care unit")]
		PEDNICU = 39,

		[Description("Inpatient pharmacy")]
		INPHARM = 40,

		[Description("Medical laboratory")]
		MBL = 41,

		[Description("Neurology critical care and stroke unit")]
		NCCS = 42,

		[Description("Neurosurgery unit")]
		NS = 43,

		[Description("Outpatient pharmacy")]
		OUTPHARM = 44,

		[Description("Pediatric unit")]
		PEDU = 45,

		[Description("Psychiatric hospital unit")]
		PHU = 46,

		[Description("Rehabilitation hospital unit")]
		RHU = 47,

		[Description("Sleep disorders unit")]
		SLEEP = 48,

		[Description("Nursing or custodial care facility")]
		NCCF = 49,

		[Description("Skilled nursing facility")]
		SNF = 50,

		[Description("Outpatient facility")]
		OF = 51,

		[Description("Allergy clinic")]
		ALL = 52,

		[Description("Amputee clinic")]
		AMPUT = 53,

		[Description("Bone marrow transplant clinic")]
		BMTC = 54,

		[Description("Breast clinic")]
		BREAST = 55,

		[Description("Child and adolescent neurology clinic")]
		CANC =56,

		[Description("Child and adolescent psychiatry clinic")]
		CAPC = 57,

		[Description("Ambulatory Health Care Facilities; Clinic/Center; Rehabilitation: Cardiac Facilities")]
		CARD = 58,

		[Description("Pediatric cardiology clinic")]
		PEDCARD = 59,

		[Description("Coagulation clinic")]
		COAG = 60,

		[Description("Colon and rectal surgery clinic")]
		CRS = 61,

		[Description("Dermatology clinic")]
		DERM = 62,

		[Description("Endocrinology clinic")]
		ENDO = 63,

		[Description("Pediatric endocrinology clinic")]
		PEDE = 64,

		[Description("Otorhinolaryngology clinic")]
		ENT = 65,

		[Description("Family medicine clinic")]
		FMC = 66,

		[Description("Gastroenterology clinic")]
		GI = 67,

		[Description("Pediatric gastroenterology clinic")]
		PEDGI = 68,

		[Description("General internal medicine clinic")]
		GIM = 69,

		[Description("Gynecology clinic")]
		GYN = 70,

		[Description("Hematology clinic")]
		HEM = 71,

		[Description("Pediatric hematology clinic")]
		PEDHEM = 72,

		[Description("Hypertension clinic")]
		HTN = 73,

		[Description("Impairment evaluation center")]
		IEC = 74,

		[Description("Infectious disease clinic")]
		INFD = 75,

		[Description("Pediatric infectious disease clinic")]
		PEDID = 76,

		[Description("Infertility clinic")]
		INV = 77,

		[Description("Lympedema clinic")]
		LYMPH = 78,

		[Description("Medical genetics clinic")]
		MGEN = 79,

		[Description("Nephrology clinic")]
		NEPH = 80,

		[Description("Pediatric nephrology clinic")]
		PEDNEPH = 81,

		[Description("Neurology clinic")]
		NEUR = 82,

		[Description("Obstetrics clinic")]
		OB = 83,

		[Description("Oral and maxillofacial surgery clinic")]
		OMS = 84,

		[Description("Medical oncology clinic")]
		ONCL = 85,

		[Description("Pediatric oncology clinic")]
		PEDHO = 86,

		[Description("Opthalmology clinic")]
		OPH = 87,

		[Description("Optometry clinic")]
		OPTC = 88,

		[Description("Orthopedics clinic")]
		ORTHO = 89,

		[Description("Hand clinic")]
		HAND = 90,

		[Description("Pain clinic")]
		PAINCL = 91,

		[Description("Primary care clinic")]
		PC = 92,

		[Description("Pediatrics clinic")]
		PEDC = 93,

		[Description("Pediatric rheumatology clinic")]
		PEDRHEUM = 94,

		[Description("Podiatry clinic")]
		POD = 95,

		[Description("Preventive medicine clinic")]
		PREV = 97,

		[Description("Proctology clinic")]
		PROCTO = 98,

		[Description("Provider's Office")]
		PROFF = 99,

		[Description("Prosthodontics clinic")]
		PROS = 100,

		[Description("Psychology clinic")]
		PSI = 101,

		[Description("Psychiatry clinic")]
		PSY = 102,

		[Description("Rheumatology clinic")]
		RHEUM = 103,

		[Description("Sports medicine clinic")]
		SPMED = 104,

		[Description("Surgery clinic")]
		SU = 105,

		[Description("Plastic surgery clinic")]
		PLS = 106,

		[Description("Urology clinic")]
		URO = 107,

		[Description("Transplant clinic")]
		TR = 108,

		[Description("Travel and geographic medicine clinic")]
		TRAVEL = 109,

		[Description("Wound clinic")]
		WND = 110,

		[Description("Residential treatment facility")]
		RTF = 111,

		[Description("Pain rehabilitation center")]
		PRC = 112,

		[Description("Substance use rehabilitation facility")]
		SURF = 113,

		[Description("Delivery Address")]
		DADDR = 114,

		[Description("Mobile Unit")]
		MOBL = 115,

		[Description("Ambulance")]
		AMB = 116,

		[Description("Pharmacy")]
		PHARM = 117,

		[Description("Accident site")]
		ACC = 118,

		[Description("Community Location")]
		COMM = 119,

		[Description("Community service center")]
		CSC = 120,

		[Description("Patient's Residence")]
		PTRES = 121,

		[Description("School")]
		SCHOOL = 122,

		[Description("Underage protection center")]
		UPC = 123,

		[Description("Work site")]
		WORK = 124,	   
	}
}
