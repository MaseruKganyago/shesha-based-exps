using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.AllergyIntoleranceCodes")]
    public class AllergyIntoleranceCode : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; } 
    }
}
