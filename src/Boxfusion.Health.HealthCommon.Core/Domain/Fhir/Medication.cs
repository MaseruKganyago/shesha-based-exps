using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Medication")]
	public class Medication: FullAuditedEntity<Guid>
	{
		public virtual string Identifier { get; set; }
		[ReferenceList("Fhir", "MedicationCodes")]
		public virtual int? Code { get; set; }
		[ReferenceList("Fhir", "MedicationStatuses")]
		public virtual int? Status { get; set; }
		public virtual FhirOrganisation Manufacture { get; set; }
		[ReferenceList("Fhir", "MedicationFormCodes")]
		public virtual int? Form { get; set; }
		public virtual decimal AmountNumerator { get; set; }
		public virtual decimal AmountDenominator { get; set; }
		public virtual string BatchLotNumber { get; set; }
		public virtual DateTime? BatchExpirationDate { get; set; }
	}
}
