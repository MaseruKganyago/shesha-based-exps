using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.ChargeItems
{
	/// <summary>
	/// 
	/// </summary>
	public class HisChargeItemsManager: DomainService
	{
		private readonly IRepository<HisChargeItem, Guid> _chargeItemRepository;
		private readonly IRepository<HisAccount, Guid> _accountRepository;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="chargeItemRepository"></param>
		/// <param name="accountRepository"></param>
		/// <param name="wardAdmissionRepository"></param>
		public HisChargeItemsManager(IRepository<HisChargeItem, Guid> chargeItemRepository,
			IRepository<HisAccount, Guid> accountRepository,
			IRepository<WardAdmission, Guid> wardAdmissionRepository)
		{
			_chargeItemRepository = chargeItemRepository;
			_accountRepository = accountRepository;
			_wardAdmissionRepository = wardAdmissionRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hisChargeItem"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> CreateChargeItemAsync(HisChargeItem hisChargeItem, RefListChargeItemStatus status = RefListChargeItemStatus.open)
		{
			if (hisChargeItem.Subject is not null && hisChargeItem.ContextEncounter is not null)
				//ContextEncouter is likely to be the HospitalAdmission
				hisChargeItem.Account = await GetPatientAccount(hisChargeItem.Subject.Id, hisChargeItem.ContextEncounter.Id);

			hisChargeItem.Status = (long?)status;
			return await _chargeItemRepository.InsertAsync(hisChargeItem);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentChargeItemId"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> ClosedAndOpenNewChargeItem(Guid currentChargeItemId)
		{
			var closedChargeItem = await CloseChargeItemAsync(currentChargeItemId);

			var newChargeItem = new HisChargeItem()
			{
				Subject = closedChargeItem.Subject,
				ContextEncounter = closedChargeItem.ContextEncounter,
				ServiceId = closedChargeItem.ServiceId,
				ServiceType = closedChargeItem.ServiceType,
				Code = closedChargeItem.Code,
				QuantityValue = closedChargeItem.ServiceType == (new WardAdmission()).GetTypeShortAlias() ? 
								null : closedChargeItem.QuantityValue,
			};

			return await CreateChargeItemAsync(newChargeItem);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentChargeItemId"></param>
		/// <returns></returns>
		/// <exception cref="UserFriendlyException"></exception>
		public async Task<HisChargeItem> CloseChargeItemAsync(Guid currentChargeItemId)
		{
			var chargeItem = await _chargeItemRepository.GetAsync(currentChargeItemId);

			chargeItem.Status = (long?)RefListChargeItemStatus.closed;

			if (chargeItem.ServiceType == (new WardAdmission()).GetTypeShortAlias())
			{
				var admission = await _wardAdmissionRepository.GetAsync(chargeItem.ServiceId);

				if (admission.StartDateTime == null) throw new UserFriendlyException($"Curremt WardAdmission does not have AdmissionDate.");

				var days = DateTime.Now.Subtract(admission.StartDateTime.Value).Days;
				chargeItem.QuantityValue = days;
			}

			return await _chargeItemRepository.UpdateAsync(chargeItem);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serviceId"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> GetOpenChargeItemByServiceIdAsync(Guid serviceId)
		{
			return await _chargeItemRepository.FirstOrDefaultAsync(a => a.ServiceId == serviceId
																	&& a.Status == (long?)RefListChargeItemStatus.open);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		public async Task<List<HisChargeItem>> GetPatientOpenChargeItems(Guid patientId)
		{
			return await _chargeItemRepository.GetAllListAsync(a => a.Subject.Id == patientId
																&& a.Status == (long?)RefListChargeItemStatus.open);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="billedDate"></param>
		/// <param name="chargeItem"></param>
		/// <returns></returns>
		public async Task UpdateChargeItemBilledDate(DateTime billedDate, HisChargeItem chargeItem)
		{
			chargeItem.LastBilledDate = billedDate;
			await _chargeItemRepository.UpdateAsync(chargeItem);
		}

		private async Task<HisAccount> GetPatientAccount(Guid patientId, Guid encounterId)
		{
			return await _accountRepository.FirstOrDefaultAsync(a => a.Subject.Id == patientId && a.Encounter.Id == encounterId);
		}
	}
}
