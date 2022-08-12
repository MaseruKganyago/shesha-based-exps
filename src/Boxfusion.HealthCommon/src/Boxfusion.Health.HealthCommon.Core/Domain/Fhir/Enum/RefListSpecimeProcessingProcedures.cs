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
    [ReferenceList("Fhir", "SpecimeProcessingProcedures")]
    public enum RefListSpecimeProcessingProcedures : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Acidification")]
        ACID = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Alkalization")]
        ALK = 2,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Defibrination")]
        DEFB = 3,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Filtration")]
        FILT = 4,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("LDL Precipitation")]
        LDLP = 5,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Neutralization")]
        NEUT = 6,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Recalification")]
        RECA = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ultrafiltration")]
        UFIL = 8




    }
}
