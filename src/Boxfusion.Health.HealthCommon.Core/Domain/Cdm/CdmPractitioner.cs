using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmPractitioner")]
    public class CdmPractitioner : PersonFhirBase
    {
        [ReferenceList("Cdm", "PractitionerRoles")]
        public virtual int? PrimaryPractitionerRole { get; set; }
    }
}
