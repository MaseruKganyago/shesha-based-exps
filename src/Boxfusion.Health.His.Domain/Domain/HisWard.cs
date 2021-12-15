using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain
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
