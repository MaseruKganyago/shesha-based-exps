using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "HealthcareServiceCategories")]
    public enum RefListHealthcareServiceCategories
    {
        [Description("General Practice")]
        generalPractice = 17,
        [Description("Hospital")]
        hospital = 35,
        [Description("Specialist Clinical Pathology")]
        specialistClinicalPathology = 26,
        [Description("Specialist Medical")]
        specialistMedical = 27,
        [Description("Specialist Obstetrics & Gynecology")]
        specialistObstetricsGynecology = 28,
        [Description("Specialist Paediatric")]
        specialistPaediatric = 29,
        [Description("Specialist Radiology/Imaging")]
        specialistRadiologyImaging = 30,
        [Description("Specialist Surgical")]
        specialistSurgical = 31
    }
}
