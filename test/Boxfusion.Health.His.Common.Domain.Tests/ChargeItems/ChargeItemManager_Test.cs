using Abp.Domain.Repositories;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Common.Procedures;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Common.Tests.ChargeItems
{
	public class ChargeItemManager_Test: HisCommonDomainTestBase
	{
		private readonly HisChargeItemsManager _chargeItemsManager;
		private readonly IRepository<HisChargeItem, Guid> _chargeItemRepository;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;

		public ChargeItemManager_Test(): base()
		{
			_chargeItemsManager = Resolve<HisChargeItemsManager>();
			_chargeItemRepository = Resolve<IRepository<HisChargeItem, Guid>>();
			_wardAdmissionRepository = Resolve<IRepository<WardAdmission, Guid>>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Should_Split_Patient_Bill_Finalize_current_ChargeItems_then_add_new_ChargeItems()
		{
			#region Prepare data for patient Split-Billing
			var patient = await CreateTestData_NewPatient("John Dave: Unit Test");

			await CreateTestsData_NewPatientChargeItems(patient);
			#endregion
		}

		private async Task CreateTestsData_NewPatientChargeItems(HisPatient patient)
		{
			var chargeItem1 = new HisChargeItem()
			{
				Subject = patient,
				ServiceId = Guid.NewGuid(),
				ServiceType = (new HisProcedure()).GetTypeShortAlias(),
				QuantityValue = 1,
				//Status = (long?)RefListChargeItemStatus.inProgress,
			};

			await _chargeItemRepository.InsertAsync(chargeItem1);

			var admission = await _wardAdmissionRepository.InsertAsync(new WardAdmission() 
			{
				Subject = patient,
				WardAdmissionStatus = RefListWardAdmissionStatuses.admitted,
				StartDateTime = DateTime.Now.AddDays(-2), //Back track date for chargeItem quantityValue
			});

			var chargeItem2 = new HisChargeItem()
			{
				Subject = patient,
				ContextEncounter = admission,
				ServiceId = admission.Id,
				ServiceType = admission.GetTypeShortAlias(),
			};

			await _chargeItemRepository.InsertAsync(chargeItem2);
		}
	}
}
