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
    [ReferenceList("His", "TransferRejectionReasons")]
    public enum RefListTransferRejectionReasons : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("No availability")]
        noAvailability = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transferred to incorrect ward")]
        transferredToIncorrectWard = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other (you will have to state the reason)")]
        other = 3
    }
}
