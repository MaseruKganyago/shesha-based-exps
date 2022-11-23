using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm;
using Boxfusion.Smartgov.Epm.Domain;
using Boxfusion.Smartgov.Epm.Domain.Components;
using Boxfusion.Smartgov.Epm.PerformanceReportAllowedComponentTypes.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shesha.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.PerformanceReportAllowedComponentTypes
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
		private readonly IRepository<Component, Guid> _componentRepository;

		public PerformanceReportAllowedComponentTypesAppService(IRepository<PerformanceReportAllowedComponentType, Guid> repository, IRepository<Component, Guid> componentRepository)
		{
			_repository = repository;
			_componentRepository = componentRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]")]
		public async Task<List<FlattenedAllowedComponentTypesDto>> GetFlattenedAllowedComponentTypesByTemplateId(Guid id, Guid? parentComponentId)
		{
			var entityList = await _repository.GetAllListAsync(a => a.PerformanceReportTemplate.Id == id);

			if (parentComponentId == null) return ObjectMapper.Map<List<FlattenedAllowedComponentTypesDto>>(entityList);

			var component = await _componentRepository.GetAsync((Guid)parentComponentId);
			var filteredList = entityList.Where(a => compareIconLevel(a.ComponentType, component.ComponentType)).ToList();

			return ObjectMapper.Map<List<FlattenedAllowedComponentTypesDto>>(filteredList);
		}

		private bool compareIconLevel(ComponentType a, ComponentType b)
		{
			//var strLength = "level-".Length;

			var aIconLevel = a.Icon;
			var aIconLevelNum = int.Parse(aIconLevel.Right(1));

			var bIconLevel = b.Icon;
			var bIconLevelNum = int.Parse(bIconLevel.Right(1));

			return aIconLevelNum > bIconLevelNum;
		}
	}
}
