using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.His.Bookings.Domain;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
