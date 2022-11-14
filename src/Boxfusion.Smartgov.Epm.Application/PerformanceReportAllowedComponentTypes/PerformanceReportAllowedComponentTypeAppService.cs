using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm.Domain;
using Microsoft.AspNetCore.Mvc;
using SheshaBased.Epm.PerformanceReportAllowedComponentTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheshaBased.Epm.PerformanceReportAllowedComponentTypes
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Epm/[controller]")]
	public class PerformanceReportAllowedComponentTypesAppService : EpmAppServiceBase
	{
		private readonly IRepository<PerformanceReportAllowedComponentType, Guid> _repository;

		public PerformanceReportAllowedComponentTypesAppService(IRepository<PerformanceReportAllowedComponentType, Guid> repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]")]
		public async Task<List<FlattenedAllowedComponentTypesDto>> GetFlattenedAllowedComponentTypesByTemplateId(Guid id)
		{
			var entityList = await _repository.GetAllListAsync(a => a.PerformanceReportTemplate.Id == id);

			return ObjectMapper.Map<List<FlattenedAllowedComponentTypesDto>>(entityList);
		}
	}
}
