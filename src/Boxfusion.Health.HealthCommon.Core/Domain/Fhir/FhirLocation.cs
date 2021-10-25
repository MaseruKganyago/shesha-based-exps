using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.FhirLocation")]
	public class FhirLocation: Facility
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "LocationStatuses")]
		public virtual int? Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "LocationBedStatuses")]
		public virtual int? OperationalStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Alias { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "LocationModes")]
		public virtual int? Mode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ServiceDeliveryLocationRoleTypes")]
		public virtual int? Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PrimaryContactEmail { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public virtual string PrimaryContactTelephone { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "LocationPhysicalTypes")]
		public virtual int? PhysicalType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string AvailabilityExceptions { get; set; }
	}
}
