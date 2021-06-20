using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Enum list of all South African provinces
    /// </summary>
    [ReferenceList("HealthDomain", "Province")]
    public enum RefListProvince : int
    {
        /// <summary>
        /// Gauteng province
        /// </summary>
        [Description("Gauteng")]
        GP = 1,
        /// <summary>
        /// Western Cape Province
        /// </summary>
        [Description("Western Cape")]
        WC = 2,
        /// <summary>
        /// Eastern Cape Province
        /// </summary>
        [Description("Eastern Cape")]
        EC = 3,
        /// <summary>
        /// Northern Cape Province
        /// </summary>
        [Description("Northern Cape")]
        NC = 4,
        /// <summary>
        /// KwaZulu Nata province
        /// </summary>
        [Description("KwaZulu Natal")]
        KZN = 5,
        /// <summary>
        /// Free State province
        /// </summary>
        [Description("Free State")]
        FS = 6,
        /// <summary>
        /// North West province
        /// </summary>
        [Description("North West")]
        NW = 7,
        /// <summary>
        /// Mpumalanga province
        /// </summary>
        [Description("Mpumalanga")]
        MP = 8,
        /// <summary>
        /// Limpopo province
        /// </summary>
        [Description("Limpopo")]
        LP = 9
    }
}
