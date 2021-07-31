using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "PersonEthnicity")]
    public enum RefListPersonEthnicity
    {
        [Description("Unknown")]
        unknown = 1,

        [Description("African")]
        african = 2,

        [Description("European")]
        european = 4,

        [Description("Indian/Asian")]
        asian = 8,

        [Description("Coloured")]
        coloured = 16,

        [Description("Other")]
        other = 32
    }
}
