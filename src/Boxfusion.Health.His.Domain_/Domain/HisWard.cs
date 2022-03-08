using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisWard")]
    public class HisWard : Ward
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListMidnightCensusApprovalModel MidnightCensusApprovalModel { get; set; }
    }
}
