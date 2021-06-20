using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// The status property covers the general availability of the resource, not the current value which may be covered by the 
    /// operationStatus, or by a schedule/slots if they are configured for the location.
    /// </summary>
    [ReferenceList("HealthDomain", "LocationStatus")]
    public enum RefListLocationStatus : int
    {
        /// <summary>
        /// The location is operational.
        /// </summary>
        [Description("Postal")]
        active = 1,
        /// <summary>
        /// The location is temporarily closed.
        /// </summary>
        [Description("Physical")]
        suspended = 2,
        /// <summary>
        /// The location is no longer used.
        /// </summary>
        [Description("Inactive")]
        inactive = 3
    }
}
