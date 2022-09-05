using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Runtime.Validation;
using Abp.UI;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds
{
	/// <summary>
	/// 
	/// </summary>
	public class BedEntityChangingEventHandler: IEventHandler<EntityChangingEventData<Bed>>, ITransientDependency
	{
		/// <summary>
		/// 
		/// </summary>
		public BedEntityChangingEventHandler()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public void HandleEvent(EntityChangingEventData<Bed> eventData)
		{
			var entity = eventData.Entity;
			var roomsRepo = StaticContext.IocManager.Resolve<IRepository<Room, Guid>>();
			var bedsRepo = StaticContext.IocManager.Resolve<IRepository<Bed, Guid>>();

			if (bedsRepo.GetAllList(a => a.Id == entity.Id).Any()) return;

			if (!(roomsRepo.Get(entity.Room.Id).NumberOfBeds > bedsRepo.GetAllList(a => a.Room.Id == entity.Room.Id).Count))
				throw new UserFriendlyException("Room has reached maximum number of Beds capacity.");

		}
	}
}
