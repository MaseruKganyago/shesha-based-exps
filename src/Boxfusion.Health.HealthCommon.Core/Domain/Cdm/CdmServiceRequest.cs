using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.CdmServiceRequest")]
	public class CdmServiceRequest: ServiceRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListServiceRequestScheduleTypes? ScheduleType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Schedule ServiceQueue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ServiceQueuePosition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListServiceRequestQueuePriorities? ServiceQueuePriority { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Slot BookingSlot { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListConsultServiceRequestStatuses? ConsultServiceRequestStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? TimeJoinedQueue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? TimeCancelled { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? AllocatedTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter EncounterInitiated { get; set; }
	}
}
