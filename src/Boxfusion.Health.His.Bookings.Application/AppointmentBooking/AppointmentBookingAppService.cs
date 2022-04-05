using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Notifications;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AppointmentBookingAppService : HisAppServiceBase
    {
        private readonly AppointmentBookingManager _appointmentBookingManager;
        private readonly IBookingNotificationSender _bookingNotificationSender;

        /// <summary>
        /// 
        /// </summary>
        public AppointmentBookingAppService(AppointmentBookingManager appointmentBookingManager, IBookingNotificationSender bookingNotificationSender)
        {
            _appointmentBookingManager = appointmentBookingManager;
            _bookingNotificationSender = bookingNotificationSender;
        }

        /// <summary>
        /// Returns a list of all Slots with available capacity that start and end between the specified dates
        /// and for the specified Schedule.
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        [HttpGet, Route("GetAvailableBookingSlots")]
        public async Task<List<DynamicDto<CdmSlot, Guid>>> GetAvailableBookingSlotsAsync(Guid scheduleId, DateTime? startTime, DateTime? endTime)
        {
            if (startTime is null) startTime = DateTime.Now.Date;
            if (endTime is null) endTime = startTime.Value.AddMonths(3);

            var slots = await _appointmentBookingManager.GetAllAvailableBookingSlotsAsync(scheduleId, startTime.Value, endTime.Value);

            var list = new List<DynamicDto<CdmSlot, Guid>>();

            foreach (var slot in slots)
            {
                var slotDto = await this.MapToDynamicDtoAsync<CdmSlot, Guid>(slot);
                list.Add(slotDto);
            }

            return list;
        }

        /// <summary>
        /// Creates a new Appointment to book the first available Slot for the specified schedule and requestedTime.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Appointments/BookAvailableSlot")]
        [AbpAuthorize(CommonPermissionsObsolete.ScheduleManagement)]
        public async Task<DynamicDto<CdmAppointment, Guid>> BookAvailableSlotAsync(BookAppointmentInput input)
        {
            Validation.ValidateEntityWithDisplayNameDto(input?.Schedule, "Schedule");
            Validation.ValidateNullableType(input?.Start, "Appointment Date");
            Validation.ValidateEntityWithDisplayNameDto(input?.Patient, "Patient");

            var mapper = IocManager.Resolve<IMapper>();

            var inAppointment = mapper.Map<CdmAppointment>(input);

            var newAppointment = await _appointmentBookingManager.BookAvailableSlotAsync(input.Schedule.Id.Value, inAppointment);

            if (newAppointment is null)
                throw new UserFriendlyException("No slots are available for booking at the requested time.");

            // send notification
            await _bookingNotificationSender.NotifyCompletionOfNewBookingAsync(newAppointment);

            return await this.MapToDynamicDtoAsync<CdmAppointment, Guid>(newAppointment);
        }

        /// <summary>
        /// RescheduleAppointment the specified Appointment.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("Appointments/{appointmentId}/Reschedule")]
        [AbpAuthorize(CommonPermissionsObsolete.ScheduleManagement)]
        public async Task<DynamicDto<CdmAppointment, Guid>> RescheduleAppointment(RescheduleInput input)
        {
            Validation.ValidateIdWithException(input?.Id, "Appointment Id cannot be empty");
            Validation.ValidateNullableType(input?.Start, "Appointment Date");

            try
            {
                var app = await _appointmentBookingManager.RescheduleAppointment(
                        input.Id,
                        input.Start.Value,
                        input.ContactName,
                        input.ContactCellphone
                        );

                if (app is null)
                    throw new UserFriendlyException("No slots are available for booking at the requested time.");

                var bookingNotificationSender = IocManager.Resolve<IBookingNotificationSender>();
                // send notification
                await _bookingNotificationSender.NotifyBookingRescheduledAsync(app);

                return await this.MapToDynamicDtoAsync<CdmAppointment, Guid>(app);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("An unexepected error occured. Could not reschedule the booking.", e);
            }
        }

        /// <summary>
        /// Confirms Arrival of the the specified Appointment.
        /// </summary>  
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpPut, Route("Appointments/{appointmentId}/ConfirmArrival")]
        [AbpAuthorize(CommonPermissionsObsolete.ScheduleManagement)]
        public async Task<DynamicDto<CdmAppointment, Guid>> ConfirmAppointmentArrival(Guid appointmentId)
        {
            var app = await _appointmentBookingManager.ConfirmAppointmentArrival(appointmentId);

            return await this.MapToDynamicDtoAsync<CdmAppointment, Guid>(app);
        }


        /// <summary>
        /// Cancels the specified Appointment.
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpPut, Route("Appointments/{appointmentId}/CancelAppointment")]
        [AbpAuthorize(CommonPermissionsObsolete.ScheduleManagement)]
        public async Task<DynamicDto<CdmAppointment, Guid>> CancelAppointment(Guid appointmentId)
        {
            try
            {
                var app = await _appointmentBookingManager.CancelAppointment(appointmentId);

                // Send notification
                await _bookingNotificationSender.NotifyBookingCancelledAsync(app);

                return await this.MapToDynamicDtoAsync<CdmAppointment, Guid>(app);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("An unexepected error occured. Could not cancel the booking.", e);
            }
        }

    }
}
