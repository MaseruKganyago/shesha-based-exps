using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.His.Common.Accounts;
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
			if (hisChargeItem.Subject is not null && hisChargeItem.ContextEncounter is not null)
			hisChargeItem.Account = await GetPatientAccount(hisChargeItem.Subject.Id, hisChargeItem.ContextEncounter.Id);

			return await _chargeItemRepository.InsertAsync(hisChargeItem);
		}

		private async Task<HisAccount> GetPatientAccount(Guid patientId, Guid encounterId)
		{
			return await _accountRepository.FirstOrDefaultAsync(a => a.Subject.Id == patientId && a.Encounter.Id == encounterId);
		}
	}
}
