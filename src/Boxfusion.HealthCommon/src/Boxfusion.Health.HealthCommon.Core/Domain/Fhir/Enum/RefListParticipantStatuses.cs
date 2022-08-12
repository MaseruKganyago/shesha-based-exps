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
    [ReferenceList("Fhir", "ParticipantStatuses")]
    public enum RefListParticipantStatuses: long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Accepted")]
        accepted = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Declined")]
        declined = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tentative")]
        tentative = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Needs-action")]
        needsAction = 4,
    }
}
