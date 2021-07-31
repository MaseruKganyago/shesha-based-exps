using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Practitioner")]
    public class Practitioner : PersonFhirBase
    {
        public virtual string PracticeSANCNumber { get; set; }
    }
}
