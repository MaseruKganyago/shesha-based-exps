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
    [ReferenceList("Cdm", "Routes")]
    public enum RefListRoutes : long
    {
        /// <summary>
        /// 
        /// </summary>
        Orally = 1,
        /// <summary>
        /// 
        /// </summary>
        Inhale = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Intramuscular (inject into muscle)")]
        Intramuscular = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Nasal (spray into nose)")]
        Nasal = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmic (eye drops, gel, or ointment)")]
        Ophthalmic = 5,
        /// <summary>
        /// 
        /// </summary>
        [Description("Otic (drops into the ear)")]
        Otic = 6,
        /// <summary>
        /// 
        /// </summary>
        [Description("Rectal (inserted into the rectum)")]
        Rectal = 7,
        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous (inject under the skin)")]
        Subcutaneous = 8,
        /// <summary>
        /// 
        /// </summary>
        [Description("Sublingual (held under the tongue)")]
        Sublingual = 9,
        /// <summary>
        /// 
        /// </summary>
        [Description("Topical (applied to the skin)")]
        Topical = 10,
        /// <summary>
        /// 
        /// </summary>
        [Description("Transdermal (place patch on the skin)")]
        Transdermal = 11,
        /// <summary>
        /// 
        /// </summary>
        [Description("Buccal (hold inside the cheek)")]
        Buccal = 12
    }
}
