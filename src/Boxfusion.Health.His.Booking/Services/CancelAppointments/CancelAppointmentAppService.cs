using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Bookings.Services.CancelAppointments.Helpers;
//using Boxfusion.Health.His.Bookings.Services.CdmAppointments.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
//using Boxfusion.Health.His.Bookings.Services.CancelAppointments.Helpers;

namespace Boxfusion.Health.His.Bookings.Services.CdmAppointments
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class CancelAppointmentAppService : CdmAppServiceBase, ICancelAppointmentAppService
    {
        private readonly ICancelAppointmentHelper _cdmAppointmentHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdmAppointmentHelper"></param>
        public CancelAppointmentAppService(ICancelAppointmentHelper cdmAppointmentHelper)
        {
            _cdmAppointmentHelper = cdmAppointmentHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpPut, Route("CancelAppointment")]
        public async Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId)
        {

            Validation.ValidateIdWithException(appointmentId, "Appointment Id cannot be null");
            var canceledAppointment = await _cdmAppointmentHelper.CancelAppointment(facilityId, appointmentId);

            return canceledAppointment;

        }
    }
}
