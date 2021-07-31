using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.FhirOrganisation")]
    public class FhirOrganisation : Organisation
    {
        [ReferenceList("Fhir", "OrganisationTypes")]
        public virtual int? Type { get; set; }
        public virtual string PrimaryContactEmail { get; set; }
        public virtual string PrimaryContactTelephone { get; set; }
    }
}
