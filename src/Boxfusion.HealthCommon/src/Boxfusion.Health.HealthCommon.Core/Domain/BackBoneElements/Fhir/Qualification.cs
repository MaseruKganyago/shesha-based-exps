using Abp.Domain.Entities.Auditing;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Qualification")]
    public class Qualification : FullAuditedEntity<Guid>
    {
        public virtual Person Owner { get; set; }
        public virtual string Identifier { get; set; }
        [ReferenceList("Fhir", "QualificationCodes")]
        public virtual int? Code { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
        public virtual Organisation Issuer { get; set; }
    }
}
