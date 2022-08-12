using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Shesha.Domain.Attributes;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "SlotStatuses")]
    public enum RefListSlotStatuses: long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Busy")]
        busy = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Free")]
        free = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Busy(unavailable)")]
        busyUnavailable = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Busy(tentative)")]
        busyTentative = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entered in error")]
        EnteredInError = 5

    }
}
