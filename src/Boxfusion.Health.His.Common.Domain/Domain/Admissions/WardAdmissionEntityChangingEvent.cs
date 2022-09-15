using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.Beds.BedFees;
using Boxfusion.Health.His.Common.Beds.BedFees.Enums;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using Boxfusion.Health.His.Common.Domain.Domain.Products;
using Boxfusion.Health.His.Common.Enums;
using NHibernate.Linq;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Admissions
{
	/// <summary>
	/// 
	/// </summary>
	public class WardAdmissionEntityChangingEvent: IEventHandler<EntityChangingEventData<WardAdmission>>, ITransientDependency
	{
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;
		private readonly BedFeeManager _bedFeeManager;
		private readonly HisChargeItemsManager _chargeItemManager;
		private readonly IRepository<Bed, Guid> _bedRepository;

		/// <summary>
		/// 
		/// </summary>
		public WardAdmissionEntityChangingEvent(IRepository<WardAdmission, Guid> wardAdmissionRepository, 
			BedFeeManager bedFeeManager, HisChargeItemsManager chargeItemManager, IRepository<Bed, Guid> bedRepository)
		{
			_wardAdmissionRepository = wardAdmissionRepository;
			_bedFeeManager = bedFeeManager;
			_chargeItemManager = chargeItemManager;
			_bedRepository = bedRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public async void HandleEvent(EntityChangingEventData<WardAdmission> eventData)
		{
			var entity = eventData.Entity;

			var dbAdmission = await _wardAdmissionRepository.FirstOrDefaultAsync(a => a.Id == entity.Id);

			if (dbAdmission is not null)
			{
				#region Then wardAdmission is being updated...
				var currentBedFee = await _bedFeeManager.repository()
						.FirstOrDefaultAsync(a => a.WardAdmission.Id == dbAdmission.Id
						&& a.Status == (long?)RefListBedFeeStatus.open);

				var chargeItem = await _chargeItemManager.repository()
														.FirstOrDefaultAsync(a => a.ServiceId == dbAdmission.Id
														&& a.Status == (long?)RefListChargeItemStatus.open);

				//Handles bedFees-chargedItem upon change of bed in wardAdmission
				if (dbAdmission.Bed.Id != entity.Bed.Id && entity.AdmissionStatus == RefListAdmissionStatuses.admitted)
				{
					await _bedFeeManager.CloseAndOpenNewBedFeeAsync(currentBedFee, chargeItem);
				}
				else
				{
					//Closes bedFees-chargedItem upon discharge
					if (entity.AdmissionStatus == RefListAdmissionStatuses.separated)
					{
						await _bedFeeManager.CloseBedFeeAsync(currentBedFee);
						await _chargeItemManager.CloseChargeItemAsync(chargeItem);
					}
				}
				#endregion
			}
			else
			{
				//Create new chargedItem and bedFee for admission into ward
				var chargeItem = await CreateWardAdmissionChargeItem(entity);

				var newBedFee = new BedFee()
				{
					StartDate = entity.StartDateTime,
					WardAdmission = entity,
					Bed = entity.Bed,
					ChargeItem = chargeItem
				};
				await _bedFeeManager.CreateBedFeeAsync(newBedFee);
			}
		}

		private async Task<HisChargeItem> CreateWardAdmissionChargeItem(WardAdmission wardAdmissionEntity)
		{
			var bedList = await _bedRepository.GetAllIncluding(a => a.BedType)
											  .Where(a => a.Id == wardAdmissionEntity.Bed.Id).ToListAsync();
			var bed = bedList.FirstOrDefault();

			var productCode = await ProductsHelper.GetProductCode(bed.BedType.Id);

			var chargeItem = new HisChargeItem()
			{
				Subject = wardAdmissionEntity.Subject,
				ContextEncounter = wardAdmissionEntity.PartOf,
				ServiceId = wardAdmissionEntity.Id,
				ServiceType = wardAdmissionEntity.GetTypeShortAlias(),
				Code = productCode
			};

			return await _chargeItemManager.CreateChargeItemAsync(chargeItem);
		}
	}
}
