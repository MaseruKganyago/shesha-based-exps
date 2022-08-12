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
    [ReferenceList("Fhir", "ServiceCategories")]
    public enum RefListServiceCategories : long
    {
        [Description("Adoption")]
        Adoption = 1,

        [Description("Aged Care")]
        AgedCare = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Allied Health")]
        AlliedHealth = 3,

        [Description("Alternative/Complementary Therapies")]
        AlternativeComplementaryTherapies = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child Care /Kindergarten")]
        ChildCareKindergarten = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child Development")]
        ChildDevelopment = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Child Protection & Family Services")]
        ChildProtectionAndFamilyServices = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Community Health Care")]
        CommunityHealthCare = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Counselling")]
        Counselling = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crisis Line (GPAH use only)")]
        CrisisLineGPAHuseOnly = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Death Services")]
        A = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental")]
        Dental = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Disability Support")]
        DisabilitySupport = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drug/Alcohol")]
        DrugOrAlcohol = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("Education & Learning")]
        EducationAndLearning = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency Department")]
        EmergencyDepartment = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Employment")]
        Employment = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Financial & Material Aid")]
        FinancialAndMaterialAid = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("General Practice")]
        GeneralPractice = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital")]
        Hospital = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Housing/Homelessness")]
        HousingOrHomelessness = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interpreting")]
        Interpreting = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Justice")]
        Justice = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Legal")]
        Legal = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mental Health")]
        MentalHealth = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("NDIA")]
        NDIA = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Physical Activity & Recreation")]
        PhysicalActivityAndRecreation = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("Regulation")]
        Regulation = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Respite/Carer Support")]
        RespiteOrCarerSupport = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Clinical Pathology")]
        SpecialistClinicalPathology = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Medical")]
        SpecialistMedical = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Obstetrics & Gynecology")]
        SpecialistObstetricsAndGynecology = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Paediatric")]
        SpecialistPaediatric = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Radiology/Imaging")]
        SpecialistRadiologyORImaging = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Surgical")]
        SpecialistSurgical = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("Support Group/s")]
        SupportGroup = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("Test Message (HSD admin)")]
        TestMessageHSDadmin = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transport")]
        Transport = 37


    }
}
