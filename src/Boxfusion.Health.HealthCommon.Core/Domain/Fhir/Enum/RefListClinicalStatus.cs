using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "ClinicalStatus")]
    public enum RefListClinicalStatus : long
    {
        [Description("Active")]
        active = 1
    }
}
