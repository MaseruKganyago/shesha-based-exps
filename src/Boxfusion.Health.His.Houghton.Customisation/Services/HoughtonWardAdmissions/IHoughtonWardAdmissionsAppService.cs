using Abp.Application.Services;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Houghton.Customisation.Services.Admissions;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Customisation.Services.HoughtonWardAdmissions
{
	/// <summary>
	/// 
	/// </summary>
	public interface IHoughtonWardAdmissionsAppService: IApplicationService
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
