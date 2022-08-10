using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{/// <summary>
/// 
/// </summary>
    [ReferenceList("Fhir", "SpecimenConditions")]
    public enum RefListSpecimenConditions : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Autolyzed")]
        AUT = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Centifuged")]
        CFU = 2,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Clotted")]
        CLOT = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Contaminated")]
        CON = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cool")]
        COOL = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Frozen")]
        FROZEN = 32,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Hemolyzed")]
        HEM = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("Live")]
        LIVE = 128,

        /// <summary>
        /// 
        /// </summary>
        [Description("Room temperature")]
        ROOM = 256,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Sample not received")]
        SNR = 512,













    }
}
