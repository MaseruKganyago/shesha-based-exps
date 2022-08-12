using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Tests
{
    public class TestExample: SheshaNhTestBase
    {
        private IUnitOfWorkManager _uowManager;
        private IRepository<CdmSchedule, Guid> _scheduleRepository;

        public TestExample()
        {
            _scheduleRepository = Resolve<IRepository<CdmSchedule, Guid>>();

            _uowManager = Resolve<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Test_Example()
        {
            LoginAsHost("admin");

            using (var uow = _uowManager.Begin())
            {
                var res = _scheduleRepository.GetAll().Count();
                await uow.CompleteAsync();

                Assert.True(res > 0);
            }
        }
    }
}
