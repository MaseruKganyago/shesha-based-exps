using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.FhirLocation")]
	public class FhirLocation: Facility
	{
		[ReferenceList("Fhir", "LocationStatuses")]
		public virtual int? Status { get; set; }

		[ReferenceList("Fhir", "LocationBedStatuses")]
		public virtual int? OperationalStatus { get; set; }


		public virtual string Alias { get; set; }


		[ReferenceList("Fhir", "LocationModes")]
		public virtual int? Mode { get; set; }

		[ReferenceList("Fhir", "ServiceDeliveryLocationRoleTypes")]
		public virtual int? Type { get; set; }
		public virtual string PrimaryContactEmail { get; set; }
		public virtual string PrimaryContactTelephone { get; set; }

		[ReferenceList("Fhir", "LocationPhysicalTypes")]
		public virtual int? PhysicalType { get; set; }
		public virtual string AvailabilityExceptions { get; set; }
	}
}
