using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "EncounterLocationStatuses")]
    public enum RefListEncounterLocationStatuses : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Planned")]
        planned = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Active")]
        active = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Reserved")]
        reserved = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Completed")]
        completed = 4
    }
}
