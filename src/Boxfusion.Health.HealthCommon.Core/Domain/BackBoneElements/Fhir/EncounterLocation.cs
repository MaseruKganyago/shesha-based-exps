using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.EncounterLocation")]
    public class EncounterLocation : FullAuditedEntity<Guid>
    {
        public virtual string OwnerId { get; set; }

        public virtual string OwnerType { get; set; }

        public virtual FhirLocation Location { get; set; }

        [ReferenceList("Fhir", "EncounterLocationStatuses")]
        public virtual int? Status { get; set; }

        [ReferenceList("Fhir", "LocationPhysicalTypes")]
        public virtual int? PhysicalType { get; set; }

        public virtual DateTime? StartDateTime { get; set; }

        public virtual DateTime? EndDateTime { get; set; }
    }
}
