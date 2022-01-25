using Abp.Application.Services;
using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Booking.Services.FacilityPatients
{
    public interface IHisFacilityPatientsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FacilityPatientsResponse> GetFacilityPatient(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FacilityPatientsResponse> CreateAsync(FacilityPatientsInput input);
    }
}
