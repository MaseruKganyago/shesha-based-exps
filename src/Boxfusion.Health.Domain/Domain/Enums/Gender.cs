using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Administrative Gender - the gender that the patient is considered to have for administration and record keeping purposes.
    /// </summary>
    [ReferenceList("HealthDomain", "Gender")]
    public enum RefListGender : int
    {
        /// <summary>
        /// Male
        /// </summary>
        [Description("Male")]
        planned = 1,
        /// <summary>
        /// Female
        /// </summary>
        [Description("Female")]
        active = 2,
        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        reserved = 3,
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        unknown = 4
    }
}
