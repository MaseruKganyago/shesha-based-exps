using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Whether this hospitalization is a readmission and why if known.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterReAdmission")]
    public enum RefListEncounterReAdmission : int
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Re-admission")]
        R = 1
    }
}
