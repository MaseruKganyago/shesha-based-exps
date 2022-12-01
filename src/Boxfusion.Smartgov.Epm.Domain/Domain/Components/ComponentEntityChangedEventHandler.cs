using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports;
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
	public class ComponentEntityChangedEventHandler: IEventHandler<EntityChangedEventData<Component>>, ITransientDependency
	{
		private readonly IRepository<Component, Guid> _repository;
		private readonly ComponentProgressReportManager _componentProgressReportManager;
		private readonly IUnitOfWorkManager _uowManager;

		/// <summary>
		/// 
		/// </summary>
		public ComponentEntityChangedEventHandler(IRepository<Component, Guid> repository,
			ComponentProgressReportManager componentProgressReportManager,
			IUnitOfWorkManager uowManager)
		{
			_repository = repository;
			_componentProgressReportManager = componentProgressReportManager;
			_uowManager = uowManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public async void HandleEvent(EntityChangedEventData<Component> eventData)
		{
			using (var uow = _uowManager.Begin())
			{
				var entity = eventData.Entity;
				var componentType = entity.ComponentType;

				var isOnCreate = !(await _componentProgressReportManager.repository()
								.GetAllListAsync(a => a.Component.Id == entity.Id)).Any();

				if (!isOnCreate) return;

				var isLevel5Icon = componentType.Icon == EpmDomainConsts.IconLevel5;
				if (!isLevel5Icon)
					return;

				await _componentProgressReportManager.GenerateComponentProgressReportsForComponentAsync(entity);

				await uow.CompleteAsync();
			}
		}
	}
}
