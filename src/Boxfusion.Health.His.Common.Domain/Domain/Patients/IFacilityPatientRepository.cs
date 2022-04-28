using Abp.Domain.Repositories;
using Boxfusion.Health.His.Common.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Patients
{
    public interface IFacilityPatientRepository : IRepository<FacilityPatient, Guid>
    {
    }
}
