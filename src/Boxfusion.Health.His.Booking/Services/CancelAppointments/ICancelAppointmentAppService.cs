using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
//using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Bookings.Services.CdmAppointments.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.CdmAppointments
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICancelAppointmentAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId);
    }
}
