using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Cdm", "HospitalTypes")]
    public enum RefListHospitalTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Level 1 - Primary Health Care Clinic")]
        level1PrimaryHealthCareCareClinic = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Level 1 - Community Health Care Centre")]
        level1CommunityHealthCareCentre = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Level 1 - District Hospital")]
        level1DistrictHospital = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Level 2 - Regional Hospital")]
        level2RegionalHospital = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Level 3 - Provincial Tertiary Hospital")]
        level3ProvincialTertiaryHospital = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Level 4 - Central Hospitals")]
        level4CentralHospitals = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Level 4 - Specialised Hospital")]
        level4SpecialisedHospital = 7
    }
}
