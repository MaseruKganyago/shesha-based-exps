using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Bookings.Services.CancelAppointments.Helpers;
//using Boxfusion.Health.His.Bookings.Services.CdmAppointments.Dtos;
using Microsoft.AspNetCore.Http;
using Shesha.AutoMapper.Dto;
using Shesha.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.CancelAppointments.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class CancelAppointmentHelper : ICancelAppointmentHelper 
    {
        private readonly IRepository<CdmAppointment, Guid> _cdmAppointmentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ISmsGateway _smsSender;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="smsSender"></param>
        /// <param name="httpContextAccessor"></param>
        public CancelAppointmentHelper(IRepository<CdmAppointment, Guid> appointmentRepository, IMapper mapper,
            ISmsGateway smsSender, IHttpContextAccessor httpContextAccessor)
        {
            _cdmAppointmentRepository = appointmentRepository;
            _mapper = mapper;
            _smsSender = smsSender;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId)
        {
            var facId = Guid.Parse(_httpContextAccessor.HttpContext.Request.Query["facilityId"].ToString());

            var appointment = await _cdmAppointmentRepository.GetAsync(appointmentId);

            if (appointment.Status == RefListAppointmentStatuses.booked || appointment.Status == RefListAppointmentStatuses.waitlist ||
                appointment.Status == RefListAppointmentStatuses.proposed || appointment.Status == RefListAppointmentStatuses.pending)
            {
                appointment.Status = RefListAppointmentStatuses.cancelled;
                appointment.ArrivalTime = DateTime.Now;
                appointment.DropOutTime = DateTime.Now;

                //Send Notification
                await _smsSender.SendSmsAsync(appointment.Patient.MobileNumber, $"Appointment for {appointment.RefNumber} is canceled");
                //await _smsSender.SendSmsAsync(appointment.AlternateContactCellphone, $"Appointment for {appointment.RefNumber} is canceled");

                await _cdmAppointmentRepository.UpdateAsync(appointment);
            }

            return _mapper.Map<CdmAppointmentResponse>(appointment);
        }
    }
}
