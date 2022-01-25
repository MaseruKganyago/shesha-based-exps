using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.FacilityPatients.Helpers
{
    public interface IHisFacilityPatientsCrudHelper
    {
        Task<FacilityPatientsResponse> GetAsync(Guid id);
    }
}
