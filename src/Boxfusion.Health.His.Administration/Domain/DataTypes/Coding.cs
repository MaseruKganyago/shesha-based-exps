using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.DataTypes
{
    [Entity(TypeShortAlias = "HealthDomain.Coding")]
    public class Coding<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        public virtual string System { get; set; }
        public virtual string Version { get; set; }
        public virtual T Code { get; set; }
        public virtual string  Display { get; set; }
        public virtual bool UserSelected { get; set; }
    }
}
