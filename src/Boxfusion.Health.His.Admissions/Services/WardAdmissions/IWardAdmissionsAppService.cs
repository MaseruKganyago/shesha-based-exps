using Abp.Application.Services;
using Boxfusion.Health.His.Common.Admissions;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.WardAdmissions
{
	/// <summary>
	/// 
	/// </summary>
	public interface IWardAdmissionsAppService: IApplicationService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<DynamicDto<WardAdmission, Guid>> AdmitPatientAsync(WardAdmissionsDto input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<DynamicDto<WardAdmission, Guid>> DischargePatientAsync(WardDischargeDto input);
	}
}
