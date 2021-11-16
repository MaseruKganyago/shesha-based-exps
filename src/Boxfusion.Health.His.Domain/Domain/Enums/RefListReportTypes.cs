using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("His", "RefListReportTypes")]
    public enum RefListReportTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Daily Report")]
        Daily = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Monthly Report")]
        Monthly = 2
    }
}
