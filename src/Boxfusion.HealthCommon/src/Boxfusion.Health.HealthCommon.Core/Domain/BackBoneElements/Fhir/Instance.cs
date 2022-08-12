using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Instance")]
    public class Instance : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? Expiry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Substance Substance { get; set; }
    }
}
