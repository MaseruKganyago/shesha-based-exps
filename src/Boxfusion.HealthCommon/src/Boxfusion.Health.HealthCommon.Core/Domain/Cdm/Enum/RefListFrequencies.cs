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
    [ReferenceList("Cdm", "Frequencies")]
    public enum RefListFrequencies : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("1x per day")]
        perday1 = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("2x per day")]
        perday2 = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("3x per day")]
        perday3 = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("4x per day")]
        perday4 = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("5x per day")]
        perday5 = 5,
        /// <summary>
        /// 
        /// </summary>
        [Description("6x per day")]
        perday6 = 6,
        /// <summary>
        /// 
        /// </summary>
        [Description("Every 4 hours")]
        Every4hours = 7,
        /// <summary>
        /// 
        /// </summary>
        [Description("Every 6 hours")]
        Every6hours = 8,
        /// <summary>
        /// 
        /// </summary>
        [Description("Every 8 hours")]
        Every8hours = 9,
        /// <summary>
        /// 
        /// </summary>
        [Description("Every 12 hours")]
        Every12hours = 10
    }
}
