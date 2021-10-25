using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmServiceRequest))]
    public class CdmServiceRequestInput : ServiceRequestInput
    {
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto ScheduleType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> ServiceQueue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? ServiceQueuePosition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto ServiceQueuePriority { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> BookingSlot { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto ConsultServiceRequestStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TimeJoinedQue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TimeCancelled { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AllocatedTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> EncounterInitiated { get; set; }
	}
}
