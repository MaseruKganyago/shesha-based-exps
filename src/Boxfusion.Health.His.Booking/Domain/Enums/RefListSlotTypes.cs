using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Domain.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "SlotTypes")]
    public enum RefListSlotTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Regular")]
        regular = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Overflow")]
        overflow = 2
    }
}
