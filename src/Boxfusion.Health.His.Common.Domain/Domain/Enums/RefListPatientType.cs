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
        [Description("Adult")]
        adult = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Minor")]
        minor = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("New Born")]
        newBorn = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("V.I.P")]
        vip = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric")]
        paediatric = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Expired")]
        Expired = 3
    }
}
