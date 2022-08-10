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
    [ReferenceList("Fhir", "ServiceTypes")]
    public enum RefListServiceTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Adoption/Permanent Care Info/Support")]
        adoptionPermanentCareInfoSupport = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Care Assessment")]
        agedCareAssessment = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Care Information/Referral")]
        agedCareInformationReferral = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Residential Care")]
        agedResidentialCare = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Case Management for Older Persons")]
        caseManagementForOlderPersons = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Delivered Meals (Meals On Wheels)")]
        deliveredMeals = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Friendly Visiting")]
        friendlyVisiting = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Care/Housekeeping Assistance")]
        homeCareHousekeepingAssistance = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Maintenance and Repair")]
        homeMaintenanceAndRepair = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Personal Alarms/Alerts")]
        personalAlarmsAlerts = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Personal Care for Older Persons")]
        personalCareForOlderPersons = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Planned Activity Groups")]
        plannedActivityGroups = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Acupuncture")]
        acupuncture = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Alexander Technique Therapy")]
        alexanderTechniqueTherapy = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aromatherapy")]
        aromatherapy = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biorhythm Services")]
        biorhythmServices = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bowen Therapy")]
        bowenTherapy = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chinese Herbal Medicine")]
        chineseHerbalMedicine = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("Feldenkrais")]
        feldenkrais = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Homoeopathy")]
        homoeopathy = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hydrotherapy")]
        hydrotherapy = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hypnotherapy")]
        hypnotherapy = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Kinesiology")]
        kinesiology = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Magnetic Therapy")]
        magneticTherapy = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Massage Therapy")]
        massageTherapy = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("Meditation")]
        meditation = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Myotherapy")]
        myotherapy = 27,

        /// <summary>
        /// /
        /// </summary>
        [Description("Naturopathy")]
        naturopathy = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reflexology")]
        reflexology = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reiki")]
        reiki = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Relaxation Therapy")]
        relaxationTherapy = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("Shiatsu")]
        shiatsu = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Western Herbal Medicine")]
        westernHerbalMedicine = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Day care")]
        familyDayCare = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("Holiday Programs")]
        holidayPrograms = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("Kindergarten Inclusion Support")]
        kindergartenInclusionSupport = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("Kindergarten/Preschool")]
        kindergartenPreschool = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("Long Day Child Care")]
        longDayChildCare = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occasional Child Care")]
        occasionalChildCare = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("Outside School Hours Care")]
        outsideSchoolHoursCare = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("Children's Play Programs")]
        childrensPlayPrograms = 41,

        /// <summary>
        /// 
        /// </summary>
        [Description("Parenting/Family Support/Education")]
        parentingFamilySupportEducation = 42,

        /// <summary>
        /// 
        /// </summary>
        [Description("Playgroup")]
        playgroup = 43,

        /// <summary>
        /// 
        /// </summary>
        [Description("School Nursing")]
        schoolNursing = 44,

        /// <summary>
        /// 
        /// </summary>
        [Description("Toy Library")]
        toyLibrary = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child Protection/Child Abuse Report")]
        childProtectionChilAbuseReport = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("Foster Care")]
        fosterCare = 47,

        /// <summary>
        /// 
        /// </summary>
        [Description("Residential/Out-of-Home Care")]
        residentialOutOfHomeCare = 48,

        /// <summary>
        /// 
        /// </summary>
        [Description("Support - Young People Leaving Care")]
        supportYoungPeopleLeavingCare = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("Audiology")]
        audiology = 50,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood Donation")]
        bloodDonation = 51,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chiropractic")]
        chiropractic = 52,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dietetics")]
        dietetics = 53,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Planning")]
        familyPlanning = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health Advocacy/Liaison Service")]
        healthAdvocacyLiaisonService = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health Information/Referral")]
        healthInformationReferral = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("Immunization")]
        immunization = 57,

        /// <summary>
        /// 
        /// </summary>
        [Description("Maternal & Child Health")]
        maternalAndChildHealth = 58,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing")]
        nursing = 59,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nutrition")]
        nutrition = 60,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational Therapy")]
        occupationalTherapy = 61,

        /// <summary>
        /// 
        /// </summary>
        [Description("Optometry")]
        optometry = 62,

        /// <summary>
        /// 
        /// </summary>
        [Description("Osteopathy")]
        osteopathy = 63,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmacy")]
        pharmacy = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physiotherapy")]
        physiotherapy = 65,

        /// <summary>
        /// 
        /// </summary>
        [Description("Podiatry")]
        podiatry = 66,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sexual Health")]
        sexualHealth = 67,

        /// <summary>
        /// 
        /// </summary>
        [Description("Speech Pathology/Therapy")]
        speechPathologyTherapy = 68,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bereavement Counselling")]
        bereavementCounselling = 69,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis Counselling")]
        crisisCounselling = 70,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Counselling/Therapy")]
        familyCounsellingTherapy = 71,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Violence Counselling")]
        familyViolenceCounselling = 72,

        /// <summary>
        /// 
        /// </summary>
        [Description("Financial Counselling")]
        financialCounselling = 73,

        /// <summary>
        /// 
        /// </summary>
        [Description("Generalist Counselling")]
        generalistCounselling = 74,

        /// <summary>
        /// 
        /// </summary>
        [Description("Genetic Counselling")]
        geneticCounselling = 75,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health Counselling")]
        healthCounselling = 76,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mediation")]
        mediation = 77,

        /// <summary>
        /// 
        /// </summary>
        [Description("Problem Gambling Counselling")]
        problemGamblingCounselling = 78,

        /// <summary>
        /// 
        /// </summary>
        [Description("Relationship Counselling")]
        relationshipCounselling = 79,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sexual Assault Counselling")]
        sexualAssaultCounselling = 80,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trauma Counselling")]
        traumaCounselling = 81,

        /// <summary>
        /// 
        /// </summary>
        [Description("Victims of Crime Counselling")]
        victimsOfCrimeCounselling = 82,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cemetery Operation")]
        cemeteryOperation = 83,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cremation")]
        cremation = 84,

        /// <summary>
        /// 
        /// </summary>
        [Description("Death Service Information")]
        deathServiceInformation = 85,

        /// <summary>
        /// 
        /// </summary>
        [Description("Funeral Services")]
        funeralServices = 86,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endodontic")]
        endodontic = 87,

        /// <summary>
        /// 
        /// </summary>
        [Description("General Dental")]
        generalDental = 88,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oral Medicine")]
        oralMedicine = 89,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oral Surgery")]
        oralSurgery = 90,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthodontic")]
        orthodontic = 91,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Dentistry")]
        paediatricDentistry = 92,

        /// <summary>
        /// 
        /// </summary>
        [Description("Periodontic")]
        periodontic = 93,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prosthodontic")]
        prosthodontic = 94,

        /// <summary>
        /// 
        /// </summary>
        [Description("Acquired Brain Injury Info/Referral")]
        acquiredBrainInjuryInfoReferral = 95,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Advocacy")]
        disabilityAdvocacy = 96,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Aids & Equipment")]
        disabilityAidsAndEquipment = 97,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Case Management")]
        disabilityCaseManagement = 98,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Day Programs/Activities")]
        disabilityDayProgramsOrActivities = 99,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Information/Referral")]
        disabilityinformationReferral = 100,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Support Packages")]
        disabilitySupportPackages = 101,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Supported Accommodation")]
        disabilitySupportedAccommodation = 102,

        /// <summary>
        /// 
        /// </summary>
        [Description("Early Childhood Intervention")]
        earlyChildhoodIntervention = 103,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hearing Aids & Equipment")]
        hearingaidsAndEquipment = 104,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drug and/or Alcohol Counselling")]
        drugAndOrAlcoholCounselling = 105,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drug/Alcohol Information/Referral")]
        drugAlcoholInformationReferral = 106,

        /// <summary>
        /// 
        /// </summary>
        [Description("Needle & Syringe Exchange")]
        needleAndSyringExchange = 107,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-resid. Alcohol/Drug Treatment")]
        nonResidAlcoholdrugTreatment = 108,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmacotherapy")]
        pharmacotherapy = 109,

        /// <summary>
        /// 
        /// </summary>
        [Description("Quit Program")]
        quitProgram = 110,

        /// <summary>
        /// 
        /// </summary>
        [Description("Residential Alcohol/Drug Treatment")]
        residentialAlcoholDrugTreatment = 111,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adult/Community Education")]
        adultCommunityEducation = 112,

        /// <summary>
        /// 
        /// </summary>
        [Description("Higher Education")]
        higherEducation = 113,

        /// <summary>
        /// 
        /// </summary>
        [Description("Primary Education")]
        primaryEducation = 114,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secondary Education")]
        secondaryEducation = 115,

        /// <summary>
        /// 
        /// </summary>
        [Description("Training & Vocational Education")]
        trainingAndVocationalEducation = 116,

        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency Medical")]
        emergencymedical = 117,

        /// <summary>
        /// 
        /// </summary>
        [Description("Employment Placement and/or Support")]
        employmentPlacementAndOrSupport = 118,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vocational Rehabilitation")]
        vocationalRehabilitation = 119,

        /// <summary>
        /// 
        /// </summary>
        [Description("Work Safety/Accident Prevention")]
        workSafetyAccidentPrevention = 120,

        /// <summary>
        /// 
        /// </summary>
        [Description("Financial Assistance")]
        financialAssistance = 121,

        /// <summary>
        /// 
        /// </summary>
        [Description("Financial Information/Advice")]
        financialInformationAdvice = 122,

        /// <summary>
        /// 
        /// </summary>
        [Description("Material Aid")]
        materialAid = 123,

        /// <summary>
        /// 
        /// </summary>
        [Description("General Practice")]
        generalPractice = 124,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accommodation Placement/Support")]
        accommodationPlacementSupport = 125,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis/Emergency Accommodation")]
        crisisEmergencyAccommodation = 126,

        /// <summary>
        /// 
        /// </summary>
        [Description("Homelessness Support")]
        homelessnessSupport = 127,

        /// <summary>
        /// 
        /// </summary>
        [Description("Housing Information/Referral")]
        housingInformationReferral = 128,

        /// <summary>
        /// 
        /// </summary>
        [Description("Public Rental Housing")]
        publicRentalHousing = 129,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interpreting/Multilingual Service")]
        interpretingMultilingualService = 130,

        /// <summary>
        /// 
        /// </summary>
        [Description("Juvenile Justice")]
        juvenileJustice = 131,

        /// <summary>
        /// 
        /// </summary>
        [Description("Legal Advocacy")]
        legalAdvocacy = 132,

        /// <summary>
        /// 
        /// </summary>
        [Description("Legal Information/Advice/Referral")]
        legalInformationAdviceReferral = 133,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health Advocacy")]
        mentalHealthAdvocacy = 134,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health Assess/Triage/Crisis Response")]
        mentalHealthAssessTriageCrisisResponse = 135,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health Case Management")]
        mentalHealthCaseManagement = 136,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health Information/Referral")]
        mentalHealthInformationReferral = 137,

        /// <summary>
        /// /
        /// </summary>
        [Description(" Mental Health Inpatient Services")]
        mentalHealthInpatientServices = 138,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health Non-residential Rehab")]
        mentalHealthNonResidentialRehab = 139,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health Residential Rehab/CCU")]
        mentalHealthResidentialRehabCCU = 140,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatry (Requires Referral)")]
        psychiatryRequiresReferral = 141,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychology")]
        psychology = 142,

        /// <summary>
        /// 
        /// </summary>
        [Description("Martial Arts")]
        martialArts = 143,

        /// <summary>
        /// 
        /// </summary>
        [Description("Personal Fitness Training")]
        personalFitnessTraining = 144,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical Activity Group")]
        physicalActivityGroup = 145,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical Activity Programs")]
        physicalActivityPrograms = 146,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical Fitness Testing ")]
        physicalFitnessTesting = 147,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pilates")]
        pilates = 148,

        /// <summary>
        /// 
        /// </summary>
        [Description("Self-Defence")]
        selfDefence = 149,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sporting Club")]
        sportingClub = 150,

        /// <summary>
        /// 
        /// </summary>
        [Description("Yoga")]
        yoga = 151,

        /// <summary>
        /// 
        /// </summary>
        [Description("Food Safety")]
        foodSafety = 152,

        /// <summary>
        /// 
        /// </summary>
        [Description("Health Regulatory /Inspection /Cert.")]
        healthRegulatoryInspectionCert = 153,

        /// <summary>
        /// 
        /// </summary>
        [Description("Work Health/Safety Inspection/Cert.")]
        workHealthSafetyInspectionCert = 154 ,

        /// <summary>
        /// 
        /// </summary>
        [Description("Carer Support")]
        carerSupport = 155,

        /// <summary>
        /// 
        /// </summary>
        [Description("Respite Care")]
        respiteCare = 156,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anatomical Pathology")]
        anatomicalPathology = 157,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pathology - Clinical Chemistry")]
        pathologyClinicalChemistry = 158,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pathology - General")]
        pathologyGeneral = 159,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pathology - Genetics")]
        pathologyGenetics = 160,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pathology - Haematology")]
        pathologyHaematology = 161,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pathology - Immunology")]
        pathologyImmunology = 162,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pathology - Microbiology")]
        pathologyMicrobiology = 163,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anaesthesiology - Pain Medicine")]
        anaesthesiologyPainMedicine = 164,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiology")]
        cardiology = 165,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical Genetics")]
        clinicalGenetics = 166,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical Pharmacology")]
        clinicalPharmacology = 167,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dermatology")]
        dermatology = 168,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocrinology")]
        endocrinology = 169,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastroenterology & Hepatology")]
        gastroenterologyAndHepatology = 170,

        /// <summary>
        /// 
        /// </summary>
        [Description("Geriatric Medicine")]
        geriatricMedicine = 171,

        /// <summary>
        /// 
        /// </summary>
        [Description("Immunology & Allergy")]
        immunologyAndAllergy = 172,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infectious Diseases")]
        infectiousDiseases = 173,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intensive Care Medicine")]
        intensiveCareMedicine = 174,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical Oncology")]
        medicalOncology = 175,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nephrology")]
        nephrology = 176,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neurology")]
        neurology = 177,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational Medicine")]
        occupationalMedicine = 178,

        /// <summary>
        /// 
        /// </summary>
        [Description("Palliative Medicine")]
        palliativeMedicine = 179,

        /// <summary>
        /// 
        /// </summary>
        [Description("Public Health Medicine")]
        publicHealthMedicine = 180,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rehabilitation Medicine")]
        rehabilitationMedicine = 181,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rheumatology")]
        rheumatology = 182,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sleep Medicine")]
        sleepMedicine = 183,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thoracic Medicine")]
        thoracicMedicine = 184,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gynaecological Oncology")]
        gynaecologicalOncology = 185,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obstetrics & Gynaecology")]
        obstetricsAndGynaecology = 186,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reproductive Endocrinology/Infertility")]
        reproductiveEndocrinologyInfertility = 187,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urogynaecology")]
        urogynaecology = 188,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neonatology & Perinatology")]
        neonatologyAndPerinatology = 189,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Cardiology")]
        paediatricCardiology = 190,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Clinical Genetics")]
        paediatricClinicalGenetics = 191,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Clinical Pharmacology")]
        paediatricClinicalPharmacology = 192,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Endocrinology")]
        paediatricEndocrinology = 193,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paed. Gastroenterology/Hepatology")]
        paedGastroenterologyHepatology = 194,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Haematology")]
        paediatricHaematology = 195,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Immunology & Allergy")]
        paediatricImmunologyAndAllergy = 196,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Infectious Diseases")]
        paediatricInfectiousDiseases = 197,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Intensive Care Medicine")]
        paediatricIntensiveCareMedicine = 198,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Medical Oncology")]
        paediatricMedicalOncology = 199,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Medicine")]
        paediatricMedicine = 200,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Nephrology")]
        paediatricNephrology = 201,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Neurology")]
        paediatricNeurology = 202,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Nuclear Medicine")]
        paediatricNuclearMedicine = 203,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Rehabilitation Medicine")]
        paediatricRehabilitationMedicine = 204,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Rheumatology")]
        paediatricRheumatology = 205,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Sleep Medicine")]
        paediatricSleepMedicine = 206,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Surgery")]
        paediatricSurgery = 207,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Thoracic Medicine")]
        paediatricThoracicMedicine = 208,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diag. Radiology /Xray /CT /Fluoroscopy")]
        diagRadiologyXrayCTfluoroscopy = 209,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diagnostic Ultrasound")]
        diagnosticUltrasound = 210,

        /// <summary>
        /// 
        /// </summary>
        [Description("Magnetic Resonance Imaging (MRI)")]
        magneticResonanceImaging = 211 ,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nuclear Medicine")]
        nuclearMedicine = 212,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obstetric/Gynaecological Ultrasound")]
        obstetricGynaecologicalUltrasound = 213,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radiation Oncology")]
        radiationOncology = 214,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiothoracic Surgery")]
        cardiothoracicSurgery = 215,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neurosurgery")]
        neurosurgery = 216,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmology")]
        ophthalmology = 217,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthopaedic Surgery")]
        orthopaedicSurgery = 218,

        /// <summary>
        /// 
        /// </summary>
        [Description("Otolaryngology/Head & Neck Surgery")]
        otolaryngologyHeadAndNeckSurgery = 219,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plastic & Reconstructive Surgery")]
        plasticAndReconstructiveSurgery = 220,

        /// <summary>
        /// 
        /// </summary>
        [Description("Surgery - General")]
        surgeryGeneral = 221,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urology")]
        urology = 222,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vascular Surgery")]
        vascularSurgery = 223,

        /// <summary>
        /// 
        /// </summary>
        [Description("Support Groups")]
        supportGroups = 224,

        /// <summary>
        /// 
        /// </summary>
        [Description("Air ambulance")]
        airAmbulance = 225,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ambulance")]
        ambulance = 226,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood Transport")]
        bloodtransport = 227,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Bus")]
        communitybus = 228,

        /// <summary>
        /// 
        /// </summary>
        [Description("Flying Doctor Service")]
        flyingDoctorService = 229,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient Transport")]
        patientTransport = 230,

        /// <summary>
        /// 
        /// </summary>
        [Description("A&E")]
        AE = 231,

        /// <summary>
        /// 
        /// </summary>
        [Description("A&EP")]
        AEP = 232,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abuse")]
        abuse = 233,

        /// <summary>
        /// 
        /// </summary>
        [Description("ACAS")]
        acas = 234,

        /// <summary>
        /// 
        /// </summary>
        [Description("Access")]
        access = 235,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accident")]
        accident = 236,

        /// <summary>
        /// /
        /// </summary>
        [Description("Acute Inpatient Serv")]
        acuteInpatientServ = 237,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adult Day Programs")]
        adultDayPrograms = 238,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adult Mental Health Services")]
        adultMentalHealthServices = 239,

        /// <summary>
        /// 
        /// </summary>
        [Description("Advice")]
        advice = 240,

        /// <summary>
        /// 
        /// </summary>
        [Description("Advocacy")]
        advocacy = 241,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Persons Mental")]
        agedPersonsMental = 242,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Persons Mental")]
        AgedPersonsMental = 243,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Persons Mental")]
        agedPersonMental = 244,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aids")]
        aids = 245,

        /// <summary>
        /// 
        /// </summary>
        [Description("Al-Anon")]
        alAnon = 246,

        /// <summary>
        /// 
        /// </summary>
        [Description("Alcohol")]
        alcohol = 247,

        /// <summary>
        /// 
        /// </summary>
        [Description("Al-Teen")]
        alTeen = 248,

        /// <summary>
        /// 
        /// </summary>
        [Description("Antenatal")]
        antenatal = 249,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anxiety")]
        anxiety = 250,

        /// <summary>
        /// 
        /// </summary>
        [Description("Arthritis")]
        arthritis = 251,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assessment")]
        assessment = 252,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assistance")]
        assistance = 253,

        /// <summary>
        /// /
        /// </summary>
        [Description("Asthma")]
        asthma = 254,

        /// <summary>
        /// 
        /// </summary>
        [Description("ATSS")]
        atss = 255,

        /// <summary>
        /// 
        /// </summary>
        [Description("Attendant Care")]
        attendantCare = 256,

        /// <summary>
        /// 
        /// </summary>
        [Description("Babies")]
        babies = 257,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bathroom Modification")]
        bathroomModification = 258,

        /// <summary>
        /// 
        /// </summary>
        [Description("Behavior")]
        behavior = 259,

        /// <summary>
        /// 
        /// </summary>
        [Description("Behavior Interventi")]
        behaviorInterventi = 260,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bereavement")]
        bereavement = 261,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bipolar")]
        bipolar = 262,

        /// <summary>
        /// 
        /// </summary>
        [Description("Birth")]
        birth = 263,

        /// <summary>
        /// 
        /// </summary>
        [Description("Birth Control")]
        birthControl = 264,

        /// <summary>
        /// 
        /// </summary>
        [Description("Birthing Options")]
        birthingOptions = 265,

        /// <summary>
        /// 
        /// </summary>
        [Description("BIST")]
        bist = 266,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood")]
        blood = 267,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone")]
        bone = 268,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bowel")]
        bowel = 269,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brain")]
        brain = 270,

        /// <summary>
        /// 
        /// </summary>
        [Description("Breast Feeding")]
        breastFeeding = 271,

        /// <summary>
        /// 
        /// </summary>
        [Description("Breast Screen")]
        breastScreen = 272,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brokerage")]
        brokerage = 273,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cancer")]
        cancer = 274,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cancer Support")]
        cancerSupport = 275,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiovascular Disease")]
        cardiovascularDisease = 276,

        /// <summary>
        /// 
        /// </summary>
        [Description("Care Packages")]
        carePackages = 277,

        /// <summary>
        /// 
        /// </summary>
        [Description("Carer")]
        carer = 278,

        /// <summary>
        /// 
        /// </summary>
        [Description("Case Management")]
        caseManagement = 279,

        /// <summary>
        /// 
        /// </summary>
        [Description("Casualty")]
        casualty = 280,

        /// <summary>
        /// 
        /// </summary>
        [Description("Centrelink")]
        centrelink = 281,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chemists")]
        chemists = 282,

        /// <summary>
        /// /
        /// </summary>
        [Description("Child And Adolescent")]
        childAndAdolescent = 283,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child Care")]
        childCare = 284,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child Services")]
        childServices = 285,

        /// <summary>
        /// 
        /// </summary>
        [Description("Children")]
        children = 286,

        /// <summary>
        /// 
        /// </summary>
        [Description("Children's Services")]
        childrensServices =	287,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cholesterol")]
        cholesterol = 288,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clothing")]
        clothing = 289,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Based Acco")]
        communitybasedacco = 290,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Care Unit")]
        communityCareUnit = 291,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Child And Adolescent Mental Health Services")]
        communityChildAndAdolescentMentalHealthServices = 292,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Health")]
        communityHealth = 293,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Residentia")]
        communityResidentia = 294,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Transport")]
        communityTransport = 295,

        /// <summary>
        /// 
        /// </summary>
        [Description("Companion Visiting")]
        companionVisiting = 296,

        /// <summary>
        /// 
        /// </summary>
        [Description("Companionship")]
        companionship = 297,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consumer Advice")]
        consumerAdvice = 298,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consumer Issues")]
        consumerIssues = 299,

        /// <summary>
        /// 
        /// </summary>
        [Description("Continuing Care Serv")]
        continuingCareServ = 300,

        /// <summary>
        /// 
        /// </summary>
        [Description("Contraception Inform")]
        contraceptionInform = 301,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coordinating Bodies")]
        coordinatingBodies = 302,

        /// <summary>
        /// 
        /// </summary>
        [Description("Correctional Service")]
        correctionaService = 303,

        /// <summary>
        /// 
        /// </summary>
        [Description("Council Environmenta")]
        councilEnvironmenta = 304,

        /// <summary>
        /// 
        /// </summary>
        [Description("Counselling")]
        counselling = 305,

        /// <summary>
        /// 
        /// </summary>
        [Description("Criminal")]
        criminal = 306,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crises")]
        crises = 307,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis Assessment And Treatment Services")]
        crisisAssessmentAndTreatmentServices = 308,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis Assistance")]
        crisisAssistance = 309,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis Refuge")]
        crisisRefuge = 310,

        /// <summary>
        /// 
        /// </summary>
        [Description("Day Program")]
        dayProgram = 311,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deaf")]
        deaf = 312,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental Hygiene")]
        dentalHygiene = 313,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dentistry")]
        dentistry = 314,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dentures")]
        dentures = 315,

        /// <summary>
        /// 
        /// </summary>
        [Description("Depression")]
        depression = 316,

        /// <summary>
        /// 
        /// </summary>
        [Description("Detoxification")]
        detoxification = 317,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetes")]
        diabetes = 318,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diaphragm Fitting")]
        diaphragmFitting = 319,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dieticians")]
        dieticians = 320,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disabled Parking")]
        disabledParking = 321,

        /// <summary>
        /// 
        /// </summary>
        [Description("District Nursing")]
        districtNursing = 322,

        /// <summary>
        /// 
        /// </summary>
        [Description("Divorce")]
        divorce = 323,

        /// <summary>
        /// 
        /// </summary>
        [Description("Doctors")]
        doctors = 324,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drink-Drive")]
        drinkDrive = 325,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dual Diagnosis Services")]
        dualDiagnosisServices = 326,

        /// <summary>
        /// 
        /// </summary>
        [Description("Early Choice")]
        earlyChoice = 327,

        /// <summary>
        /// 
        /// </summary>
        [Description("Eating Disorder")]
        eatingDisorder = 328,

        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency Relief")]
        emergencyRelief = 329,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Employment And Training")]
        employmentAndTraining = 330,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environment")]
        environment = 331,

        /// <summary>
        /// 
        /// </summary>
        [Description("Equipment")]
        equipment = 332,

        /// <summary>
        /// 
        /// </summary>
        [Description("Exercise")]
        exercise = 333,

        /// <summary>
        /// 
        /// </summary>
        [Description("Facility")]
        facility = 334,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Choice")]
        familyChoice = 335,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Law")]
        familyLaw = 336,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Options")]
        familyOptions = 337,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Services")]
        familyServices = 338,

        /// <summary>
        /// 
        /// </summary>
        [Description("FFYA")]
        ffya = 339,

        /// <summary>
        /// 
        /// </summary>
        [Description("Financial Aid")]
        financialAid = 340,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fitness")]
        fitness = 341,

        /// <summary>
        /// 
        /// </summary>
        [Description("Flexible Care Packag")]
        flexibleCarePackag = 342,

        /// <summary>
        /// 
        /// </summary>
        [Description("Food")]
        food = 343,

        /// <summary>
        /// 
        /// </summary>
        [Description("Food Vouchers")]
        foodVouchers = 344,

        /// <summary>
        /// 
        /// </summary>
        [Description("Forensic Mental Heal")]
        forensicMentalHeal = 345,

        /// <summary>
        /// 
        /// </summary>
        [Description("Futures")]
        futures = 346,

        /// <summary>
        /// 
        /// </summary>
        [Description("Futures For Young Ad")]
        futuresForYoungAd = 347,

        /// <summary>
        /// 
        /// </summary>
        [Description("General Practitioner")]
        generalPractitioner = 348,

        /// <summary>
        /// 
        /// </summary>
        [Description("Grants")]
        grants = 349,

        /// <summary>
        /// 
        /// </summary>
        [Description("Grief")]
        grief = 350,

        /// <summary>
        /// 
        /// </summary>
        [Description("Grief Counselling")]
        griefCounselling = 351,

        /// <summary>
        /// 
        /// </summary>
        [Description("HACC")]
        hacc = 352,

        /// <summary>
        /// 
        /// </summary>
        [Description("Heart Disease")]
        heartDisease = 353,

        /// <summary>
        /// 
        /// </summary>
        [Description("Help")]
        help = 354,

        /// <summary>
        /// 
        /// </summary>
        [Description("High Blood Pressure")]
        highBloodPressure = 355,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Help")]
        homeHelp = 356,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Nursing")]
        homeNursing = 357,

        /// <summary>
        /// 
        /// </summary>
        [Description("Homefirst")]
        homefirst = 358,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospice Care")]
        hospiceCare = 359,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital Services")]
        hospitalServices = 360,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital To Home")]
        hospitalToHome = 361,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hostel")]
        hostel = 362,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hostel Accommodation")]
        hostelAccommodation = 363,

        /// <summary>
        /// 
        /// </summary>
        [Description("Household Items")]
        householdItems = 364,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hypertension")]
        hypertension = 365,

        /// <summary>
        /// 
        /// </summary>
        [Description("Illness")]
        illness = 366,

        /// <summary>
        /// 
        /// </summary>
        [Description("Independent Living")]
        independentLiving = 367,

        /// <summary>
        /// 
        /// </summary>
        [Description("Information")]
        information = 368,

        /// <summary>
        /// 
        /// </summary>
        [Description("Injury")]
        injury = 369,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intake")]
        intake = 370,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intensive Mobile Youth Outreach Services")]
        intensiveMobileYou = 371,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervention")]
        intervention = 372,

        /// <summary>
        /// 
        /// </summary>
        [Description("Job Searching")]
        jobSearching = 373,

        /// <summary>
        /// 
        /// </summary>
        [Description("Justice")]
        justice = 374,

        /// <summary>
        /// 
        /// </summary>
        [Description("Leisure")]
        leisure = 375,

        /// <summary>
        /// 
        /// </summary>
        [Description("Loans")]
        loans = 376,

        /// <summary>
        /// 
        /// </summary>
        [Description("Low Income Earners")]
        lowIncomeEarners = 377,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lung")]
        lung = 378,

        /// <summary>
        /// 
        /// </summary>
        [Description("Making A Difference")]
        makingAdifference = 379,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical Services")]
        medicalServices = 380,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical Specialists")]
        medicalSpecialists = 381,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medication Administr")]
        medicationAdministr = 382,

        /// <summary>
        /// 
        /// </summary>
        [Description("Menstrual Information")]
        menstrualInformation = 383,

        /// <summary>
        /// 
        /// </summary>
        [Description("Methadone")]
        methadone = 384,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mobile Support And T")]
        mobileSupportAndt = 385,

        /// <summary>
        /// 
        /// </summary>
        [Description("Motor Neurone")]
        motorNeurone = 386,

        /// <summary>
        /// 
        /// </summary>
        [Description("Multiple Sclerosis")]
        multipleSclerosis = 387,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neighbourhood House")]
        neighbourhoodHouse = 388,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing Home")]
        nursingHome = 389,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nursing Mothers")]
        nursingMothers = 390,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obesity")]
        obesity = 391,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupational Health")]
        occupationalHealth = 392,

        /// <summary>
        /// 
        /// </summary>
        [Description("Optometrist")]
        optometrist = 393,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oral Hygiene")]
        oralHygiene = 394,

        /// <summary>
        /// 
        /// </summary>
        [Description("Outpatients")]
        outpatients = 395,

        /// <summary>
        /// 
        /// </summary>
        [Description("Outreach Service")]
        outreachService = 396,

        /// <summary>
        /// 
        /// </summary>
        [Description("PADP")]
        padp = 397,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pain")]
        pain = 398,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pap Smear")]
        papSmear = 399,

        /// <summary>
        /// 
        /// </summary>
        [Description("Parenting")]
        parenting = 400,

        /// <summary>
        /// 
        /// </summary>
        [Description("Peak Organizations")]
        peakOrganizations = 401,

        /// <summary>
        /// 
        /// </summary>
        [Description("Personal Care")]
        personalCare = 402,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharmacies")]
        pharmacies = 403,

        /// <summary>
        /// 
        /// </summary>
        [Description("Phobias")]
        phobias = 404,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical")]
        physical = 405,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical Activity")]
        physicalActivity = 406,

        /// <summary>
        /// 
        /// </summary>
        [Description("Postnatal")]
        postnatal = 407,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pregnancy")]
        pregnancy = 408,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pregnancy Tests")]
        pregnancyTests = 409,

        /// <summary>
        /// 
        /// </summary>
        [Description("Preschool")]
        preschool = 410,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prescriptions")]
        prescriptions = 411,

        /// <summary>
        /// 
        /// </summary>
        [Description("Primary Mental Healt")]
        primaryMentalHealt = 412,

        /// <summary>
        /// 
        /// </summary>
        [Description("Property Maintenance")]
        propertyMaintenance = 413,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prostate")]
        prostate = 414,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric")]
        psychiatric = 415,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric Disability Support Services - Home-Based Outreach")]
        psychiatricDisabilityHomeBasedOutreach = 416,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric Disability Support Services-Planned Respite")]
        PsychiatricDisabilityPlannedRespite = 417,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric Disability Support Services - Residential Rehabilitation")]
        psychiatricDisabilityResidentialRehabilitation = 418,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric Disability Home-Based Outreach")]
        psychiatricDisability = 419,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric Disability Suppport Services Mutual Support And Self Help")]
        psychiatricDisabilitySupportServicesMutualSupportAndSelfHelp = 420,

        /// <summary>
        /// 
        /// </summary>
        [Description("Psychiatric Support")]
        psychiatricSupport = 421,

        /// <summary>
        /// 
        /// </summary>
        [Description("Recreation")]
        recreation = 422,

        /// <summary>
        /// 
        /// </summary>
        [Description("Referral")]
        referral = 423,

        /// <summary>
        /// 
        /// </summary>
        [Description("Refuge")]
        refuge = 424,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rent Assistance")]
        rentAssistance = 425,

        /// <summary>
        /// 
        /// </summary>
        [Description("Residential Facilities")]
        residentialFaciliti = 426,

        /// <summary>
        /// 
        /// </summary>
        [Description("Residential Respite")]
        residentialRespite = 427,

        /// <summary>
        /// 
        /// </summary>
        [Description("Respiratory")]
        respiratory = 428,

        /// <summary>
        /// 
        /// </summary>
        [Description("Response")]
        response = 429,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rooming Houses")]
        roomingHouses = 430,

        /// <summary>
        /// 
        /// </summary>
        [Description("Safe Sex")]
        safeSex = 431,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secure Extended Care")]
        secureExtendedCare = 432,

        /// <summary>
        /// 
        /// </summary>
        [Description("Self Help")]
        selfHelp = 433,

        /// <summary>
        /// 
        /// </summary>
        [Description("Separation")]
        separation = 434,

        /// <summary>
        /// 
        /// </summary>
        [Description("Services")]
        services = 435,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sex Education")]
        sexEducation = 436,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sexual Abuse")]
        sexualAbuse = 437,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sexual Issues")]
        sexualIssues = 438,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sexually Transmitted")]
        sexuallyTransmitted = 439,

        /// <summary>
        /// 
        /// </summary>
        [Description("SIDS")]
        sids = 440,

        /// <summary>
        /// 
        /// </summary>
        [Description("Social Support")]
        socialSupport = 441,

        /// <summary>
        /// 
        /// </summary>
        [Description("Socialisation")]
        socialisation = 442,

        /// <summary>
        /// 
        /// </summary>
        [Description("Special Needs")]
        specialNeeds = 443,

        /// <summary>
        /// 
        /// </summary>
        [Description("Speech Therapist")]
        speechTherapist = 444,

        /// <summary>
        /// 
        /// </summary>
        [Description("Splinting")]
        splinting = 445,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sport")]
        sport = 446,

        /// <summary>
        /// 
        /// </summary>
        [Description("Statewide And Specia")]
        statewideAndSpecia = 447,

        /// <summary>
        /// 
        /// </summary>
        [Description("STD")]
        std = 448,

        /// <summary>
        /// 
        /// </summary>
        [Description("STI")]
        sti = 449,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stillbirth")]
        stillbirth = 450,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stomal Care")]
        stomalCare = 451,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stroke")]
        stroke = 452,

        /// <summary>
        /// 
        /// </summary>
        [Description("Substance Abuse")]
        substanceAbuse = 453,

        /// <summary>
        /// 
        /// </summary>
        [Description("Support")]
        support = 454,

        /// <summary>
        /// 
        /// </summary>
        [Description("Syringes")]
        syringes = 455,

        /// <summary>
        /// 
        /// </summary>
        [Description("Teeth")]
        teeth = 456,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tenancy Advice")]
        tenancyAdvice = 457,

        /// <summary>
        /// 
        /// </summary>
        [Description("Terminal Illness")]
        terminalIllness = 458,

        /// <summary>
        /// 
        /// </summary>
        [Description("Therapy")]
        therapy = 459,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transcription")]
        transcription = 460,

        /// <summary>
        /// 
        /// </summary>
        [Description("Translating Services")]
        translatingServices = 461,

        /// <summary>
        /// 
        /// </summary>
        [Description("Translator")]
        translator = 462,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transport")]
        transport = 463,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vertebrae")]
        vertebrae = 464,

        /// <summary>
        /// 
        /// </summary>
        [Description("Violence")]
        violence = 465,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vocational Guidance")]
        vocationalGuidance = 466,

        /// <summary>
        /// 
        /// </summary>
        [Description("Weight")]
        weight = 467,

        /// <summary>
        /// 
        /// </summary>
        [Description("Welfare Assistance")]
        welfareAssistance = 468,

        /// <summary>
        /// 
        /// </summary>
        [Description("Welfare Counselling")]
        welfareCounselling = 469,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wheelchairs")]
        wheelchairs = 470,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound Management")]
        woundManagement = 471,

        /// <summary>
        /// 
        /// </summary>
        [Description("Young People At Risk")]
        youngPeopleAtRisk = 472,

        /// <summary>
        /// 
        /// </summary>
        [Description("Further Desc. - Community Health Care")]
        furtherDescCommunityHealthCare = 473,

        /// <summary>
        /// 
        /// </summary>
        [Description("Library")]
        library = 474,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Hours")]
        communityHours = 475,

        /// <summary>
        /// 
        /// </summary>
        [Description("Further Desc. - Specialist Medical")]
        furtherDescSpecialistMedical = 476,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hepatology")]
        hepatology = 477,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastroenterology")]
        gastroenterology = 478,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gynaecology")]
        gynaecology = 479,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obstetrics")]
        obstetrics = 480,

        /// <summary>
        /// 
        /// </summary>
        [Description("Further Desc. - Specialist Surgical")]
        furtherDescSpecialistSurgical = 481,

        /// <summary>
        /// 
        /// </summary>
        [Description("Placement Protection")]
        placementProtection = 482,

        /// <summary>
        /// 
        /// </summary>
        [Description("Family Violence")]
        familyViolence = 483,

        /// <summary>
        /// 
        /// </summary>
        [Description("Integrated Family Services")]
        integratedFamilyServices = 484,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetes Educator")]
        diabetesEducator = 485,

        /// <summary>
        /// 
        /// </summary>
        [Description("Kinship Care")]
        kinshipCare = 486,

        /// <summary>
        /// 
        /// </summary>
        [Description("General Mental Health Services")]
        generalMentalHealthServices = 487,

        /// <summary>
        /// 
        /// </summary>
        [Description("Exercise Physiology")]
        exercisePhysiology = 488,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medical Research")]
        medicalResearch = 489,

        /// <summary>
        /// 
        /// </summary>
        [Description("Youth")]
        youth = 490,

        /// <summary>
        /// 
        /// </summary>
        [Description("Youth Services")]
        youthServices = 491,

        /// <summary>
        /// 
        /// </summary>
        [Description("Youth Health")]
        youthHealth = 492,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child and Family Ser")]
        childAndFamilySer = 493,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Visits")]
        homeVisits = 494,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mobile Services")]
        mobileServices = 495,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before and/or After")]
        beforeAndOrAfter = 496,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cancer Services")]
        cancerServices = 497,

        /// <summary>
        /// 
        /// </summary>
        [Description("Integrated Cancer Se")]
        integratedCancerSe = 498,

        /// <summary>
        /// 
        /// </summary>
        [Description("Multidisciplinary Se")]
        multidisciplinarySe = 499,

        /// <summary>
        /// 
        /// </summary>
        [Description("Multidisciplinary Ca")]
        multidisciplinaryCa = 500,

        /// <summary>
        /// 
        /// </summary>
        [Description("Meetings")]
        Meetings = 501,

        /// <summary>
        /// 
        /// </summary>
        [Description("BloodPressureMonit")]
        BloodPressureMonit = 502,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dose administration")]
        doseAdministration = 503,

        /// <summary>
        /// 
        /// </summary>
       [Description("Medical Equipment Hi")]
        medicalEquipmentHi = 504,

       /// <summary>
       /// 
       /// </summary>
        [Description("Parenting/Family Support/Education")]
        ParentingFamilySupportEducation = 505,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deputising Service")]
        deputisingService = 506,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cancer Support Groups")]
        cancerSupportGroups = 507,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Cancer Services")]
        communityCancerServices = 508,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Care Transport")]
        disabilityCareTransport = 509,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aged Care Transport")]
        agedCareTransport = 510,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diabetes Education s")]
        diabetesEducationS = 511,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac Rehabilitati")]
        cardiacRehabilitati = 512,

        /// <summary>
        /// 
        /// </summary>
        [Description("Young Adult Diabetes")]
        youngAdultDiabetes = 513,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pulmonary Rehabilita")]
        pulmonaryRehabilita = 514,

        /// <summary>
        /// 
        /// </summary>
        [Description("Art therapy")]
        artTherapy = 515,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medication Reviews")]
        medicationReviews = 516,

        /// <summary>
        /// 
        /// </summary>
        [Description("Telephone Counselling")]
        telephoneCounselling = 517,

        /// <summary>
        /// 
        /// </summary>
        [Description("Telephone Help Line")]
        telephoneHelpLine = 518,

        /// <summary>
        /// 
        /// </summary>
        [Description("Online Service")]
        onlineService = 519,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis - Mental Health")]
        crisisMentalHealth = 520,

        /// <summary>
        /// 
        /// </summary>
        [Description("Youth Crisis")]
        youthCrisis = 521,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sexual Assault")]
        sexualAssault = 522,

        /// <summary>
        /// 
        /// </summary>
        [Description("GPAH Other")]
        gpahOther = 523,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric Dermatology")]
        paediatricDermatology = 524,

        /// <summary>
        /// 
        /// </summary>
        [Description("Veterans Services")]
        veteransServices = 525,

        /// <summary>
        /// 
        /// </summary>
        [Description("Veterans")]
        veterans = 526,

        /// <summary>
        /// 
        /// </summary>
        [Description("Food Relief/Food/Meals")]
        foodReliefFoodMeals = 527,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dementia Care")]
        dementiaCare = 528,

        /// <summary>
        /// 
        /// </summary>
        [Description("Alzheimer")]
        alzheimer = 529,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drug and/or Alcohol Support Groups")]
        drugAndOrAlcoholSupportGroups = 530,

        /// <summary>
        /// 
        /// </summary>
        [Description("1-on-1 Support /Mentoring /Coaching")]
        OneOnOneSupportMentoringOrCoaching = 531,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chronic Disease Management")]
        chronicDiseaseManagement = 532,

        /// <summary>
        /// 
        /// </summary>
        [Description("Liaison Services")]
        liaisonServices = 533,

        /// <summary>
        /// 
        /// </summary>
        [Description("Walk-in Centre /Non-Emergency")]
        walkInCentreNonEmergency = 534,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inpatients")]
        inpatients = 535,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spiritual Counselling")]
        spiritualCounselling = 536,

        /// <summary>
        /// 
        /// </summary>
        [Description("Women's Health")]
        womensHealth = 537,

        /// <summary>
        /// 
        /// </summary>
[Description("Men's Health")]
        mensHealth = 538,

/// <summary>
/// 
/// </summary>
 [Description("Health Education/Awareness Program")]
        healthEducationAwarenessProgram = 539,

 /// <summary>
 /// 
 /// </summary>
        [Description("Test Message")]
        testMessage = 540,

        /// <summary>
        /// 
        /// </summary>
        [Description("Remedial Massage")]
        remedialMassage = 541,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adolescent Mental Health Services")]
        adolescentMentalHealthServices = 542,

        /// <summary>
        /// 
        /// </summary>
        [Description("Youth Drop In/Assistance/Support")]
        youthDropInAssistanceSupport = 543,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aboriginal Health Worker")]
        aboriginalHealthWorker = 544,

        /// <summary>
        /// 
        /// </summary>
        [Description("Women's Health Clinic")]
        womenHealthClinic = 545,

        /// <summary>
        /// 
        /// </summary>
        [Description("Men's Health Clinic")]
        mensHealthClinic = 546,

        /// <summary>
        /// 
        /// </summary>
        [Description("Migrant Health Clinic ")]
        migrantHealthClinic = 547,

        /// <summary>
        /// 
        /// </summary>
        [Description("Refugee Health Clinic")]
        refugeeHealthClinic = 548,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aboriginal Health Clinic")]
        aboriginalHealthClinic = 549,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse Practitioner Lead Clinic/s")]
        nursePractitionerLeadClinic= 550,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nurse Lead Clinic/s")]
        nurseLeadClinic = 551,

        /// <summary>
        /// 
        /// </summary>
        [Description("Culturally Tailored Support Groups")]
        culturallyTailoredSupportGroups = 552,

        /// <summary>
        /// 
        /// </summary>
        [Description("Culturally Tailored Health Promotion")]
        culturallyTailoredHealthPromotion = 553,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rehabilitation")]
        rehabilitation = 554,

        /// <summary>
        /// 
        /// </summary>
        [Description("Education Information/Referral")]
        educationInformationReferral = 555,

        /// <summary>
        /// 
        /// </summary>
        [Description("Social Work")]
        socialWork = 556,

        /// <summary>
        /// 
        /// </summary>
        [Description("Haematology")]
        haematology = 557,

        /// <summary>
        /// 
        /// </summary>
        [Description("Maternity Shared Car")]
        maternitySharedCar = 558,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rehabilitation Servi")]
        rehabilitationServi = 559,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cranio-sacral Therapy")]
        cranioSacralTherapy = 560,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prosthetics & Orthotics")]
        prostheticsAndOrthotics = 561,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Medicine Review")]
        homeMedicineReview = 562,

        /// <summary>
        /// 
        /// </summary>
        [Description("GPAH - Medical")]
        gpahMedical = 563,

        /// <summary>
        /// 
        /// </summary>
        [Description("Music Therapy")]
        musicTherapy = 564,

        /// <summary>
        /// 
        /// </summary>
        [Description("Falls Prevention")]
        fallsPrevention = 565,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accommodation/Tenancy")]
        accommodationTenancy = 566,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assess-Skill, Ability, Needs")]
        assessSkillAbilityNeeds = 567,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assist Access/Maintain Employ")]
        assistAccessMaintainEmploy = 568,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assist Prod-Pers Care/Safety")]
        assistProdPersCareSafety = 569,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assist-Integrate School/Ed")]
        assistIntegrateSchoolEd = 570,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assist-Life Stage, Transition")]
        assistLifeStageTransition = 571,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assist-Personal Activities")]
        assistPersonalActivities = 572,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assist-Travel/Transport")]
        assistTravelTransport = 573,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assistive Equip-General Tasks")]
        assistiveEquipGeneralTasks = 574,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assistive Equip-Recreation")]
        assistiveEquipRecreation = 575,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assistive Prod-Household Task")]
        assistiveProdHouseholdTask = 576,

        /// <summary>
        /// 
        /// </summary>
        [Description("Behavior Support")]
        behaviorSupport = 577,

        /// <summary>
        /// 
        /// </summary>
        [Description("Comms & Info Equipment")]
        commsAndInfoEquipment = 578,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Nursing Care")]
        communityNursingCare = 579,

        /// <summary>
        /// 
        /// </summary>
        [Description("Daily Tasks/Shared Living")]
        dailyTasksSharedLiving = 580,

        /// <summary>
        /// 
        /// </summary>
        [Description("Development-Life Skills")]
        developmentLifeSkills = 581,

        /// <summary>
        /// 
        /// </summary>
        [Description("Early Childhood Supports")]
        earlyChildhoodSupports = 582,

        /// <summary>
        /// 
        /// </summary>
        [Description("Equipment Special Assess Setup")]
        equipmentSpecialAssessSetup = 583,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hearing Equipment")]
        hearingEquipment = 584,

        /// <summary>
        /// 
        /// </summary>
        [Description("Home Modification")]
        homeModification = 585,

        /// <summary>
        /// 
        /// </summary>
        [Description("Household Tasks")]
        householdTasks = 586,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interpret/Translate")]
        interpretTranslate = 587,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other Innovative Supports")]
        otherInnovativeSupports = 588,

        /// <summary>
        /// 
        /// </summary>
        [Description("Participate Community")]
        participateCommunity = 589,

        /// <summary>
        /// 
        /// </summary>
        [Description("Personal Mobility Equipment")]
        personalMobilityEquipment = 590,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical Wellbeing")]
        physicalWellbeing = 591,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plan Management")]
        planManagement = 592,

        /// <summary>
        /// 
        /// </summary>
        [Description("Therapeutic Supports")]
        therapeuticSupports = 593,

        /// <summary>
        /// 
        /// </summary>
        [Description("Training-Travel Independence")]
        trainingTravelIndependence = 594,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vehicle modifications")]
        vehicleModifications = 595,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vision Equipment")]
        visionEquipment = 596,
    }
}
