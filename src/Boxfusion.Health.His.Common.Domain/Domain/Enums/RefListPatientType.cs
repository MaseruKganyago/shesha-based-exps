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
    [ReferenceList("His", "PatientType")]
    public enum RefListPatientType : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency")]
        emergency = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("In Patient")]
        inPatient = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Out Patient")]
        outPatient = 3
    }
}
