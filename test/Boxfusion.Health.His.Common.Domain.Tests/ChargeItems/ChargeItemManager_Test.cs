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
using Shouldly;
using Abp.Domain.Uow;

namespace Boxfusion.Health.His.Common.Tests.ChargeItems
{
	public class ChargeItemManager_Test: HisCommonDomainTestBase
	{
		private readonly HisChargeItemsManager _chargeItemsManager;
		private readonly IRepository<HisChargeItem, Guid> _chargeItemRepository;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;
		private readonly IUnitOfWorkManager _unitOfWorkManager;

		public ChargeItemManager_Test(): base()
		{
			_chargeItemsManager = Resolve<HisChargeItemsManager>();
			_chargeItemRepository = Resolve<IRepository<HisChargeItem, Guid>>();
			_wardAdmissionRepository = Resolve<IRepository<WardAdmission, Guid>>();
			_unitOfWorkManager = Resolve<IUnitOfWorkManager>();

		}

		[Fact]
		public async Task Should_Create_Charge_Item()
		{
			//testdata
			HisPatient patient = await CreateTestData_NewPatient("John Dave: Unit Test");
			HisChargeItem chargeItem = null;
			try {


				var newChargeItem = new HisChargeItem()
				{
					Subject = patient,
					ServiceId = Guid.NewGuid(),
					ServiceType = (new HisProcedure()).GetTypeShortAlias(),
					Status = (long?)RefListChargeItemStatus.open,
				};

				//act
				using var uwo = _unitOfWorkManager.Begin();
				var createChargeItem = await _chargeItemsManager.CreateChargeItemAsync(newChargeItem);
				await uwo.CompleteAsync();

				//assert

				chargeItem = await _chargeItemsManager.repository().GetAsync(createChargeItem.Id);
				chargeItem.ShouldNotBeNull();
				chargeItem.Status.ShouldBe((long?)RefListChargeItemStatus.open);

			}
			finally {

		        CleanUpTestData_ChargeItem(chargeItem.Id);
				CleanUpTestData_Patient(chargeItem.Subject.Id);
			
			}


		}
		private void CleanUpTestData_ChargeItem(Guid chargeItemId)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery("DELETE FROM Fhir_ChargeItems WHERE Id = '" + chargeItemId.ToString() + "'");
			query.ExecuteUpdate();

			session.Flush();
		}
	}
}
