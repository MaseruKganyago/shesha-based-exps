using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Patient")]
	public class Patient: PersonFhirBase
	{
        public virtual string OtherIdentityNumber { get; set; }
        public virtual bool MultipleBirthBoolean { get; set; }
        public virtual int? MultipleBirthInteger { get; set; }
        public virtual bool DeceasedBoolean { get; set; }
        public virtual DateTime? DeceasedDateTime { get; set; }
        [ReferenceList("Fhir", "MaritalStatus")]
        public virtual int? MaritalStatus { get; set; }
        public virtual string GeneralPractitioner { get; set; }
        public virtual Patient LinkToOtherPatient { get; set; }
        [ReferenceList("Fhir", "LinkTypes")]
        public virtual int? TypeOfLinkToOtherPatient { get; set; }
    }
}
