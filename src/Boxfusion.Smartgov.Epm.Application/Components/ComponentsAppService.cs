using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm.Components.Dtos;
using Boxfusion.Smartgov.Epm.Domain;
using Boxfusion.Smartgov.Epm.Domain.ComponentProgressReport;
using Boxfusion.Smartgov.Epm.Domain.Components;
using Microsoft.AspNetCore.Mvc;
using Shesha.Utilities;
using System.Text.Json;

namespace Boxfusion.Smartgov.Epm.Components
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Epm/[controller]")]
	public class ComponentsAppService : EpmAppServiceBase
	{
		private readonly IRepository<Component, Guid> _repository;
		private readonly IRepository<ComponentType, Guid> _componentTypeRepository;
		private readonly IRepository<ComponentProgressReport, Guid> _componentProgressReportReporsitory;

		public ComponentsAppService(IRepository<Component, Guid> repository, 
			IRepository<ComponentType, Guid> componentTypeRepository,
			IRepository<ComponentProgressReport, Guid> componentProgressReportReporsitory)
		{
			_repository = repository;
			_componentTypeRepository = componentTypeRepository;
			_componentProgressReportReporsitory = componentProgressReportReporsitory;
		}

		/// <summary>
		/// Temporary unOptimzed, just to allow front-end building flow
		/// </summary>
		/// <returns></returns>
		[AbpAllowAnonymous]
		[HttpGet, Route("[action]")]
		public async Task<string> GetTreeDataJson(Guid performanceReportId)
		{
			var components = await _repository.GetAllListAsync(a => a.PerformanceReport.Id == performanceReportId);
			var filteredComponents = components.Where(a => a.ComponentType.Icon == "level-1").ToList();

			var treeDataList = await MapComponentsToTreeDataList(filteredComponents);
			var orderedList = treeDataList.OrderBy(a => a.OrderIndex).ToList();

			var serializeOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};

			return System.Text.Json.JsonSerializer.Serialize(orderedList, serializeOptions);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="componentProgressReportId"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]")]
		public async Task<ComponentReportingDto> GetComponentReportingDetails(Guid id)
		{
			var report = await _componentProgressReportReporsitory.GetAsync(id);

			var path = await ComponentsHelper.GetComponentNodePath(report.Component.Id);

			return new ComponentReportingDto()
			{
				NodeName = report.Component.Name,
				NodePath = path.Left(path.Length -1),
				Id = report.Id,
				ComponentProgressReport = await MapToDynamicDtoAsync<ComponentProgressReport, Guid>(report)
			};
		}

		private async Task<List<TreeDataDto>> MapComponentsToTreeDataList(List<Component> components)
		{
			var treeDataList = new List<TreeDataDto>();

			foreach (var item in components)
			{
				var componentType = await _componentTypeRepository.GetAsync(item.ComponentType.Id);

				treeDataList.Add(new TreeDataDto()
				{
					Title = item.Name,
					Key = item.Id,
					AdminTreeCreateForm = componentType.AdminTreeCreateForm,
					IconLevel = componentType.Icon,
					Parent = item.Parent?.Id,
					OrderIndex = item.OrderIndex,
					ComponentType = item.ComponentType?.Id,
					PerformanceReport = item.PerformanceReport?.Id,
					Children = await GetChildrenComponents(item.Id),
				});
			}

			return treeDataList;
		}

		private async Task<List<TreeDataDto>> GetChildrenComponents(Guid parentId)
		{
			var childrenList = await _repository.GetAllListAsync(a => a.Parent.Id == parentId);

			if (!childrenList.Any()) return null;

			return await MapComponentsToTreeDataList(childrenList);
		}
	}
}
