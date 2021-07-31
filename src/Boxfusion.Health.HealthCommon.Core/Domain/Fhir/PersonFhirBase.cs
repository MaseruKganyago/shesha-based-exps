using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.PersonFhirBase")]
	public class PersonFhirBase: Person
	{
        public virtual string PassportNumber { get; set; }
        public virtual string PermitNumber { get; set; }
        [MultiValueReferenceList("Shesha.Core", "CommonLanguage")]
        public virtual int? CommunicationLanguage { get; set; }
        public virtual StoredFile IDDocument { get; set; }
        [ReferenceList("Cdm", "IdentityVerificationStatus")]
        public virtual int? IdentityVerificationStatus { get; set; }
        [ReferenceList("Cdm", "Countries")]
        public virtual int? Nationality { get; set; }
        [ReferenceList("Cdm", "PersonEthnicity")]
        public virtual int? Ethnicity { get; set; }

    }
}
