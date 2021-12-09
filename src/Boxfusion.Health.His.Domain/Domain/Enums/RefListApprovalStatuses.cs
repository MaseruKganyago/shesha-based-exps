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
        [Description("In Progress")]
        Inprogress = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Approved")]
        approved = 2,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Awaiting Approval")]
        awaitingApproval = 3,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Awaiting Final Approval")]
        awaitingFinalApproval = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rejected")]
        Rejected = 5
    }
}
