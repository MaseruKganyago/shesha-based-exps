using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Domain.Domain.Products;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Common.Procedures;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Procedures
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcedureChangedEventHandler: IEventHandler<EntityChangedEventData<HisProcedure>>, ITransientDependency
	{
		private readonly HisChargeItemManager _hisChargeItemManager;

		/// <summary>
		/// 
		/// </summary>
		public ProcedureChangedEventHandler(HisChargeItemManager hisChargeItemManager)
		{
			_hisChargeItemManager = hisChargeItemManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public async void HandleEvent(EntityChangedEventData<HisProcedure> eventData)
		{
			var entity = eventData.Entity;

			var productCode = await ProductsHelper.GetProductCode(entity.ProcedureService.Id);

			var chargeItem = new HisChargeItem()
			{
				Subject = entity.Subject,
				ContextEncounter = entity.Encounter,
				ServiceId = entity.Id,
				ServiceType = entity.GetTypeShortAlias(),
				QuantityValue = 1,
				Code = productCode,
			};

			await _hisChargeItemManager.CreateChargeItem(chargeItem);
		}
	}
}
