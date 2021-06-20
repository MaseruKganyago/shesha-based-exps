using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// A category assigned to the condition.
    /// </summary>
    [ReferenceList("HealthDomain", "ConditionCategory")]
    public enum RefListConditionCategory : int
    {
        /// <summary>
        /// An item on a problem list that can be managed over time and can be expressed by a practitioner (e.g. physician, nurse), patient, or related person.
        /// </summary>
        [Description("Problem List Item")]
        ProblemListItem = 1,
        /// <summary>
        /// A point in time diagnosis (e.g. from a physician or nurse) in context of an encounter.
        /// </summary>
        [Description("Encounter Diagnosis")]
        EncounterDiagnosis = 2
    }
}
