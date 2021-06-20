using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.DataTypes;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.Participant")]
    public class Participant<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        public virtual RefListEncounterParticipantType? Type { get; set; }
        public virtual Period Period { get; set; }
        public virtual Practioner Individual { get; set; }
        public virtual Encounter<T> Encounter { get; set; }
    }
}
