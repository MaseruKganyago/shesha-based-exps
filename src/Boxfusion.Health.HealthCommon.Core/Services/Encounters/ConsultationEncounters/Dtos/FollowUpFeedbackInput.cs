using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(ConsultationEncounter))]
	public class FollowUpFeedbackInput: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public bool FollowupIsFeelingBetter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FollowupSuggestion { get; set; }
	}
}
