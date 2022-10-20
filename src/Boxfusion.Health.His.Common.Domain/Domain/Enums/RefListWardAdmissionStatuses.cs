﻿using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("His", "WardAdmissionStatuses")]
    public enum RefListWardAdmissionStatuses : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Admitted")]
        admitted = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Separated")]
        separated = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("In-Transit")]
        inTransit = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rejected")]
        rejected = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Discharge - Initiated")]
        dischargeInitiated = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Discharge - Processed")]
        dischargeProcessed = 6
    }
}