using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Identifies the purpose for this identifier, if known .
    /// </summary>
    [ReferenceList("HealthDomain", "IdentifierUse")]
    public enum RefListIdentifierUse : int
    {
        /// <summary>
        /// Usual
        /// </summary>
        [Description("Usual")]
        usual = 1,
        /// <summary>
        /// Official
        /// </summary>
        [Description("Official")]
        official = 2,
        /// <summary>
        /// Temp
        /// </summary>
        [Description("Temp")]
        temp = 3,
        /// <summary>
        /// Secondary
        /// </summary>
        [Description("Secondary")]
        secondary = 4,
        /// <summary>
        /// Old (If known)
        /// </summary>
        [Description("Old")]
        old = 4,
    }
}
