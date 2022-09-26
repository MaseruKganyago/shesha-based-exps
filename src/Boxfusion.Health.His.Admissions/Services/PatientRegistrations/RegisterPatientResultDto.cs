using Abp.Application.Services.Dto;
using Boxfusion.Health.His.Common.Patients;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.PatientRegistrations
{
	/// <summary>
	/// 
	/// </summary>
	public class RegisterPatientResultDto: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public DynamicDto<HisPatient, Guid> Patient { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Guid HospitalAdmissionId { get; set; }
	}
}
