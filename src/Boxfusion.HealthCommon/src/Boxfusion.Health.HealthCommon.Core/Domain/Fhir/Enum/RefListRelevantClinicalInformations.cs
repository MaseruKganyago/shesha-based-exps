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
    [ReferenceList("Fhir", "RelevantClinicalInformations")]
    public enum RefListRelevantClinicalInformations : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Patient was fasting prior to the procedure.")]
        F = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fasting not asked of the patient at time of procedure.")]
        FNA = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("The patient indicated they did not fast prior to the procedure.")]
        NF = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Not Given - Patient was not asked at the time of the procedure.")]
        NG = 4
    }
}
