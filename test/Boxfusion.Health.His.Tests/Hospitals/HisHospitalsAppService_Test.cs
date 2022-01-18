using Boxfusion.Health.His.Contracts.Interfaces.Hospitals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Tests.Hospitals
{
    public class HisHospitalsAppService_Test : SheshaNhTestBase<HisTestModule>
    {
        private readonly IHisHospitalsAppService _hisHospitalsAppService;
        public HisHospitalsAppService_Test()
        {
            _hisHospitalsAppService = Resolve<IHisHospitalsAppService>();
        }

        [Fact]
        public async Task Should_Create_Hospital()
        {
            LoginAsHost("admin");
            var hospital = await _hisHospitalsAppService.CreateHospitalAsync(new HealthCommon.Core.Dtos.Cdm.HospitalInput()
            {
                Description = "Unit Testing Hospital",
                District = new Shesha.AutoMapper.Dto.ReferenceListItemValueDto() { ItemValue = 1 },
                FreeTextAddress = "266 Pretorius",
                CompanyRegistrationNo = "12325",
                FacilityType = new Shesha.AutoMapper.Dto.ReferenceListItemValueDto() { ItemValue = 1 },
                Name = "Boxfusion Hospital",
                Latitude = 1212121,
                Longitude = 1544,
                OrganisationType = new Shesha.AutoMapper.Dto.ReferenceListItemValueDto() { ItemValue = 1 },
                Speciality = new Shesha.AutoMapper.Dto.ReferenceListItemValueDto() { ItemValue = 1 },
            });

            Assert.NotNull(hospital);
        }
        
        [Fact]
        public async Task Should_Get_ALL_Hospital()
        {
            LoginAsHost("admin");
            var hospital = await _hisHospitalsAppService.GetHospitalsAsync();

            Assert.NotNull(hospital);
        }
    }
}
