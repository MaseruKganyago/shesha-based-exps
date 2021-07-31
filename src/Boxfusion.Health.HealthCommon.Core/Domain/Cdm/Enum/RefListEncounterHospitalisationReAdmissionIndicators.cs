using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "EncounterHospitalisationReAdmissionIndicators")]
    public enum RefListEncounterHospitalisationReAdmissionIndicators
    {
        [Description("Re-admission")]
        R = 1
    }
}
