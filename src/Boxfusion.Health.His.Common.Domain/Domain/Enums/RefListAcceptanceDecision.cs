using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
    [ReferenceList("His", "AcceptanceDecision")]
    public enum RefListAcceptanceDecision
    {
        Accept = 1,
        Reject = 2
    }
}
