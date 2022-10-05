using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
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
    public class HisProcedureChangedEventHandler: IEventHandler<EntityChangedEventData<HisProcedure>>, ITransientDependency
	{
		private readonly HisChargeItemsManager _hisChargeItemManager;
		private readonly IUnitOfWorkManager _unitOfWork;

		/// <summary>
		/// 
		/// </summary>
		public HisProcedureChangedEventHandler(HisChargeItemsManager hisChargeItemManager, IUnitOfWorkManager unitOfWork)
		{
			_hisChargeItemManager = hisChargeItemManager;
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public async void HandleEvent(EntityChangedEventData<HisProcedure> eventData)
		{
			var entity = eventData.Entity;

			var productCode = await ProductsHelper.GetProductCode(entity.ProcedureService.Id);

			using (var uow = _unitOfWork.Begin())
			{
				var currentChargeItem = await _hisChargeItemManager.GetOpenChargeItemByServiceIdAsync(entity.Id);

				if (currentChargeItem is not null)
				{
					if (currentChargeItem?.Code != productCode)
					{
						var chargeItem = new HisChargeItem()
						{
							Subject = entity.Subject,
							ContextEncounter = entity.Encounter.PartOf ?? entity.Encounter,
							ServiceId = entity.Id,
							ServiceType = entity.GetTypeShortAlias(),
							QuantityValue = 1,
							Code = productCode,
						};
						await _hisChargeItemManager.CreateChargeItemAsync(chargeItem, RefListChargeItemStatus.closed);
					}
					else { await uow.CompleteAsync(); return; }
				}
				else
				{
					var chargeItem = new HisChargeItem()
					{
						Subject = entity.Subject,
						ContextEncounter = entity.Encounter.PartOf ?? entity.Encounter,
						ServiceId = entity.Id,
						ServiceType = entity.GetTypeShortAlias(),
						QuantityValue = 1,
						Code = productCode,
					};
					await _hisChargeItemManager.CreateChargeItemAsync(chargeItem);
				}

				await uow.CompleteAsync();
			}
		}
	}
}
