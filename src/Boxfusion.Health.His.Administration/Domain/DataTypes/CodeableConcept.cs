using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.DataTypes
{
    [Entity(TypeShortAlias = "HealthDomain.CodeableConcept")]
    public class CodeableConcept<T> : FullAuditedEntity<Guid> where T: struct, IComparable, IConvertible, IFormattable
    {
        public virtual Coding<T> Coding { get; set; }
        public virtual string Text { get; set; }
    }
}
