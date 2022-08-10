using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Slot", GenerateApplicationService = false)]
	[Table("Fhir_Slots")]
	[Discriminator]
	public class Slot: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// External Ids for this item
		/// </summary>
		public virtual string Identifier { get; set; }

		/// <summary>
		/// A broad categorization of the service that is to be performed during this appointment
		/// </summary>
		[MultiValueReferenceList("Fhir", "SlotServiceCategories")]
		[ReferenceList("Fhir", "HealthcareServiceCategories")]
		public virtual long? ServiceCategory { get; set; }

		/// <summary>
		/// The type of appointments that can be booked into this slot (ideally this would be an identifiable service - which is at a location, rather than the location itself). If provided then this overrides the value provided on the availability resource
		/// </summary>
		[ReferenceList("Fhir", "ServiceTypes")]
		public virtual long? ServiceType { get; set; }

		/// <summary>
		/// The specialty of a practitioner that would be required to perform the service requested in this appointment.
		/// </summary>
		[ReferenceList("Fhir", "PracticeSettingCodeValueSets")]
		public virtual long? Speciality { get; set; }

		/// <summary>
		/// The style of appointment or patient that may be booked in the slot (not service type).
		/// </summary>
		[ReferenceList("Fhir", "AppointmentReasonCodes")]
		public virtual long? AppointmentType { get; set; }

		/// <summary>
		/// The schedule resource that this slot defines an interval of status information.
		/// </summary>
		public virtual Schedule Schedule { get; set; }

		/// <summary>
		/// busy | free | busy-unavailable | busy-tentative | entered-in-error.
		/// </summary>
		public virtual RefListSlotStatuses? Status { get; set; }

		/// <summary>
		/// Date/Time that the slot is to begin.
		/// </summary>
		public virtual DateTime? StartDateTime { get; set; }

		/// <summary>
		/// Date/Time that the slot is to conclude.
		/// </summary>
		public virtual DateTime? EndDateTime { get; set; }

		/// <summary>
		/// This slot has already been overbooked, appointments are unlikely to be accepted for this time.
		/// </summary>
		public virtual bool Overbooked { get; set; }

		/// <summary>
		/// Comments on the slot to describe any extended information. Such as custom constraints on the slot.
		/// </summary>
		public virtual string Comment { get; set; }
	}
}
