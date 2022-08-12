using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "IdentifierUse")]
    public enum RefListIdentifierUses
    {
        [Description("Usual")]
        usual = 1,

        [Description("Official")]
        official = 2,

        [Description("Temp")]
        temp = 3,

        [Description("Secondary")]
        secondary = 4,

        [Description("Old")]
        old = 5
    }
}
