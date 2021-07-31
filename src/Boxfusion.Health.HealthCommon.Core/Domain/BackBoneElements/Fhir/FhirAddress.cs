using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.FhirAddress")]
    public class FhirAddress : Address
    {
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }

        [ReferenceList("Fhir", "AddressUse")]
        public virtual int? Use { get; set; }
        [ReferenceList("Fhir", "AddressType")]
        public virtual int? Type { get; set; }
        public virtual string District { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
    }
}
