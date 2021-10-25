using Abp.Application.Services;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.IcdTenCodes
{
	/// <summary>
	/// 
	/// </summary>
	public interface IIcdTenCodeAppService: IApplicationService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="term"></param>
		/// <returns></returns>
		Task<List<EntityWithDisplayNameDto<Guid>>> IcdTenCodesAutoCompleteList(string term);
	}
}
