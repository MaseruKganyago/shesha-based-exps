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
    public class CdmServiceRequestResponse : ServiceRequestResponse
    {
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto ScheduleType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> ServiceQueue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ServiceQueuePosition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto ServiceQueuePriority { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> BookingSlot { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto ConsultServiceRequestStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? TimeJoinedQue { get; set; }
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
		public virtual EntityWithDisplayNameDto<Guid?> EncounterInitiated { get; set; }
	}
}
