using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "FollowupNotificationStatuses")]
    public enum RefListFollowupNotificationStatuses
    {
        [Description("Sent")]
        sent = 1,

        [Description("NotSent")]
        notSent = 2,

        [Description("Failed")]
        failed = 3,

        [Description("Pending")]
        pending = 4
    }
}
