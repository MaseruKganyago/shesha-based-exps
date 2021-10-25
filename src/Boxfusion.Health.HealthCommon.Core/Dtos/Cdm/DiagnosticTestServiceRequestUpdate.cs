using Abp.AutoMapper;
using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
	/// <summary>
	/// 
	/// </summary>
    [AutoMap(typeof(DiagnosticTestServiceRequest))]
    public class DiagnosticTestServiceRequestUpdate : CdmServiceRequestInput
	{
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ScheduledVisitDate { get; set; }
		///// <summary>
		///// 
		///// </summary>
		//public TimeSpan? ScheduledVisitTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool DiagnosticTestRequired { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> ExaminationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> ExamReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Comment { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> FacilityType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Guid FileId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Guid DocumentId { get; set; }
	}
}
