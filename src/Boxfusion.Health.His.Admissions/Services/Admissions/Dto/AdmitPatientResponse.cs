using Abp.Application.Services.Dto;
using Boxfusion.Health.His.Domain.Dtos;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
	/// <summary>
	/// 
	/// </summary>
	public class AdmitPatientResponse: EntityDto<Guid?>
	{
		/// <summary>
		/// 
		/// </summary>
		public HisPatientResponse Patient { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public WardAdmissionResponse WardAdmission { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public HospitalAdmissionResponse HospitalAdmission { get; set; }
	}
}
