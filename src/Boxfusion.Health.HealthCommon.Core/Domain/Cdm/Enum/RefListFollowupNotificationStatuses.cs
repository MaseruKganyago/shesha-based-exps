using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Cdm", "FollowupNotificationStatuses")]
    public enum RefListFollowupNotificationStatuses: long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Sent")]
        sent = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("NotSent")]
        notSent = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Failed")]
        failed = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pending")]
        pending = 4
    }
}
