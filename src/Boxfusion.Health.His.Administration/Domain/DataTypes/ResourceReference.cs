using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.DataTypes
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Reference")]
    public class ResourceReference<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        public virtual string Reference { get; set; }
        public virtual string Type { get; set; }
        public virtual Identifier<T> Identifier { get; set; }
        public virtual string Display { get; set; }
    }
}
