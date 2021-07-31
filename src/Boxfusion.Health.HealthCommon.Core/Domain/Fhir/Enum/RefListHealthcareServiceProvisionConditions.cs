using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "HealthcareServiceProvisionConditions")]
    public enum RefListHealthcareServiceProvisionConditions
    {
        [Description("Free")]
        free = 1,
        [Description("Discounts Available")]
        disc = 2,
        [Description("Fees apply")]
        cost = 3
    }
}
