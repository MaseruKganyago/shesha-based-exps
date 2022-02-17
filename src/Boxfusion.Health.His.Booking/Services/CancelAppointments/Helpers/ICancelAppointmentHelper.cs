using Abp.Application.Services;
using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Bookings.Services.CancelAppointments.Dtos;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.CancelAppointments.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICancelAppointmentHelper : ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId);
    }
}
