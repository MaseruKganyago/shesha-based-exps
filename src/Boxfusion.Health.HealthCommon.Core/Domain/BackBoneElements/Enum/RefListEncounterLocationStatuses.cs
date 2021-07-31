using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "EncounterLocationStatuses")]
    public enum RefListEncounterLocationStatuses
    {
        [Description("Planned")]
        planned = 1,
        [Description("Active")]
        active = 2,
        [Description("Reserved")]
        reserved = 3,
        [Description("Completed")]
        completed = 4
    }
}
