using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm.Domain;
using Microsoft.AspNetCore.Mvc;
using Shesha.Utilities;
using SheshaBased.Epm.PerformanceReportAllowedComponentTypes.Dtos;
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
			var aIconLevelNum = Int32.Parse(StringHelper.Right(aIconLevel, 1));

			var bIconLevel = b.Icon;
			var bIconLevelNum = Int32.Parse(StringHelper.Right(bIconLevel, 1));

			return aIconLevelNum > bIconLevelNum;
		}
	}
}
