using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "AddressUse")]
    public enum RefListAddressUse
    {
        [Description("Home")]
        home = 1,
        [Description("Work")]
        work = 2,
        [Description("Temporary")]
        temp = 3,
        [Description("Old / Incorrect")]
        old = 4,
        [Description("Billing")]
        billing = 5
    }
}
