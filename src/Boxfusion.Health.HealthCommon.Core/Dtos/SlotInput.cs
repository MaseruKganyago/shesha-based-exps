using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.AutoMapper.Dto;
using Shesha.Domain.Attributes;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(Slot))]
	public class SlotInput
	{
		/// <summary>
		/// 
		/// </summary>
		public string Identifier { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> ServiceCategory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		
		public List<ReferenceListItemValueDto> ServiceType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		
		public List<ReferenceListItemValueDto> Speciality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		
		public ReferenceListItemValueDto AppointmentType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> Schedule { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDateTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDateTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool Overbooked { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Comment { get; set; }
	}
}