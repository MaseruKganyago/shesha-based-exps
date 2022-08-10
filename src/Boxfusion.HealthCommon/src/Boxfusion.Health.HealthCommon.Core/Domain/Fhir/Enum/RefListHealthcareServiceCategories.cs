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
    [ReferenceList("Fhir", "HealthcareServiceCategories")]
    public enum RefListHealthcareServiceCategories
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("General Practice")]
        generalPractice = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital")]
        hospital = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Clinical Pathology")]
        specialistClinicalPathology = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Medical")]
        specialistMedical = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Obstetrics & Gynecology")]
        specialistObstetricsGynecology = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Paediatric")]
        specialistPaediatric = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Radiology/Imaging")]
        specialistRadiologyImaging = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specialist Surgical")]
        specialistSurgical = 31
    }
}
