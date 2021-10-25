using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
	/// <summary>
	/// 
	/// </summary>
    [AutoMap(typeof(ChwVisitServiceRequest))]
    public class ChwVisitServiceRequestsResponse : CdmServiceRequestResponse
	{
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto VisitType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool IsSampleCollection { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool IsMedicationDelivery { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? VisitDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public TimeSpan? VisitTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Comment { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Address { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> VisitTasks { get; set; }
	}
}
