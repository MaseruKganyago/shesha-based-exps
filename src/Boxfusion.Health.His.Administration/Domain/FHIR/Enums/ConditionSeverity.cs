using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// A subjective assessment of the severity of the condition as evaluated by the clinician.
    /// </summary>
    [ReferenceList("HealthDomain", "ConditionSeverity")]
    public enum RefListConditionSeverity : int
    {
        /// <summary>
        /// Condition is severe.
        /// </summary>
        Severe = 1,
        /// <summary>
        /// Condition is moderate.
        /// </summary>
        Moderate = 2,
        /// <summary>
        /// Condition is mild.
        /// </summary>
        Mild = 3
    }
}
