using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Identifier")]
    public class Identifier : FullAuditedEntity<Guid>
    {
        public Identifier()
        {

        }
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }
        [ReferenceList("Fhir", "IdentifierUses")]
        public virtual int? Use { get; set; }
        [ReferenceList("Fhir", "IdentifierTypes")]
        public virtual int? Type { get; set; }
        public virtual string System { get; set; }
        public virtual string Value { get; set; }
        public virtual DateTime? PeriodStart { get; set; }
        public virtual DateTime? PeriodEnd { get; set; }
        public virtual FhirOrganisation Assigner { get; set; }
    }
}
