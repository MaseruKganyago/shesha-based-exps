using Abp.Application.Services.Dto;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(ConsultationEncounter))]
	public class FollowUpInput: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto FollowUpDay { get; set; }
	}
}
