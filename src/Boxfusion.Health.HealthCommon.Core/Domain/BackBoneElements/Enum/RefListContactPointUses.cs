using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "ContactPointUses")]
    public enum RefListContactPointUses
    {
        [Description("Home")]
        home = 1,
        [Description("Work")]
        work = 2,
        [Description("Temporary")]
        temp = 3,
        [Description("Old")]
        old = 4,
        [Description("Mobile")]
        mobile = 5
    }
}
