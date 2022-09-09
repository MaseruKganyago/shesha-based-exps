using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.ChargeItems
{
	/// <summary>
	/// 
	/// </summary>
	public class HisChargeItemManager: DomainService
	{
		private readonly IRepository<HisChargeItem, Guid> _chargeItemRepository;
		private readonly IRepository<HisAccount, Guid> _accountRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="chargeItemRepository"></param>
		/// <param name="accountRepository"></param>
		public HisChargeItemManager(IRepository<HisChargeItem, Guid> chargeItemRepository, IRepository<HisAccount, Guid> accountRepository)
		{
			_chargeItemRepository = chargeItemRepository;
			_accountRepository = accountRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hisChargeItem"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> CreateChargeItem(HisChargeItem hisChargeItem)
		{
			var result = new HisChargeItem();
			using (var uow = UnitOfWorkManager.Begin())
			{
				if (hisChargeItem.Subject is not null && hisChargeItem.ContextEncounter is not null)
					hisChargeItem.Account = await GetPatientAccount(hisChargeItem.Subject.Id, hisChargeItem.ContextEncounter.Id);

				result = await _chargeItemRepository.InsertAsync(hisChargeItem);

				await uow.CompleteAsync();
			}

			return result;
		}

		public async Task<HisChargeItem> UpdateChargeItem(HisChargeItem hisChargeItem)
		{
			var result = new HisChargeItem();
			
				if (hisChargeItem.Account is null)
				{
					if (hisChargeItem.Subject is not null && hisChargeItem.ContextEncounter is not null)
						hisChargeItem.Account = await GetPatientAccount(hisChargeItem.Subject.Id, hisChargeItem.ContextEncounter.Id);
				}

				result = await _chargeItemRepository.UpdateAsync(hisChargeItem);

				 
			
			 
			return result;
		}

		private async Task<HisAccount> GetPatientAccount(Guid patientId, Guid encounterId)
		{
			return await _accountRepository.FirstOrDefaultAsync(a => a.Subject.Id == patientId && a.Encounter.Id == encounterId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serviceId"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> GetInProgressChargeItem(Guid serviceId)
		{
			return await _chargeItemRepository.FirstOrDefaultAsync(a => a.ServiceId == serviceId 
																	&& a.Status == (long?)RefListChargeItemStatus.inProgress);
		}
	}
}
