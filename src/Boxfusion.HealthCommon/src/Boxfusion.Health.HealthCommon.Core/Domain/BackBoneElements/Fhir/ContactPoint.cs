using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.ContactPoint")]
    public class ContactPoint : FullAuditedEntity<Guid>
    {
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }
        [ReferenceList("Fhir", "ContactPointSystem")]
        public virtual int? System { get; set; }
        public virtual string Value { get; set; }
        [ReferenceList("Fhir", "ContactPointUse")]
        public virtual int? Use { get; set; }
        public virtual int? Rank { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
    }
}
