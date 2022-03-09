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
    [ReferenceList("His", "Provinces")]
    public enum RefListProvinces : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Eastern Cape")]
        EasternCape = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Free State")]
        FreeState = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gauteng")]
        Gauteng = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("KwaZulu Natal")]
        KwaZuluNatal = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Limpopo")]
        Limpopo = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mpumalanga")]
        Mpumalanga = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Northern Cape")]
        NorthernCape = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("North West")]
        NorthWest = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Western Cape")]
        WesternCape = 9
    }
}
