using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "AddressType")]
    public enum RefListAddressType
    {
        [Description("Postal")]
        postal = 1,
        [Description("Physical")]
        physical = 2
    }
}
