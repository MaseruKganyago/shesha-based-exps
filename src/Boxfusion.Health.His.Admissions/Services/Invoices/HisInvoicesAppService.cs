using Abp.Authorization;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Invoices;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Invoices
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/His/[controller]")]
	public class HisInvoicesAppService: SheshaAppServiceBase
	{
		private readonly HisInvoiceManager _invoiceManager;
		private readonly HisChargeItemsManager _chargeItemsManager;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="invoiceManager"></param>
		/// <param name="chargeItemsManager"></param>
		public HisInvoicesAppService(HisInvoiceManager invoiceManager, HisChargeItemsManager chargeItemsManager)
		{
			_invoiceManager = invoiceManager;
			_chargeItemsManager = chargeItemsManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("action")]
		public async Task<DynamicDto<HisInvoice, Guid>> GenerateSplitBillInvoice(SplitBillInvoiceDto input)
		{
			var chargeItems = new List<HisChargeItem>();

			foreach (var id in input.ChargeItemIds)
			{
				var chargeItem = await _chargeItemsManager.repository().GetAsync(id);
				chargeItems.Add(chargeItem);
			}

			var invoiceEntity = await _invoiceManager.SplitPatientBill(input.PatientAccountId, 
																	   input.OccurenceDate, chargeItems);

			return await MapToDynamicDtoAsync<HisInvoice, Guid>(invoiceEntity);
		}
	}
}
