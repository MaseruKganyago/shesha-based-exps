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
    [ReferenceList("His", "SeparationTypes")]
    public enum RefListSeparationTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Discharge (Normal)")]
        dischargeNormal = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Discharge (Abscondment)")]
        dischargeAbscondment = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Discharge (RHT)")]
        dischargeRHT = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Internal Transfer")]
        internalTransfer = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("External Transfer")]
        externalTransfer = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Death")]
        death = 6
    }
}
