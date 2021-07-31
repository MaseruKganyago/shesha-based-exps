using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "HealthcareServiceTypes")]
    public enum RefListHealthcareServiceTypes
    {
        [Description("Friendly Visiting")]
        friendlyVisiting = 7,
        [Description("Home Care/Housekeeping Assistance")]
        homeCareHousekeepingAssistance = 8,

        [Description("General Practice")]
        generalPractice = 124,

        [Description("Community Care Unit")]
        communityCareUnit = 291,

        [Description("Community Health")]
        communityHealth = 293,

        [Description("General Practitioner")]
        generalPractitioner = 349,

        [Description("Home Help")]
        homeHelp = 357,

        [Description("Medical Services")]
        medicalServices = 382,

        [Description("Medical Services")]
        medicalSpecialists = 383,

        [Description("General Mental Health Services")]
        generalMentalHealthServices = 490,

        [Description("Nurse Practitioner Lead Clinic/s")]
        nursePractitionerLeadClinics = 572,

        [Description("Nurse Lead Clinic/s")]
        nurseLeadClinics = 573,

        [Description("Community Nursing Care")]
        communityNursingCare = 612,
    }
}
