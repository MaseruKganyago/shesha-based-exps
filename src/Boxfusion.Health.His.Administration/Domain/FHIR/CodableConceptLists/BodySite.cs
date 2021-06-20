using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.FHIR.CodableConceptLists
{
    /// <summary>
    /// This value set includes all codes from SNOMED CT for BodyStructure
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.BodySite")]
    public class BodySite : FullAuditedEntity<Guid>
    {
        public virtual string System { get; set; }
        public virtual string Code { get; set; }
        public virtual string Display { get; set; }
    }
}
