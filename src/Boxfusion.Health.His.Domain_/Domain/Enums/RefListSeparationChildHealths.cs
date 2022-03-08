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
    [ReferenceList("His", "SeparationChildHealths")]
    public enum RefListSeparationChildHealths : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("SAM under 5 years")]
        samUnder5Years = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("MAM under 5 years")]
        mamUnder5Years = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("NAM under 5 years")]
        namUnder5Years = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pneumonia under 5 years")]
        pneumoniaUnder5Years = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diarrhoea under 5 years")]
        diarrhoeaUnder5Years = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("HIV Testing")]
        hivTesting = 6
    }
}
