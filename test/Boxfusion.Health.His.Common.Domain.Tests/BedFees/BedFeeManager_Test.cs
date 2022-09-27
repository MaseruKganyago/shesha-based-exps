using Abp.Domain.Repositories;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds.BedFees;
using Boxfusion.Health.His.Common.Beds.BedFees.Enums;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Tests;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Common.Domain.Tests.BedFees
{
	public class BedFeeManager_Test: HisCommonDomainTestBase
	{
		private readonly BedFeeManager _bedFeeManager;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;

		public BedFeeManager_Test(): base()
		{
			CreateTestData_HealthFacility_And_Ward_With_RoomBed("UnitTest Hospital", "UnitTest Ward", "UnitTest Room", "UnitTest Bed");
			_bedFeeManager = Resolve<BedFeeManager>();
			_wardAdmissionRepository = Resolve<IRepository<WardAdmission, Guid>>();
		}

		[Fact]
		public async Task Should_Create_then_CloseAndOpen_new_BedFee_through_WardAdmission()
		{
			//Note: all tested methods (CreateBedFeeAsync, CloseBedFeeAsync, CloseAndOpenNewBedFeeAsync) are tested
			//through wardAdmission create and update which triggers entityEvent(WardAdmissionEntityChangingEvent)

			#region Prepare test data
			var patient = await CreateTestData_NewPatient("John Dave" + "Test1");

			var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
			var ward = await GetTestData_Ward("UnitTest Ward");
			var room = await GetTestData_Room("UnitTest Room");
			var bed = await GetTestData_Bed("UnitTest Bed");

			var newAdmission = new WardAdmission
			{
				Subject = patient,
				ServiceProvider = hospital,
				Ward = ward,
				Room = room,
				Bed = bed,
				StartDateTime = DateTime.Now,
				WardAdmissionStatus = RefListWardAdmissionStatuses.admitted
			};

			var admissionEntity = await _wardAdmissionRepository.InsertAsync(newAdmission);
			var bed2 = CreateTestData_Bed("UnitTest Bed 2", room);
			#endregion

			//Act update wardAdmission and change bed
			admissionEntity.Bed = bed2;
			await _wardAdmissionRepository.UpdateAsync(admissionEntity);

			#region Assert: Verify close and open of new bedFee
			var bedFeeList = await _bedFeeManager.repository().GetAllListAsync(a => a.WardAdmission.Id == admissionEntity.Id);

			//Should have two bedFees of the wardAdmission  where one is closed and the other is open
			bedFeeList.Any(a => a.Status == (long?)RefListBedFeeStatus.closed).ShouldBe(true);
			bedFeeList.Any(a => a.Status == (long?)RefListBedFeeStatus.open).ShouldBe(true);
			#endregion
		}
	}
}
