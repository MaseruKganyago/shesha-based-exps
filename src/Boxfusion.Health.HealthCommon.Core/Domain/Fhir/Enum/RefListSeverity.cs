using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "Severity")]
    public enum RefListSeverity : long
    {
        [Description("Severe")]
        severe = 24484000,

        [Description("Moderate")]
        moderate = 6736007,

        [Description("Mild")]
        mild = 255604002
    }
}
