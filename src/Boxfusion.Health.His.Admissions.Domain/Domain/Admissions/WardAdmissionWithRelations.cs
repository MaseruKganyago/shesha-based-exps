using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Admissions
{
	/// <summary>
	/// 
	/// </summary>
	public class WardAdmissionWithRelations
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardAdmission"></param>
		/// <param name="hospitalAdmission"></param>
		/// <param name="patient"></param>
		/// <param name="icdTenCodes"></param>
		/// <param name="separationIcdTenCodes"></param>
		public WardAdmissionWithRelations(WardAdmission wardAdmission, HospitalAdmission hospitalAdmission,
			HisPatient patient, List<IcdTenCode> icdTenCodes, List<IcdTenCode> separationIcdTenCodes = null)
		{
			WardAdmission = wardAdmission;
			HospitalAdmission = hospitalAdmission;
			Patient = patient;
			IcdTenCodes = icdTenCodes;
			SeparationIcdTenCodes = separationIcdTenCodes;
		}

		/// <summary>
		/// 
		/// </summary>
		public WardAdmission WardAdmission { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public HospitalAdmission HospitalAdmission { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public HisPatient Patient { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<IcdTenCode> IcdTenCodes { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<IcdTenCode>? SeparationIcdTenCodes { get; set; }
	}
}
