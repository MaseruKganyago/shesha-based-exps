using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.DataTypes;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.Hospitalization")]
    public class Hospitalization<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        public virtual Identifier<T> PreAdmissionIdentifier { get; set; }
        public virtual Organization Origin { get; set; }

    }
}
