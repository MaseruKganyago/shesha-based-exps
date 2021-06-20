using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// This value set defines a set of codes that can be used to express the role of a diagnosis on the Encounter or EpisodeOfCare record.
    /// </summary>
    [ReferenceList("HealthDomain", "DiagnosisRole")]
    public enum RefListDiagnosisRole : int
    {
        /// <summary>
        /// Admission diagnosis
        /// </summary>
        [Description("Admission diagnosis")]
        AD = 1,
        /// <summary>
        /// Discharge diagnosis
        /// </summary>
        [Description("Discharge diagnosis")]
        DD = 2,
        /// <summary>
        /// Chief complaint
        /// </summary>
        [Description("Chief complaint")]
        CC = 3,
        /// <summary>
        /// Comorbidity diagnosis
        /// </summary>
        [Description("Comorbidity diagnosis")]
        CM = 4,
        /// <summary>
        /// pre-op diagnosis
        /// </summary>
        [Description("Pre-op diagnosis")]
        Preop = 5,
        /// <summary>
        /// Post-op diagnosis
        /// </summary>
        [Description("Post-op diagnosis")]
        Postop = 6,
        /// <summary>
        /// Billing
        /// </summary>
        [Description("Billing")]
        Billing = 7
    }
}
