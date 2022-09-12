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
		/// <returns></returns>
		public async Task<HisChargeItem> CreateChargeItem(HisChargeItem hisChargeItem)
		{
			if (hisChargeItem.Subject is not null && hisChargeItem.ContextEncounter is not null)
				hisChargeItem.Account = await GetPatientAccount(hisChargeItem.Subject.Id, hisChargeItem.ContextEncounter.Id);

			return await _chargeItemRepository.InsertAsync(hisChargeItem);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hisChargeItem"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		public async Task SplitPatientBill(Guid patientId)
		{
			var patientChargeItems = await _chargeItemRepository.GetAllListAsync(a => a.Subject.Id == patientId
																				&& a.Status == (long?)RefListChargeItemStatus.inProgress);

			var finalizeChargeItemsTasks = new List<Task>();
			patientChargeItems.ForEach(charge => finalizeChargeItemsTasks.Add(FinalizaChargeItem(charge)));

			var newPatientChargeItemsTasks = new List<Task>();
			patientChargeItems.ForEach(charge =>
			{
				newPatientChargeItemsTasks.Add(CreateNewPatientChargeItem(charge));
			});

			await Task.WhenAll(finalizeChargeItemsTasks);
			await Task.WhenAll(newPatientChargeItemsTasks);
		}

		private async Task CreateNewPatientChargeItem(HisChargeItem charge)
		{
			var newChargeItem = new HisChargeItem()
			{
				Subject = charge.Subject,
				ContextEncounter = charge.ContextEncounter,
				ServiceId = charge.ServiceId,
				ServiceType = charge.ServiceType,
				QuantityValue = charge.QuantityValue,
				Code = charge.Code,
			};

			await CreateChargeItem(newChargeItem);
		}

		private async Task FinalizaChargeItem(HisChargeItem charge)
		{
			using (var uow = UnitOfWorkManager.Begin())
			{
				charge.Status = (long?)RefListChargeItemStatus.finalized;

				if (charge.ServiceType == (new WardAdmission()).GetTypeShortAlias())
				{
					var admission = await _wardAdmissionRepository.GetAsync(charge.ServiceId);

					if (admission.StartDateTime == null) throw new UserFriendlyException($"Curremt WardAdmission does not have AdmissionDate.");

					var days = DateTime.Now.Subtract(admission.StartDateTime.Value).Days;
					charge.QuantityValue = days;
				}

				await _chargeItemRepository.UpdateAsync(charge);

				await uow.CompleteAsync();
			}
		}
	}
}
