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
    [ReferenceList("Fhir", "ConditionClinicalStatus")]
    public enum RefListConditionClinicalStatus : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Active")]
        active = 1
    }
}
