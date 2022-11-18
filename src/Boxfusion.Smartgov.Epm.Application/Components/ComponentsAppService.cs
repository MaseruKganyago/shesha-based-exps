using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SheshaBased.Epm.Components.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SheshaBased.Epm.Components
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Epm/[controller]")]
	public class ComponentsAppService: EpmAppServiceBase
	{
		private readonly IRepository<Component, Guid> _repository;
		private readonly IRepository<ComponentType, Guid> _componentTypeRepository;

		public ComponentsAppService(IRepository<Component, Guid> repository, IRepository<ComponentType, Guid> componentTypeRepository)
		{
			_repository = repository;
			_componentTypeRepository = componentTypeRepository;
		}

		/// <summary>
		/// Temporary unpotimzed, just to allow front-end building flow
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("[action]")]
		public async Task<string> GetTreeDataJson()
		{
			var components = await _repository.GetAllListAsync();
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
