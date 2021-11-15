using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("His", "ApprovalStatuses")]
    public enum RefListApprovalStatuses : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Approved")]
        approved = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Not Approved")]
        notApproved = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Waiting for Approval")]
        waitingForApproval = 3
    }
}
