using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain.Enums
{
    [ReferenceList("His", "MidnightCensusApprovalModel")]
    public enum RefListMidnightCensusApprovalModel: long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Single Approver")]
        SingleApprover = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Two Approver")]
        TwoApprover = 2
    }
}
