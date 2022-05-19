using Abp.Domain.Uow;

namespace Boxfusion.Health.His.Admissions.Tests

{
    public class AdmissionManagementTestBase : SheshaNhTestBase
    {
        protected IUnitOfWorkManager _uowManager;

        public AdmissionManagementTestBase()
        {
            _uowManager = Resolve<IUnitOfWorkManager>();
        }
    }
}
