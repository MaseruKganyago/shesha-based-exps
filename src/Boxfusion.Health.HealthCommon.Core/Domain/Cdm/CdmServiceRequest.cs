using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.CdmServiceRequest")]
	public class CdmServiceRequest: ServiceRequest
	{
		[ReferenceList("Cdm", "ServiceRequestScheduleTypes")]
		public virtual int? ScheduleType { get; set; }
		public virtual Schedule ServiceQueue { get; set; }
		public virtual decimal ServiceQueuePosition { get; set; }
		[ReferenceList("Cdm", "ServiceRequestQueuePriorities")]
		public virtual int? ServiceQueuePriority { get; set; }
		public virtual Slot BookingSlot { get; set; }
		[ReferenceList("Cdm", "ConsultServiceRequestStatuses")]
		public virtual int? ConsultServiceRequestStatus { get; set; }
		public virtual DateTime? TimeJoinedQue { get; set; }
		public virtual DateTime? TimeCancelled { get; set; }
		public virtual DateTime? AllocatedTime { get; set; }
		public virtual Encounter EncounterInitiated { get; set; }
	}
}
