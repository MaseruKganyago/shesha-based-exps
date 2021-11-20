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
	public class AdmitPatientInput: EntityDto<Guid?>
	{
		/// <summary>
		/// 
		/// </summary>
		public HisPatientInput Patient { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public WardAdmissionInput WardAdmission { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public HospitalAdmissionInput HospitalAdmission { get; set; }
	}
}
