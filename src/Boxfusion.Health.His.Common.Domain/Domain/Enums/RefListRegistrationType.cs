using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("His", "RefListRegistrationType")]
    public enum RefListRegistrationType : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency")]
        Emergency = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Out Patient")]
        OutPatient = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("In Patient")]
        InPatient = 3
    }
}
