using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Shesha.Domain.Attributes;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [Obsolete("This list will likely need to configured on a per client basis and should therefore be data driven. Once dependency from Ward Admissions module has been removed will need to Delete this from the project")]
    [ReferenceList("Fhir", "PracticeSettingCodeValueSets")]
    public enum RefListPracticeSettingCodeValueSets: long
    {

        /// <summary>
        /// 
        /// </summary>
        [Description("Adult mental illness")]
        adultMentalIllness = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anesthetics")]
        anesthetics = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Audiological medicine")]
        audiologicalMedicine = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood banking and transfusion medicine")]
        bloodBankingAndTransfusionMedicine = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Burns care")]
        burnsCare = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiology")]
        cardiology = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical cytogenetics and molecular genetics")]
        clinicalCytogeneticsAndMolecularGenetics = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical genetics")]
        clinicalGenetics = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical hematology")]
        clinicalHematology = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical immunology")]
        clinicalImmunology = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical microbiology")]
        clinicalMicrobiology = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical neuro-physiology")]
        clinicalNeuroPhysiology = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical oncology")]
        clinicalOncology = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical pharmacology")]
        clinicalPharmacology = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical physiology")]
        clinicalPhysiology = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community medicine")]
        communityMedicine = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Critical care medicine")]
        criticalCareMedicine = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental medicine specialties")]
        dentalMedicineSpecialties = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental-General dental practice")]
        dentalGeneralDentalPractice = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dermatology")]
        dermatology = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetic medicine")]
        diabeticMedicine = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dive medicine")]
        diveMedicine = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocrinology")]
        endocrinology = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family practice")]
        familyPractice = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastroenterology")]
        gastroenterology = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("General medical practice")]
        generalMedicalPractice = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("General medicine")]
        generalMedicine = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("General pathology")]
        generalMathology = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("General practice")]
        generalPractice = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Genito-urinary medicine")]
        genitoUrinaryMedicine = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Geriatric medicine")]
        geriatricMedicine = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gynecological oncology")]
        gynecologicaloncology = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gynecology")]
        gynecology = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hematopathology")]
        hematopathology = 34,

        /// <summary>
        /// /
        /// </summary>
        [Description("Hepatology")]
        hepatology = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("Histopathology")]
        histopathology = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("Immunopathology")]
        immunopathology = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infectious diseases")]
        infectiousDiseases = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("Internal medicine")]
        internalMedicine = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("Learning disability")]
        learningDisability = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical oncology")]
        medicalOncology = 41,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical ophthalmology")]
        medicalOphthalmology = 42,

        /// <summary>
        /// 
        /// </summary>
        [Description("Military medicine")]
        militaryMedicine = 43,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nephrology")]
        nephrology = 44,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neurology")]
        neurology = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neuropathology")]
        neuropathology = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nuclear medicine")]
        nuclearMedicine = 47,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obstetrics")]
        obstetrics = 48,

        /// <summary>
        /// /
        /// </summary>
        [Description("Obstetrics and gynecology")]
        obstetricsAndGynecology = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational medicine")]
        occupationalMedicine = 50,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmic surgery")]
        ophthalmicsurgery = 51,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmology")]
        ophthalmology = 52,

        /// <summary>
        /// 
        /// </summary>
        [Description("Osteopathic manipulative medicine")]
        osteopathicManipulativeMedicine = 53,

        /// <summary>
        /// 
        /// </summary>
        [Description("Otolaryngology")]
        otolaryngology = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pain management")]
        painManagement = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("Palliative medicine")]
        palliativeMedicine = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric (Child and adolescent) psychiatry")]
        pediatricPsychiatryChildAndAdolescent = 57,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric cardiology")]
        pediatricCardiology = 58,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric dentistry")]
        pediatricDentistry = 59,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric endocrinology")]
        pediatricEndocrinology = 60,

        /// <summary>
        /// /
        /// </summary>
        [Description("Pediatric gastroenterology")]
        pediatricGastroenterology = 61,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric genetics")]
        pediatricGenetics = 62,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric hematology")]
        pediatricHematology = 63,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric immunology")]
        pediatricImmunology = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric infectious diseases")]
        pediatricInfectiousDiseases = 65,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric nephrology")]
        pediatricNephrology = 66,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric oncology")]
        pediatricOncology = 67,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric ophthalmology")]
        pediatricOphthalmology = 68,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric pulmonology")]
        pediatricPulmonology = 69,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric rheumatology")]
        pediatricRheumatology = 70,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric surgery")]
        pediatricSurgery = 71,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pediatric surgery-bone marrow transplantation")]
        pediatricSurgeryBoneMarrowTransplantation = 72,

        /// <summary>
        /// 
        /// </summary>
        [Description("Preventive medicine")]
        preventiveMedicine = 73,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatry")]
        psychiatry = 74,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychotherapy")]
        psychotherapy = 75,

        /// <summary>
        /// 
        /// </summary>
        [Description("Public health medicine")]
        publichealthmedicine = 76,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pulmonary medicine")]
        pulmonaryMedicine = 77,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiation oncology")]
        radiationOncology = 78,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiology")]
        radiology = 79,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiology-Interventional radiology")]
        radiologyInterventionalRadiology = 80,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rehabilitation")]
        rehabilitation = 81,

        /// <summary>
        ///
        /// </summary>
        [Description("Respite care")]
        respiteCare = 82,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rheumatology")]
        rheumatology = 83,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sleep studies")]
        sleepStudies = 84,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Bone and marrow transplantation")]
        surgeryBoneAndMarrowTransplantation = 85,

        /// <summary>
        /// /
        /// </summary>
        [Description("Surgery-Breast surgery")]
        surgeryBreastSurgery = 86,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Cardiac surgery")]
        surgeryCardiacSurgery = 87,

        /// <summary>
        /// /
        /// </summary>
        [Description("Surgery-Cardiothoracic transplantation")]
        surgeryCardiothoracicTransplantation = 88,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Colorectal surgery")]
        surgeryColorectalSurgery = 89,

        /// <summary>
        /// /
        /// </summary>
        [Description("Surgery-Dental-Endodontics")]
        surgeryDentalEndodontics = 90,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dental-Oral and maxillofacial surgery")]
        surgeryDentalOralAndMaxillofacialSurgery = 91,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dental-Oral surgery")]
        surgeryDentalOralSurgery = 92,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dental-Orthodontics")]
        surgeryDentalOrthodontics = 93,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dental-Periodontal surgery")]
        surgeryDentalPeriodontalSurgery = 94,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dental-Prosthetic dentistry (Prosthodontics)")]
        surgeryDentalProstheticDentistry = 95,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dental-surgical-Prosthodontics")]
        surgeryDentalSurgicalProsthodontics = 96,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dentistry-Restorative dentistry")]
        surgeryDentistryRestorativeDentistry = 97,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dentistry--surgical")]
        surgeryDentistrySurgical = 98,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dentistry-surgical-Orthodontics")]
        surgeryDentistrySurgicalOrthodontics = 99,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Dermatologic surgery")]
        surgeryDermatologicSurgery = 100,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Ear, nose and throat surgery")]
        surgeryEarNoseAndThroatSurgery = 101,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-general")]
        surgeryGeneral = 102,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Hepatobiliary and pancreatic surgery")]
        surgeryHepatobiliaryAndPancreaticSurgery = 103,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Neurosurgery")]
        surgeryNeurosurgery = 104,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Plastic surgery")]
        surgeryPlasticSurgery = 105,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Transplantation surgery")]
        surgeryTransplantationsurgery = 106,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Trauma and orthopedics")]
        surgeryTraumaAndOrthopedics = 107,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery-Vascular")]
        surgeryVascular = 108,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgical oncology")]
        surgicalOncology = 109,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgical-Accident & emergency")]
        surgicalAccidentAndEmergency = 110,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thoracic medicine")]
        thoracicMedicine = 111,

        /// <summary>
        /// 
        /// </summary>
        [Description("Toxicology")]
        toxicology = 112,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tropical medicine")]
        tropicalMedicine = 113,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urological oncology")]
        urologicalOncology = 114,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urology")]
        urology = 115,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical specialty--OTHER--NOT LISTED")]
        medicalSpecialtyOtherNotListed = 116,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgical specialty--OTHER-NOT LISTED")]
        surgicalSpecialityOtherNotListed = 117

    }
}
