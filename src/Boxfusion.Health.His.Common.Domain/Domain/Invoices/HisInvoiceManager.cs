using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds.BedOccupations;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using Boxfusion.Health.His.Common.Invoices;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Common.Products;
using NHibernate.Linq;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Invoices
{
	/// <summary>
	/// 
	/// </summary>
	public class HisInvoiceManager: DomainService
	{
		private readonly HisChargeItemsManager _hisChargeItemManager;
		private readonly BedOccupationManager _bedOccupationManager;
		private readonly IRepository<HisInvoiceLineItem, Guid> _hisInvoiceLineItemRepository;
		private readonly IRepository<HisInvoice, Guid> _hisInvoiceRepository;
		private readonly IRepository<HisAccount, Guid> _hisAccountRepository;
		private readonly IRepository<HisHealthFacility, Guid> _hisHealthFacility;
		private readonly IRepository<HisProduct, Guid> _hisProductRepository;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;
		private readonly IUnitOfWorkManager _unitOfWorkManager;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hisChargeItemManager"></param>
		/// <param name="bedOccupationManager"></param>
		/// <param name="hisInvoiceLineItemRepository"></param>
		/// <param name="hisHealthFacility"></param>
		/// <param name="hisAccountRepository"></param>
		/// <param name="hisProductRepository"></param>
		/// <param name="wardAdmissionRepository"></param>
		/// <param name="hisInvoiceRepository"></param>
		/// <param name="unitOfWorkManager"></param>
		public HisInvoiceManager(HisChargeItemsManager hisChargeItemManager,
			BedOccupationManager bedOccupationManager,
			IRepository<HisInvoiceLineItem, Guid> hisInvoiceLineItemRepository,
			IRepository<HisHealthFacility, Guid> hisHealthFacility,
			IRepository<HisAccount, Guid> hisAccountRepository,
			IRepository<HisProduct, Guid> hisProductRepository,
			IRepository<WardAdmission, Guid> wardAdmissionRepository,
			IRepository<HisInvoice, Guid> hisInvoiceRepository,
			IUnitOfWorkManager unitOfWorkManager)
		{
			_hisChargeItemManager = hisChargeItemManager;
			_bedOccupationManager = bedOccupationManager;
			_hisInvoiceLineItemRepository = hisInvoiceLineItemRepository;
			_hisHealthFacility = hisHealthFacility;
			_hisAccountRepository = hisAccountRepository;
			_hisProductRepository = hisProductRepository;
			_wardAdmissionRepository = wardAdmissionRepository;
			_hisInvoiceRepository = hisInvoiceRepository;
			_unitOfWorkManager = unitOfWorkManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientAccountId"></param>
		/// <param name="occurenceDate"></param>
		/// <param name="hisChargeItems"></param>
		/// <returns></returns>
		public async Task<HisInvoice> SplitPatientBill(Guid patientAccountId, DateTime occurenceDate, List<HisChargeItem> hisChargeItems)
		{
			var account = await _hisAccountRepository.GetAllIncluding(a => a.Subject)
													.Where(a => a.Id == patientAccountId).FirstOrDefaultAsync();

			var newInvoice = new HisInvoice()
			{
				InvoiceDate = occurenceDate,
				IssuedBy = await GetCurentFacility(),
				IssuedToPerson = account.Subject,
				Account = account
			};
			var invoice = await _hisInvoiceRepository.InsertAsync(newInvoice);

			var billedItemTask = new List<Task>();
			hisChargeItems.ForEach(charge => billedItemTask.Add(CreateBilledItem(charge, occurenceDate, invoice)));
			await Task.WhenAll(billedItemTask);

			return invoice;
		}

		private async Task CreateBilledItem(HisChargeItem charge, DateTime occurenceDate, HisInvoice invoice)
		{
			using (var uow = _unitOfWorkManager.Begin())
			{
				await _hisChargeItemManager.UpdateChargeItemBilledDate(occurenceDate, charge);
				
				var product = await _hisProductRepository.FirstOrDefaultAsync(a => a.ProductCode == charge.Code);

				int localQuantity;
				if (charge.ServiceType == (new WardAdmission()).GetTypeShortAlias())
					localQuantity = (int)await _bedOccupationManager.GetQuantityFromBedOccupationAsync(charge);
				else localQuantity = (int)charge.QuantityValue;

				var newInvoiceLineItem = new HisInvoiceLineItem()
				{
					Invoice = invoice,
					Product = product,
					Quantity = localQuantity
				};

				await _hisInvoiceLineItemRepository.InsertAsync(newInvoiceLineItem);
				await uow.CompleteAsync();
			}
		}

		private async Task<HisHealthFacility> GetCurentFacility()
		{
			HisHealthFacility facility = null;
			if (RequestContextHelper.HasFacilityId)
			{
				var facilityId = RequestContextHelper.FacilityId;
				facility = await _hisHealthFacility.GetAsync(facilityId);
			}

			return facility;
		}
	}
}
