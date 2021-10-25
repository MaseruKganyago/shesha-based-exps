using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(Content))]
	public class ContentResponse: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto Format { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> Attachment { get; set; }
	}
}
