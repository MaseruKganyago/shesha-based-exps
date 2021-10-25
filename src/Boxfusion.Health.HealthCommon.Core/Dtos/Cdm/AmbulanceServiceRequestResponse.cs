using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
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
	[AutoMap(typeof(AmbulanceServiceRequest))]
	public class AmbulanceServiceRequestResponse: CdmServiceRequestResponse
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual CdmAddressResponse PickUpAddress { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto ProvisionalCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Comment { get; set; }
	}
}
