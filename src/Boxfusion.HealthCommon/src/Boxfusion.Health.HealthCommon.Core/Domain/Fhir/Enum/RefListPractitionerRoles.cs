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
    [ReferenceList("Fhir", "PractitionerRoles")]
    public enum RefListPractitionerRoles : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Doctor")]
        doctor = 1,

        /// <summary>
        /// /
        /// </summary>
        [Description("Nurse")]
        nurse = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmacist")]
        pharmacist = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Researcher")]
        researcher = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Teacher/educator")]
        teacher = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("ICT professional")]
        ict = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Specialized surgeon")]
        specializedSurgeon = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiation therapist")]
        radiationTherapist = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chiropractor")]
        chiropractor = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental assistant")]
        dentalAssistant = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("NA - Nursing auxiliary")]
        nursingAuxiliary = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialized nurse")]
        specializedNurse = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital administrator")]
        hospitalAdministrator = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plastic surgeon")]
        plasticSurgeon = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neuropathologist")]
        neuropathologist = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nephrologist")]
        nephrologist = 16,

        /// <summary>
        /// /
        /// </summary>
        [Description("Obstetrician")]
        obstetrician = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("School dental assistant")]
        schoolDentalAssistant = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical microbiologist")]
        medicalMicrobiologist = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiologist")]
        cardiologist = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dermatologist")]
        dermatologist = 21,

        /// <summary>
        /// /
        /// </summary>
        [Description("Laboratory hematologist")]
        laboratoryHematologist = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gerodontist")]
        gerodontist = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Removable prosthodontist")]
        removableProsthodontist = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialized dentist")]
        specializedDentist = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neuropsychiatrist")]
        neuropsychiatrist = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical assistant")]
        medicalAssistant = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Orthopedic surgeon	")]
        orthopedicSurgeon = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Thoracic surgeon	")]
        thoracicSurgeon = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Community health physician	")]
        communityHealthPhysician = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical medicine specialist")]
        physicalMedicineSpecialist = 31,

        /// <summary>
        /// /
        /// </summary>
        [Description("Urologist")]
        urologist = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Electroencephalography specialist")]
        electroencephalographySpecialist = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental hygienist")]
        dentalHygienist = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("Public health nurse")]
        publicHealthNurse = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("Optometrist")]
        optometrist = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neonatologist")]
        neonatologist = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chemical pathologist")]
        chemicalPathologist = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("PT - Physiotherapist")]
        physiotherapist = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("Periodontist")]
        periodontist = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthodontist")]
        orthodontist = 41,

        /// <summary>
        /// /
        /// </summary>
        [Description("Internal medicine specialist")]
        internalMedicineSpecialist = 42,

        /// <summary>
        /// /
        /// </summary>
        [Description("Dietitian (general)")]
        dietitianGeneral = 43,

        /// <summary>
        /// /
        /// </summary>
        [Description("Hematologist")]
        hematologist = 44,

        /// <summary>
        /// /
        /// </summary>
        [Description("Interpreter")]
        interpreter = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("Respiratory physician")]
        respiratoryPhysician = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical X-ray technician")]
        medicalXrayTechnician = 47,

        /// <summary>
        /// /
        /// </summary>
        [Description("Occupational health nurse	")]
        occupationalHealthNurse = 48,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmaceutical assistant")]
        pharmaceuticalAssistant = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("Masseur")]
        masseur = 50,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rheumatologist")]
        rheumatologist = 51,

        /// <summary>
        /// /
        /// </summary>
        [Description("Neurosurgeon")]
        neurosurgeon = 52,

        /// <summary>
        /// /
        /// </summary>
        [Description("Sanitarian")]
        sanitarian = 53,

        /// <summary>
        /// /
        /// </summary>
        [Description("Pharmacist")]
        Pharmacist = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Philologist	")]
        philologist = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Dispensing optometrist	")]
        dispensingOptometrist = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("Maxillofacial surgeon")]
        maxillofacialSurgeon = 57,

        /// <summary>
        /// /
        /// </summary>
        [Description("Endodontist")]
        endodontist = 58,

        /// <summary>
        /// 
        /// </summary>
        [Description("Faith healer")]
        faithHealer = 59,

        [Description("Neurologist")]
        neurologist = 60,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community physician")]
        communityPhysician = 61,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical record administrator")]
        medicalRecordAdministrator = 62,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiovascular surgeon")]
        cardiovascularSurgeon = 63,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fixed prosthodontist")]
        fixedProsthodontist = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("General physician")]
        generalPhysician = 65,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthopedic technician")]
        orthopedicTechnician = 66,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychologist")]
        psychologist = 67,

        /// <summary>
        /// /
        /// </summary>
        [Description("Community-based dietitian")]
        communityBasedDietitian = 68,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical pathologist")]
        medicalPathologist = 69,

        /// <summary>
        /// 
        /// </summary>
        [Description("Laboratory medicine specialist")]
        laboratoryMedicineSpecialist = 70,

        /// <summary>
        /// 
        /// </summary>
        [Description("Otorhinolaryngologist")]
        otorhinolaryngologist = 71,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocrinologist")]
        endocrinologist = 72,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family medicine specialist")]
        familyMedicineSpecialist = 73,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical immunologist")]
        clinicalImmunologist = 74,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oral pathologist")]
        oralPathologist = 75,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiologist")]
        radiologist = 76,

        /// <summary>
        /// 
        /// </summary>
        [Description("Public health dentist")]
        publicHealthDentist = 77,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Prosthodontist	")]
        prosthodontist = 78,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Specialized physician	")]
        specializedPhysician = 79,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Gastroenterologist	")]
        gastroenterologist = 80,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing aid")]
        nursingAid = 81,

        /// <summary>
        /// 
        /// </summary>
        [Description("	MW - Midwife")]
        midwife = 82,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Practical aid (pharmacy)")]
        practicalAidPharmacy = 83,

        /// <summary>
        /// 
        /// </summary>
        [Description("Osteopath")]
        osteopath = 84,

        /// <summary>
        /// /
        /// </summary>
        [Description("Infectious diseases physician")]
        infectiousDiseasesPhysician = 85,

        /// <summary>
        /// /
        /// </summary>
        [Description("General surgeon")]
        generalSurgeon = 86,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diagnostic radiologist")]
        diagnosticRadiologist = 87,

        /// <summary>
        /// 
        /// </summary>
        [Description("Auxiliary midwife")]
        auxiliaryMidwife = 88,

        /// <summary>
        /// 
        /// </summary>
        [Description("Translator")]
        translator = 89,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational therapist")]
        occupationalTherapist = 90,

        /// <summary>
        ///
        /// </summary>
        [Description("Psychiatrist")]
        psychiatrist = 91,

        /// <summary>
        /// /
        /// </summary>
        [Description("Nuclear medicine physician")]
        nuclearMedicinePhysician = 92,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical pathologist")]
        clinicalPathologist = 93,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatrician")]
        pediatrician = 94,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other professional nurse")]
        otherProfessionalnurse = 95,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anatomic pathologist")]
        anatomicpathologist = 96,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gynecologist")]
        gynecologist = 97,

        /// <summary>
        /// 
        /// </summary>
        [Description("	General pathologist	")]
        generalpathologist = 98,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anesthesiologist")]
        anesthesiologist = 99,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other dietitians and public health nutritionists")]
        otherDietitiansAndPublicHealthNutritionists = 100,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Pediatric dentist	")]
        pediatricDentist = 101,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Care of the elderly physician	")]
        careOfTheElderlyPhysician = 102,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental surgeon")]
        dentalSurgeon = 103,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dietician AND/OR public health nutritionist")]
        dieticianAndOrPublicHealthNutritionist = 104,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse")]
        Nurse = 105,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing personnel")]
        nursingPersonnel = 106,

        /// <summary>
        /// 
        /// </summary>
        [Description("Midwifery personnel")]
        midwiferyPersonnel = 107,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physiotherapist AND/OR occupational therapist")]
        physiotherapistAndOroccupationalTherapist = 108,

        /// <summary>
        /// 
        /// </summary>
        [Description("Philologist, translator AND/OR interpreter")]
        philologistTranslatorAndOrInterpreter = 109,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Medical doctor	")]
        medicalDoctor = 110,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical practitioner")]
        medicalPractitioner = 111,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical administrator - national")]
        medicalAdministratorNational = 112,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consultant physician")]
        consultantPhysician = 113,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consultant surgeon")]
        consultantSurgeon = 114,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consultant gynecology and obstetrics")]
        consultantGynecologyAndObstetrics = 115,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anesthetist")]
        anesthetist = 116,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital registrar")]
        hospitalRegistrar = 117,

        /// <summary>
        /// 
        /// </summary>
        [Description("House officer")]
        houseOfficer = 118,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational physician")]
        occupationalPhysician = 119,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical medical officer")]
        clinicalMedicalOfficer = 120,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Medical practitioner - teaching	")]
        medicalPractitionerTeaching = 121,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental administrator")]
        dentalAdministrator = 122,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental consultant")]
        dentalConsultant = 123,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental general practitioner")]
        dentalGeneralPractitioner = 124,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Dental practitioner - teaching	")]
        dentalPractitionerTeaching = 125,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Nurse administrator - national	")]
        nurseAdministratorNational = 126,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing officer - region")]
        nursingOfficerRegion = 127,

        /// <summary>
        /// /
        /// </summary>
        [Description("	Nursing officer - district	")]
        nursingOfficerDistrict = 128,

        /// <summary>
        /// /
        /// </summary>
        [Description("Nursing administrator - professional body")]
        nursingAdministratorProfessionalBody = 129,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing officer - division")]
        nursingOfficerDivision = 130,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse education director")]
        nurseEducationDirector = 131,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational health nursing officer")]
        occupationalHealthNursingOfficer = 132,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing officer")]
        nursingOfficer = 133,

        /// <summary>
        /// 
        /// </summary>
        [Description("Midwifery sister")]
        midwiferySister = 134,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing sister (theatre)")]
        nursingSisterTheatre = 135,

        /// <summary>
        /// 
        /// </summary>
        [Description("Staff nurse")]
        staffNurse = 136,

        /// <summary>
        /// 
        /// </summary>
        [Description("Staff midwife")]
        staffMidwife = 137,

        /// <summary>
        /// 
        /// </summary>
        [Description("State enrolled nurse")]
        stateEnrolledNurse = 138,

        /// <summary>
        /// 
        /// </summary>
        [Description("District nurse")]
        districtNurse = 139,

        /// <summary>
        /// 
        /// </summary>
        [Description("Private nurse")]
        privateNurse = 140,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community midwife")]
        communityMidwife = 141,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinic nurse")]
        clinicNurse = 142,

        /// <summary>
        /// 
        /// </summary>
        [Description("Practice nurse")]
        practiceNurse = 143,

        /// <summary>
        /// 
        /// </summary>
        [Description("School nurse")]
        schoolNurse = 144,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse - teaching")]
        nurseTeaching = 145,

        /// <summary>
        /// 
        /// </summary>
        [Description("Student nurse")]
        studentNurse = 146,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental nurse")]
        dentalNurse = 147,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community pediatric nurse")]
        communityPediatricNurse = 148,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hospital pharmacist")]
        hospitalPharmacist = 149,

        /// <summary>
        /// 
        /// </summary>
        [Description("Retail pharmacist")]
        retailPharmacist = 150,

        /// <summary>
        /// 
        /// </summary>
        [Description("Industrial pharmacist")]
        industrialPharmacist = 151,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmaceutical officer H.A.")]
        pharmaceuticalOfficerHA = 152,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trainee pharmacist")]
        traineePharmacist = 153,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical radiographer")]
        medicalRadiographer = 154,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Diagnostic radiographer	")]
        diagnosticRadiographer = 155,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Therapeutic radiographer	")]
        therapeuticRadiographer = 156,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trainee radiographer")]
        traineeRadiographer = 157,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmic optician")]
        ophthalmicOptician = 158,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trainee optician")]
        traineeOptician = 159,

        /// <summary>
        /// 
        /// </summary>
        [Description("Remedial gymnast")]
        remedialGymnast = 160,

        /// <summary>
        /// 
        /// </summary>
        [Description("Speech and language therapist")]
        speechAndLanguageTherapist = 161,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthoptist")]
        orthoptist = 162,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trainee remedial therapist")]
        traineeRemedialTherapist = 163,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dietician")]
        dietician = 164,

        /// <summary>
        /// 
        /// </summary>
        [Description("Podiatrist")]
        podiatrist = 165,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental auxiliary")]
        dentalAuxiliary = 166,

        /// <summary>
        /// 
        /// </summary>
        [Description("	 technician")]
        ecgTechnician = 167,

        /// <summary>
        /// 
        /// </summary>
        [Description("EEG technician")]
        eegTechnician = 168,

        /// <summary>
        /// 
        /// </summary>
        [Description("Artificial limb fitter")]
        artificialLimbFitter = 169,

        /// <summary>
        /// 
        /// </summary>
        [Description("AT - Audiology technician")]
        audiologyTechnician = 170,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmacy technician")]
        pharmacyTechnician = 171,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trainee medical technician")]
        traineeMedicalTechnician = 172,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Geneticist	")]
        geneticist = 173,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgical corset fitter")]
        surgicalCorsetFitter = 174,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental technician")]
        dentalTechnician = 175,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical assistant")]
        clinicalAssistant = 176,

        /// <summary>
        /// 
        /// </summary>
        [Description("Senior registrar")]
        seniorRegistrar = 177,

        /// <summary>
        /// 
        /// </summary>
        [Description("Registrar")]
        registrar = 178,

        /// <summary>
        /// 
        /// </summary>
        [Description("Senior house officer")]
        seniorHouseOfficer = 179,

        /// <summary>
        /// 
        /// </summary>
        [Description("MO - Medical officer")]
        medicalOfficer = 180,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health visitor, nurse/midwife")]
        healthVisitorNurseOrMidwife = 181,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Registered nurse	")]
        registeredNurse = 182,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Midwifery tutor	")]
        midwiferyTutor = 183,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Accident and Emergency nurse	")]
        accidentAndEmergencyNurse = 184,

        /// <summary>
        /// 
        /// </summary>
        [Description("Triage nurse")]
        triageNurse = 185,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community nurse")]
        communityNurse = 186,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing continence advisor")]
        nursingContinenceAdvisor = 187,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coronary care nurse	")]
        coronaryCareNurse = 188,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetic nurse")]
        diabeticNurse = 189,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family planning nurse")]
        familyPlanningNurse = 190,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Care of the elderly nurse")]
        careOfTheElderlyNurse = 191,

        /// <summary>
        /// 
        /// </summary>
        [Description("ICN - Infection control nurse")]
        infectionControlNurse = 192,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intensive therapy nurse")]
        intensiveTherapyNurse = 193,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Learning disabilities nurse	")]
        learningDisabilitiesNurse = 194,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Neonatal nurse	")]
        neonatalNurse = 195,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Neurology nurse	")]
        neurologyNurse = 196,

        /// <summary>
        /// 
        /// </summary>
        [Description("Industrial nurse")]
        industrialNurse = 197,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oncology nurse")]
        oncologyNurse = 198,

        /// <summary>
        /// 
        /// </summary>
        [Description("Macmillan nurse")]
        macmillanNurse = 199,

        /// <summary>
        /// 
        /// </summary>
        [Description("Marie Curie nurse")]
        marieCurieNurse = 200,


        /// <summary>
        /// 
        /// </summary>
        [Description("Pain control nurse")]
        painControlNurse = 201,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Palliative care nurse")]
        palliativeCareNurse = 202,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chemotherapy nurse")]
        chemotherapyNurse = 203,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiotherapy nurse")]
        radiotherapyNurse = 204,

        /// <summary>
        /// 
        /// </summary>
        [Description("	PACU nurse	")]
        pacuNurse = 205,


        /// <summary>
        /// 
        /// </summary>
        [Description("Stomatherapist")]
        stomatherapist = 206,

        /// <summary>
        /// 
        /// </summary>
        [Description("Theatre nurse")]
        theatreNurse = 207,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric nurse")]
        pediatricNurse = 208,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric nurse")]
        psychiatricNurse = 209,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community mental health nurse")]
        communityMentalHealthNurse = 210,

        /// <summary>
        /// 
        /// </summary>
        [Description("Renal nurse	")]
        renalNurse = 211,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hemodialysis nurse")]
        hemodialysisNurse = 212,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound care nurse")]
        woundCareNurse = 213,

        /// <summary>
        /// 
        /// </summary>
        [Description(" Nurse grade ")]
        nurseGrade = 214,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical nurse specialist")]
        clinicalNurseSpecialist = 215,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Nurse practitioner	")]
        nursePractitioner = 216,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Nursing sister	")]
        nursingSister = 217,

        /// <summary>
        /// 
        /// </summary>
        [Description("	CN - Charge nurse	")]
        chargeNurse = 218,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ward manager")]
        wardManager = 219,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing team leader")]
        nursingTeamLeader = 220,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing assistant")]
        nursingAssistant = 221,

        /// <summary>
        /// 
        /// </summary>
        [Description("Healthcare assistant")]
        healthcareAssistant = 222,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursery nurse")]
        nurseryNurse = 223,

        /// <summary>
        /// 
        /// </summary>
        [Description("Healthcare service manager")]
        healthcareServiceManager = 224,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational health service manager")]
        occupationalHealthServiceManager = 225,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community nurse manager")]
        communityNurseManager = 226,

        /// <summary>
        /// 
        /// </summary>
        [Description("Behavior therapist")]
        behaviorTherapist = 227,

        /// <summary>
        /// 
        /// </summary>
        [Description("Behavior therapy assistant")]
        behaviorTherapyAssistant = 228,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drama therapist")]
        dramaTherapist = 229,

        /// <summary>
        /// 
        /// </summary>
        [Description("Domiciliary occupational therapist")]
        domiciliaryOccupationalTherapist = 230,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational therapy helper")]
        occupationalTherapyHelper = 231,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychotherapist")]
        psychotherapist = 232,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community-based physiotherapist")]
        communityBasedPhysiotherapist = 233,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Play therapist	")]
        playTherapist = 234,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Play specialist	")]
        playSpecialist = 235,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Play leader	")]
        playLeader = 236,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community-based speech/language therapist")]
        communityBasedSpeechLanguageTherapist = 237,

        /// <summary>
        /// 
        /// </summary>
        [Description("Speech/language assistant")]
        speechLanguageAssistant = 238,

        /// <summary>
        /// 
        /// </summary>
        [Description("Professional counselor")]
        professionalCounselor = 239,

        /// <summary>
        /// 
        /// </summary>
        [Description("Marriage guidance counselor")]
        marriageGuidanceCounselor = 240,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trained nurse counselor")]
        trainedNurseCounselor = 241,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Trained social worker counselor	")]
        trainedSocialWorkerCounselor = 242,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Trained personnel counselor	")]
        trainedPersonnelCounselor = 243,

        /// <summary>
        /// 
        /// </summary>
        [Description(" Psychoanalyst ")]
        psychoanalyst = 244,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assistant psychologist")]
        assistantPsychologist = 245,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community-based podiatrist")]
        communityBasedPodiatrist = 246,

        /// <summary>
        /// 
        /// </summary>
        [Description("Foot care worker")]
        footCareWorker = 247,

        /// <summary>
        /// 
        /// </summary>
        [Description("Audiometrician")]
        audiometrician = 248,

        /// <summary>
        /// 
        /// </summary>
        [Description("Audiometrist")]
        audiometrist = 249,

        /// <summary>
        /// 
        /// </summary>
        [Description("Technical healthcare occupation")]
        technicalHealthcareOccupation = 250,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational therapy technical instructor")]
        occupationalTherapyTechnicalInstructor = 251,

        /// <summary>
        /// 
        /// </summary>
        [Description("Administrative healthcare staff")]
        administrativeHealthcareStaff = 252,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Complementary health worker	")]
        complementaryHealthWorker = 253,

        /// <summary>
        /// 
        /// </summary>
        [Description("Supporting services personnel")]
        supportingServicePersonnel = 254,

        /// <summary>
        /// 
        /// </summary>
        [Description("Research associate")]
        researchAssociate = 255,

        /// <summary>
        /// /
        /// </summary>
        [Description("Research nurse")]
        researchNurse = 256,

        /// <summary>
        /// 
        /// </summary>
        [Description("Human aid to communication")]
        humanAidToCommunication = 257,

        /// <summary>
        /// 
        /// </summary>
        [Description("Palantypist")]
        palantypist = 258,

        /// <summary>
        /// 
        /// </summary>
        [Description("Note taker")]
        noteTaker = 259,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cuer")]
        cuer = 260,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lipspeaker")]
        lipspeaker = 261,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interpreter for British sign language")]
        interpreterForBritishSignLanguage = 262,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interpreter for Signs supporting English")]
        interpreterForSignsSupportingEnglish = 263,

        /// <summary>
        /// 
        /// </summary>
        [Description("General practitioner locum")]
        generalPractitionerLocum = 264,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lactation consultant ")]
        lactationConsultant = 265,

        /// <summary>
        /// 
        /// </summary>
        [Description("Midwife counselor")]
        midwifeCounselor = 266,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing occupation")]
        nursingOccupation = 267,

        /// <summary>
        /// /
        /// </summary>
        [Description("Medical/dental technicians")]
        medicalDentalTechnicians = 268,

        /// <summary>
        /// 
        /// </summary>
        [Description("Parkinson disease nurse")]
        parkinsonDiseaseNurse = 269,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Specialist registrar	")]
        specialistRegistrar = 270,

        /// <summary>
        /// 
        /// </summary>
        [Description("Member of mental health review tribunal")]
        memberOfMentalHealthReviewTribunal = 271,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital manager")]
        hospitalManager = 272,

        /// <summary>
        /// 
        /// </summary>
        [Description("Responsible medical officer	")]
        responsibleMedicalOfficer = 273,

        /// <summary>
        /// 
        /// </summary>
        [Description("Independent doctor")]
        independentDoctor = 274,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bereavement counselor")]
        bereavementCounselor = 275,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgeon")]
        surgeon = 276,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical technician")]
        medicalTechnician = 277,

        /// <summary>
        /// 
        /// </summary>
        [Description("Remedial therapist")]
        remedialTherapist = 278,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accident and Emergency doctor")]
        accidentAndEmergencyDoctor = 279,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Clinical oncologist	")]
        clinicalOncologist = 280,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Family planning doctor	")]
        familyPlanningDoctor = 281,

        /// <summary>
        /// 
        /// </summary>
        [Description("Associate general practitioner")]
        associateGeneralPractitioner = 282,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Partner of general practitioner	")]
        partnerOfGeneralPractitioner = 283,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assistant GP")]
        assistantGP = 284,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deputizing general practitioner")]
        deputizingGeneralPractitioner = 285,

        /// <summary>
        /// 
        /// </summary>
        [Description("	General practitioner registrar")]
        generalPractitionerRegistrar = 286,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ambulatory pediatrician")]
        ambulatoryPediatrician = 287,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community pediatrician")]
        communityPediatrician = 288,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric cardiologist")]
        pediatricCardiologist = 289,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric endocrinologist")]
        pediatricEndocrinologist = 290,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric gastroenterologist")]
        pediatricGastroenterologist = 291,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric nephrologist")]
        pediatricNephrologist = 292,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric neurologist")]
        pediatricNeurologist = 293,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric rheumatologist")]
        pediatricRheumatologist = 294,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric oncologist")]
        pediatricOncologist = 295,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pain management specialist")]
        painManagementSpecialist = 296,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intensive care specialist")]
        intensiveCareSpecialist = 297,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adult intensive care specialist")]
        adultIntensiveCareSpecialist = 298,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric intensive care specialist")]
        pediatricIntensiveCareSpecialist = 299,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood transfusion doctor")]
        bloodTransfusionDoctor = 300,

        /// <summary>
        /// 
        /// </summary>
        [Description("Histopathologist")]
        histopathologist = 301,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physician")]
        physician = 302,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chest physician")]
        chestPhysician = 303,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thoracic physician")]
        thoracicPhysician = 304,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical hematologist")]
        clinicalHematologist = 305,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical neurophysiologist")]
        clinicalNeurophysiologist = 306,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical physiologist")]
        clinicalPhysiologist = 307,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetologist")]
        diabetologist = 308,

        /// <summary>
        /// 
        /// </summary>
        [Description("Andrologist")]
        andrologist = 309,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neuroendocrinologist")]
        neuroendocrinologist = 310,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reproductive endocrinologist")]
        reproductiveEndocrinologist = 311,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thyroidologist")]
        thyroidologist = 312,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Clinical geneticist	")]
        clinicalGeneticist = 313,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Clinical cytogeneticist	")]
        clinicalCytogeneticist = 314,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Clinical molecular geneticist	")]
        clinicalMolecularGeneticist = 315,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Genitourinary medicine physician	")]
        genitourinaryMedicinePhysician = 316,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Palliative care physician	")]
        palliativeCarePhysician = 317,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Rehabilitation physician	")]
        rehabilitationPhysician = 318,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Child and adolescent psychiatrist	")]
        childAndAdolescentPsychiatrist = 319,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Forensic psychiatrist	")]
        forensicPsychiatrist = 320,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Liaison psychiatrist	")]
        liaisonPsychiatrist = 321,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Psychogeriatrician	")]
        psychogeriatrician = 322,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatrist for mental handicap")]
        psychiatristForMentalHandicap = 323,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Rehabilitation psychiatrist	")]
        rehabilitationPsychiatrist = 324,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Obstetrician and gynecologist")]
        obstetricianAndGynecologist = 325,

        /// <summary>
        /// 
        /// </summary>
        [Description("Breast surgeon")]
        breastSurgeon = 326,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiothoracic surgeon")]
        cardiothoracicSurgeon = 327,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac surgeon")]
        cardiacSurgeon = 328,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ear, nose and throat surgeon")]
        earNoseAndThroatSurgeon = 329,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocrine surgeon")]
        endocrineSurgeon = 330,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thyroid surgeon")]
        thyroidSurgeon = 331,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pituitary surgeon")]
        pituitarySurgeon = 332,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Gastrointestinal surgeon")]
        gastrointestinalSurgeon = 333,

        /// <summary>
        /// 
        /// </summary>
        [Description("	General gastrointestinal surgeon")]
        generalGastrointestinalSurgeon = 334,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Upper gastrointestinal surgeon	")]
        upperGastrointestinalSurgeon = 335,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Colorectal surgeon	")]
        colorectalSurgeon = 336,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hand surgeon	")]
        handSurgeon = 337,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hepatobiliary surgeon")]
        hepatobiliarySurgeon = 338,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmic surgeon")]
        ophthalmicSurgeon = 339,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric surgeon")]
        pediatricSurgeon = 340,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pancreatic surgeon")]
        pancreaticSurgeon = 341,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transplant surgeon")]
        transplantSurgeon = 342,

         /// <summary>
         /// 
         /// </summary>
        [Description("Trauma surgeon")]
        traumaSurgeon = 343,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vascular surgeon")]
        vascularSurgeon = 344,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical practitioner grade")]
        medicalPractitionerGrade = 345,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital consultant")]
        hospitalConsultant = 346,

        /// <summary>
        /// 
        /// </summary>
        [Description("Visiting specialist registrar")]
        visitingSpecialistRegistrar = 347,

        /// <summary>
        /// 
        /// </summary>
        [Description("Research registrar")]
        researchRegistrar = 348,

        /// <summary>
        /// 
        /// </summary>
        [Description("General practitioner grade")]
        generalPractitionerGrade = 349,

        /// <summary>
        /// 
        /// </summary>
        [Description("General practitioner principal")]
        generalPractitionerPrincipal = 350,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hospital specialist	")]
        hospitalSpecialist = 351,

        /// <summary>
        /// 
        /// </summary>
        [Description("Associate specialist")]
        associateSpecialist = 352,

        /// <summary>
        /// 
        /// </summary>
        [Description("Research fellow")]
        researchFellow = 353,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Allied health professional	")]
        alliedhealthProfessional = 354,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hospital dietitian	")]
        hospitalDietitian = 355,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Domiciliary physiotherapist	")]
        domiciliaryPhysiotherapist = 356,

        /// <summary>
        /// 
        /// </summary>
        [Description("General practitioner-based physiotherapist")]
        generalPractitionerBasedPhysiotherapist = 357,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital-based physiotherapist")]
        hospitalBasedPhysiotherapist = 358,

        /// <summary>
        /// 
        /// </summary>
        [Description("Private physiotherapist")]
        privatePhysiotherapist = 359,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Physiotherapy assistant	")]
        physiotherapyAssistant = 360,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital-based speech and language therapist")]
        hospitalBasedSpeechAndLanguageTherapist = 361,

        /// <summary>
        /// 
        /// </summary>
        [Description("Arts therapist")]
        artsTherapist = 362,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dance therapist")]
        danceTherapist = 363,

        /// <summary>
        /// 
        /// </summary>
        [Description("Music therapist")]
        musicTherapist = 364,

        /// <summary>
        /// 
        /// </summary>
        [Description("Renal dietitian")]
        renalDietitian = 365,

        /// <summary>
        /// 
        /// </summary>
        [Description("Liver dietitian")]
        liverDietitian = 366,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oncology dietitian")]
        oncologyDietitian = 367,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric dietitian")]
        pediatricDietitian = 368,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetes dietitian")]
        diabetesDietitian = 369,

        /// <summary>
        /// 
        /// </summary>
        [Description("Audiologist")]
        audiologist = 370,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hearing therapist	")]
        hearingTherapist = 371,

        /// <summary>
        /// 
        /// </summary>
        [Description("Audiological scientist	")]
        audiologicalScientist = 372,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hearing aid dispenser")]
        hearingAidDispenser = 373,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community-based occupational therapist")]
        communityBasedOccupationalTherapist = 374,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hospital occupational therapist	")]
        hospitalOccupationalTherapist = 375,

        /// <summary>
        /// 
        /// </summary>
        [Description("Social services occupational therapist")]
        socialServicesOccupationalTherapist = 376,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthotist")]
        orthotist = 377,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgical fitter	")]
        surgicalFitter = 378,

        /// <summary>
        /// /
        /// </summary>
        [Description("Hospital-based podiatrist")]
        hospitalBasedPodiatrist = 379,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Podiatry assistant	")]
        podiatryAssistant = 380,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphedema nurse")]
        lymphedemaNurse = 381,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Community learning disabilities nurse	")]
        communityLearningDisabilitiesNurse = 382,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Clinical nurse teacher	")]
        clinicalNurseTeacher = 383,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community practice nurse teacher")]
        communityPracticeNurseTeacher = 384,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse tutor")]
        nurseTutor = 385,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse teacher practitioner")]
        nurseTeacherPractitioner = 386,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse lecturer practitioner")]
        nurseLecturerPractitioner = 387,

        /// <summary>
        /// 
        /// </summary>
        [Description("Outreach nurse")]
        outreachNurse = 388,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anesthetic nurse")]
        anestheticNurse = 389,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse manager")]
        nurseManager = 390,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse administrator")]
        nurseAdministrator = 391,

        /// <summary>
        /// 
        /// </summary>
        [Description("Midwifery grade")]
        midwiferyGrade = 392,

        /// <summary>
        /// 
        /// </summary>
        [Description("Midwife")]
        Midwife = 393,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Student midwife	")]
        studentMidwife = 394,

        /// <summary>
        /// 
        /// </summary>
        [Description("Parentcraft sister")]
        parentcraftSister = 395,

        /// <summary>
        /// 
        /// </summary>
        [Description("Healthcare professional grade")]
        healthcareProfessionalGrade = 396,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Restorative dentist	")]
        restorativeDentist = 397,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Pediatric audiologist	")]
        pediatricAudiologist = 398,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Immunopathologist	")]
        immunopathologist = 399,

        /// <summary>
        /// /
        /// </summary>
        [Description("Audiological physician")]
        audiologicalPhysician = 400,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical pharmacologist")]
        clinicalPharmacologist = 401,

        /// <summary>
        /// 
        /// </summary>
        [Description("Private doctor")]
        privateDoctor = 402,

        /// <summary>
        /// 
        /// </summary>
        [Description("Agency nurse")]
        agencyNurse = 403,

        /// <summary>
        /// 
        /// </summary>
        [Description("Behavioral therapist nurse")]
        behavioralTherapistNurse = 404,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac rehabilitation nurse")]
        cardiacRehabilitationNurse = 405,

        /// <summary>
        /// 
        /// </summary>
        [Description("Genitourinary nurse")]
        genitourinaryNurse = 406,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rheumatology nurse specialist")]
        rheumatologyNurseSpecialist = 407,

        /// <summary>
        /// 
        /// </summary>
        [Description("Continence nurse")]
        continenceNurse = 408,

        /// <summary>
        /// 
        /// </summary>
        [Description("Contact tracing nurse")]
        contactTracingNurse = 409,

        /// <summary>
        /// 
        /// </summary>
        [Description("	General nurse	")]
        generalNurse = 410,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse for the mentally handicapped")]
        nurseForTheMentallyHandicapped = 411,

        /// <summary>
        /// 
        /// </summary>
        [Description("Liaison nurse")]
        liaisonNurse = 412,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetic liaison nurse")]
        diabeticLiaisonNurse = 413,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse psychotherapist")]
        nursePsychotherapist = 414,

        /// <summary>
        /// 
        /// </summary>
        [Description("Company nurse")]
        companyNurse = 415,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital midwife")]
        hospitalMidwife = 416,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Genetic counselor")]
        geneticCounselor = 417,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Mental health counselor	")]
        mentalHealthCounselor = 418,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical psychologist")]
        clinicalPsychologist = 419,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Educational psychologist")]
        educationalPsychologist = 420,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coroner")]
        coroner = 421,

        /// <summary>
        /// 
        /// </summary>
        [Description("Appliance officer")]
        applianceOfficer = 422,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical oncologist")]
        medicalOncologist = 423,

        /// <summary>
        /// 
        /// </summary>
        [Description("School medical officer")]
        schoolMedicalOfficer = 424,

        /// <summary>
        /// 
        /// </summary>
        [Description("Integrated midwife")]
        integratedMidwife = 425,

        /// <summary>
        /// 
        /// </summary>
        [Description("RN First Assist")]
        rnFirstAssist = 426,

        /// <summary>
        /// 
        /// </summary>
        [Description("Optician")]
        optician = 427,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical secretary")]
        medicalSecretary = 428,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital nurse")]
        hospitalNurse = 429,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consultant anesthetist")]
        consultantAnesthetist = 430,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paramedic")]
        paramedic = 431,

        /// <summary>
        /// 
        /// </summary>
        [Description("Staff grade obstetrician")]
        staffGradeObstetrician = 432,

        /// <summary>
        /// 
        /// </summary>
        [Description("Staff grade practitioner")]
        staffGradePractitioner = 433,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical student ")]
        medicalStudent = 434,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Acting obstetric registrar	")]
        actingObstetricRegistrar = 435,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physiotherapist technical instructor ")]
        physiotherapisTechnicalInstructor = 436,

        /// <summary>
        /// 
        /// </summary>
        [Description("Resident physician")]
        residentPhysician = 437,

        /// <summary>
        /// 
        /// </summary>
        [Description("Certified registered nurse anesthetist")]
        certifiedRegisteredNurseAnesthetist = 438,

        /// <summary>
        /// 
        /// </summary>
        [Description("Attending physician")]
        attendingPhysician = 439,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assigned practitioner")]
        assignedPractitioner = 440,

        /// <summary>
        /// 
        /// </summary>
        [Description("Professional initiating surgical case")]
        professionalInitiatingSurgicalCase = 441,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Professional providing staff relief during surgical procedure")]
        professionalProvidingStaffReliefDuringSurgicalProcedure = 442,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Consultant pediatrician	")]
        consultantPediatrician = 443,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consultant neonatologist")]
        consultantNeonatologist = 444,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health educator")]
        healthEducator = 445,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Certified health education specialist")]
        certifiedHealthEducationSpecialist = 446,

        /// <summary>
        /// 
        /// </summary>
        [Description("Circulating nurse")]
        circulatingNurse = 447,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Perioperative nurse	")]
        perioperativeNurse = 448,

        /// <summary>
        /// 
        /// </summary>
        [Description("Scrub nurse	")]
        scrubNurse = 449,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fellow of American Academy of Osteopathy")]
        fellowOfAmericanAcademyOfOsteopathy = 450,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oculoplastic surgeon")]
        oculoplasticSurgeon = 451,

        /// <summary>
        /// 
        /// </summary>
        [Description("Retinal surgeon")]
        retinalSurgeon = 452,

        /// <summary>
        /// 
        /// </summary>
        [Description("Admitting physician")]
        admittingPhysician = 453,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical ophthalmologist")]
        medicalOphthalmologist = 454,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmologist")]
        ophthalmologist = 455,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health coach")]
        healthCoach = 456,

        /// <summary>
        /// 
        /// </summary>
        [Description("Respiratory therapist")]
        respiratoryTherapist = 457,

        /// <summary>
        /// 
        /// </summary>
        [Description("Podiatric surgeon")]
        podiatricSurgeon = 458,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hypnotherapist")]
        hypnotherapist = 459,

        /// <summary>
        /// 
        /// </summary>
        [Description("Asthma nurse specialist")]
        asthmaNurseSpecialist = 460,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse case manager")]
        nurseCaseManager = 461,

        /// <summary>
        /// 
        /// </summary>
        [Description("	PCP - Primary care physician")]
        primaryCarePhysician = 462,

        /// <summary>
        /// 
        /// </summary>
        [Description("Addiction medicine specialist")]
        addictionMedicineSpecialist = 463,

        /// <summary>
        /// 
        /// </summary>
        [Description("	PA - physician assistant")]
        physicianAssistant = 464,

        /// <summary>
        /// 
        /// </summary>
        [Description("Government midwife")]
        governmentMidwife = 465,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse complex case manager")]
        nurseComplexCaseManager = 466,

        /// <summary>
        /// 
        /// </summary>
        [Description("Naturopath")]
        naturopath = 467,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prosthetist")]
        prosthetist = 468,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hip and knee surgeon")]
        hipAndKneeSurgeon = 469,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hepatologist")]
        hepatologist = 470,

        /// <summary>
        /// 
        /// </summary>
        [Description("Shoulder surgeon")]
        shoulderSurgeon = 471,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interventional radiologist")]
        interventionalRadiologist = 472,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric radiologist")]
        pediatricRadiologist = 473,

        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency medicine specialist")]
        emergencyMedicineSpecialist = 474,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Family medicine specialist - palliative care")]
        familyMedicineSpecialistPalliativeCare = 475,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Surgical oncologist	")]
        surgicalOncologist = 476,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Acupuncturist	")]
        acupuncturist = 477,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Pediatric orthopedic surgeon	")]
        pediatricOrthopedicSurgeon = 478,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric hematologist")]
        pediatricHematologist = 479,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neuroradiologist")]
        neuroradiologist = 480,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family medicine specialist - anesthetist")]
        familyMedicineSpecialistAnesthetist = 481,

        /// <summary>
        /// 
        /// </summary>
        [Description("Doula")]
        doula = 482,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Traditional herbal medicine specialist	")]
        traditionalHerbalMedicineSpecialist = 483,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational medicine specialist ")]
        occupationalMedicineSpecialist = 484,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Pediatric emergency medicine specialist	")]
        pediatricEmergencyMedicineSpecialist = 485,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family medicine specialist - care of the elderly")]
        familyMedicineSpecialistCareOfTheElderly = 486,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Travel medicine specialist	")]
        travelMedicineSpecialist = 487,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Spine surgeon	")]
        spineSurgeon = 488,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Maternal or fetal medicine specialist	")]
        maternalOrFetalMedicineSpecialist = 489,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Massage therapist	")]
        massageTherapist = 490,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Hospitalist	")]
        hospitalist = 491,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sports medicine specialist")]
        sportsMedicineSpecialist = 492,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric respirologist")]
        pediatricRespirologist = 493,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Homeopath	")]
        homeopath = 494,

        /// <summary>
        /// 
        /// </summary>
        [Description("	Family medicine specialist - emergency medicine	")]
        familyMedicineSpecialistEmergencyMedicine = 495,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric hematologist or oncologist")]
        pediatricHematologistOrOncologist = 496,

        /// <summary>
        /// 
        /// </summary>
        [Description("Foot and ankle surgeon")]
        footAndAnkleSurgeon = 497,

        /// <summary>
        /// 
        /// </summary>
        [Description("Invasive cardiologist")]
        invasiveCardiologist = 498,

        /// <summary>
        /// 
        /// </summary>
        [Description("Case manager")]
        caseManager = 499,

        /// <summary>
        /// 
        /// </summary>
        [Description("Kinesthesiologist")]
        kinesthesiologist = 500,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical Associate")]
        clinicalAssociate = 501,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical Associate")]
        adminClerk = 502,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Health Worker")]
        chw = 503,
    }
}
