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
    [ReferenceList("Cdm", "Repeats")]
    public enum RefListRepeats : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("No Repeats")]
        NoRepeats = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("2 Months")]
        Months2 = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("3 Months")]
        Months3 = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("4 Months")]
        Months4 = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("5 Months")]
        Months5 = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("6 Months")]
        Months6 = 6
    }
}
