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

		public async Task Should_Test_ChargeItems()
		{
			//testdata
			var chargeItem = new HisChargeItem()
			{
				Subject = await CreateTestData_NewPatient("John Dave: Unit Test"),
			    ServiceId = Guid.NewGuid(),
				ServiceType = (new HisProcedure()).GetTypeShortAlias(),
				Status = (long?)RefListChargeItemStatus.open,
			};

			//act
			using var uwo = _unitOfWorkManager.Begin();
			await _chargeItemRepository.InsertAsync(chargeItem);
			await uwo.CompleteAsync();

			//assert

			var chargeItem1 = await _chargeItemRepository.FirstOrDefaultAsync(a => a.Id == chargeItem.Id);
			chargeItem1.ShouldNotBeNull();


		}
	}
}
