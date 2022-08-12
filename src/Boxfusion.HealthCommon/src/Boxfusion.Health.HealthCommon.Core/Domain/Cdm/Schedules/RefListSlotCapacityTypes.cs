using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Cdm", "SlotCapacityTypes")]
    [Flags]
    public enum RefListSlotCapacityTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Regular")]
        Regular = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Overflow")]
        Overflow = 2

    }
}
