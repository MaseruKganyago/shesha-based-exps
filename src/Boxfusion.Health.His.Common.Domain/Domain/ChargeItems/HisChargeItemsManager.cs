﻿using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds.BedOccupations;
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
		private readonly BedOccupationManager _bedOccupationManager;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="chargeItemRepository"></param>
		/// <param name="accountRepository"></param>
		/// <param name="wardAdmissionRepository"></param>
		/// <param name="bedOccupationManager"></param>
		public HisChargeItemsManager(IRepository<HisChargeItem, Guid> chargeItemRepository,
			IRepository<HisAccount, Guid> accountRepository,
			IRepository<WardAdmission, Guid> wardAdmissionRepository,
			BedOccupationManager bedOccupationManager)
		{
			_chargeItemRepository = chargeItemRepository;
			_accountRepository = accountRepository;
			_wardAdmissionRepository = wardAdmissionRepository;
			_bedOccupationManager = bedOccupationManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IRepository<HisChargeItem, Guid> repository()
		{
			return _chargeItemRepository;
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

			hisChargeItem.Status = status;
			return await _chargeItemRepository.InsertAsync(hisChargeItem);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentChargeItem"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> ClosedAndOpenNewChargeItemAsync(HisChargeItem currentChargeItem)
		{
			var closedChargeItem = await CloseChargeItemAsync(currentChargeItem);

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
		/// <param name="currentChargeItem"></param>
		/// <returns></returns>
		/// <exception cref="UserFriendlyException"></exception>
		public async Task<HisChargeItem> CloseChargeItemAsync(HisChargeItem currentChargeItem)
		{
			currentChargeItem.Status = RefListChargeItemStatus.closed;

			if (currentChargeItem.ServiceType == (new WardAdmission()).GetTypeShortAlias())
				currentChargeItem.QuantityValue = await _bedOccupationManager.GetQuantityFromBedOccupationAsync(currentChargeItem);

			return await _chargeItemRepository.UpdateAsync(currentChargeItem);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serviceId"></param>
		/// <returns></returns>
		public async Task<HisChargeItem> GetOpenChargeItemByServiceIdAsync(Guid serviceId)
		{
			return await _chargeItemRepository.FirstOrDefaultAsync(a => a.ServiceId == serviceId
																	&& a.Status == RefListChargeItemStatus.open);
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