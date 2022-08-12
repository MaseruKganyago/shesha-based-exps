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
    [ReferenceList("Fhir", "SpecimenStatuses")]
    public enum RefListSpecimenStatuses : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Available")]
        available = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Unvailable")]
        unavailable = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Unsatisfactory")]
        unsatisfactory = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entered in error")]
        enteredInError = 4
    }
}
