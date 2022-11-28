using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Smartgov.Epm.Domain.ComponentProgressReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Components
{
	/// <summary>
	/// 
	/// </summary>
	public class ComponentEntityChangingEventHandler: IEventHandler<EntityChangingEventData<Component>>, ITransientDependency
	{
		private readonly IRepository<Component, Guid> _repository;
		private readonly ComponentProgressReportManager _componentProgressReportManager;

		/// <summary>
		/// 
		/// </summary>
		public ComponentEntityChangingEventHandler(IRepository<Component, Guid> repository,
			ComponentProgressReportManager componentProgressReportManager)
		{
			_repository = repository;
			_componentProgressReportManager = componentProgressReportManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public async void HandleEvent(EntityChangingEventData<Component> eventData)
		{
			var entity = eventData.Entity;
			var componentType = entity.ComponentType;

			var isCreated = (await _repository.GetAllListAsync(a => a.Id == entity.Id)).Any();
			var isLevel5Icon = componentType.Icon == EpmDomainConsts.IconLevel5;
			if (isCreated || !isLevel5Icon)
				return;

			await _componentProgressReportManager.GenerateComponentProgressReportsForComponentAsync(entity);
		}
	}
}
