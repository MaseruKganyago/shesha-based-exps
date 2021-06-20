using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// The clinical status of the condition.
    /// </summary>
    [ReferenceList("HealthDomain", "ClinicalStatus")]
    public enum RefListClinicalStatus : int
    {
        /// <summary>
        /// The subject is currently experiencing the symptoms of the condition or there is evidence of the condition.
        /// </summary>
        Active = 1,
        /// <summary>
        /// The subject is experiencing a re-occurence or repeating of a previously resolved condition, e.g. urinary tract infection, pancreatitis, cholangitis, conjunctivitis.
        /// </summary>
        Recurrence = 2,
        /// <summary>
        /// The subject is experiencing a return of a condition, or signs and symptoms after a period of improvement or remission, e.g. relapse of cancer, multiple sclerosis, rheumatoid arthritis, systemic lupus erythematosus, bipolar disorder, [psychotic relapse of] schizophrenia, etc.
        /// </summary>
        Relapse = 3,
        /// <summary>
        /// The subject is no longer experiencing the symptoms of the condition or there is no longer evidence of the condition.
        /// </summary>
        Inactive = 4,
        /// <summary>
        /// The subject is no longer experiencing the symptoms of the condition, but there is a risk of the symptoms returning.
        /// </summary>
        Remission = 5,
        /// <summary>
        /// The subject is no longer experiencing the symptoms of the condition and there is a negligible perceived risk of the symptoms returning.
        /// </summary>
        Resolved = 6
    }
}
