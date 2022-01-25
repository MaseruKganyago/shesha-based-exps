using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.FacilityPatients.Helpers
{
    public interface IHisFacilityPatientsCrudHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FacilityPatientsResponse> CreateAsync(FacilityPatientsInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FacilityPatientsResponse> GetAsync(Guid id);
    }
}
