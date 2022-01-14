using Boxfusion.Health.His.Admissions.Services.Wards;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Boxfusion.Health.His.Tests.HisWards
{
    public class HisWardsAppService_Test : SheshaNhTestBase<HisTestModule>
    {
        private readonly IHisWardsAppService _hisWardsAppService;
        public HisWardsAppService_Test()
        {
            _hisWardsAppService = Resolve<IHisWardsAppService>();
        }

        [Fact]
        public async Task Should_Get_Daily_Report()
        {
            LoginAsHost("kalafongcapturer");
            var report = await _hisWardsAppService.GetWardDailyReport(new Admissions.Services.Admissions.Dto.WardCensusInput()
            {
                ReportDate = DateTime.Parse("2022-01-13"),
                WardId = Guid.Parse("25bd2814-a7ce-490c-959c-a38652863df4")
            });

            Assert.NotNull(report);
        }
    }
}
