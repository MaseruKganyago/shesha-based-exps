using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "ParticipantTypes")]
    public enum RefListParticipantTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("admitter")]
        ADM = 1 ,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("attender")]
        ATND = 2 ,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("callback contact")]
        CALLBCK =  4,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("consultant")]
        CON =  8,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("discharger")]
        DIS =  16,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("escort")]
        ESC =  32,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("referrer")]
        REF =  64,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("secondary performer")]
        SPRF =  128,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("primary performer")]
        PPRF = 256,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Participation")]
        PART =  512,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Translator")]
        translator =  1024,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency")]
        emergency = 2048

    }
}
