using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
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
	[AutoMap(typeof(ReferralServiceRequest))]
	public class ReferralServiceRequestResponse : CdmServiceRequestResponse
	{
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Department { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ReferralReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Comment { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ReceivingPractitioner { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ReferralLetterPath { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Guid FileId { get; set; }
	}
}
