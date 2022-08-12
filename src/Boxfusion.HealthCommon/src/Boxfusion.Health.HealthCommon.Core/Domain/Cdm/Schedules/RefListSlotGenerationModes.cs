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
    [ReferenceList("Cdm", "SlotGenerationModes")]
    public enum RefListSlotGenerationModes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("One slot per resource")]
        OneSlotPerResource = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("One slot for all resources")]
        OneSlotForAllResources = 2

    }
}
