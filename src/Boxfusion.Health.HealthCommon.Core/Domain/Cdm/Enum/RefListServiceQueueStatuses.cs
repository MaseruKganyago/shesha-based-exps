using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "ServiceQueueStatuses")]
    public enum RefListServiceQueueStatuses
    {
        Open = 1,
        Paused = 2,
        Closed = 3
    }
}
