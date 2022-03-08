using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers;
using Boxfusion.Health.His.Domain.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AppointmentBookingAppService : CdmAppServiceBase //, IBookingManagementsAppService
    {
        private readonly AppointmentBookingManager _appointmentBookingManager;

        /// <summary>
        /// 
        /// </summary>
        public AppointmentBookingAppService(AppointmentBookingManager appointmentBookingManager)
        {
            _appointmentBookingManager = appointmentBookingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        [HttpGet, Route("GetAvailableBookingSlots")]
        public async Task<List<CdmSlotResponse>> GetAvailableBookingSlotsAsync(Guid scheduleId, DateTime? startTime, DateTime? endTime)
        {
            if (startTime is null) startTime = DateTime.Now.Date;
            if (endTime is null) endTime = startTime.Value.AddMonths(3);

            var slots = await _appointmentBookingManager.GetAllAvailableBookingSlotsAsync(scheduleId, startTime.Value, endTime.Value);

            //TODO:IH-NOW - Replace CdmSlotResponse with auto-generated if possible or CdmSlotDto
            /// Bring in SlotDto and SlotMapProfile from Common

            var mapper = this.IocManager.Resolve<IMapper>();

            return mapper.Map<List<CdmSlotResponse>>(slots);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Appointments/BookAvailableSlot")]
        [AbpAuthorize(PermissionNames.BookAppointment)]
        public async Task<CdmAppointmentResponse> BookAvailableSlotAsync(BookAppointmentInput input)
        {
            Validation.ValidateEntityWithDisplayNameDto(input?.Schedule, "Schedule");
            Validation.ValidateNullableType(input?.Start, "Appointment Date");
            Validation.ValidateEntityWithDisplayNameDto(input?.Patient, "Patient");


            try
            {
                var res = await _appointmentBookingManager.BookAvailableSlotAsync(
                        input.Schedule.Id.Value, 
                        input.Start.Value,
                        input.AppointmentType.ItemValue,
                        input.Patient.Id.Value,
                        input.ContactName,
                        input.ContactCellphone
                        );
                if (res is null)
                    throw new UserFriendlyException("No slots are available for booking at the requested time.");

                return await _appointmentBookingManager.BookAvailableSlotAsync(input, availableSlots.FirstOrDefault());
            }
            catch(Exception e)
            {
                throw new UserFriendlyException("There are no available slots", e);
            }

            var availableSlots = await _slotHelperCrudHelper.GetBookingSlots((RefListSlotCapacityTypes)input.SlotType.ItemValue, input.Start.Value);

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("Appointments/{appointmentId}/Reschedule")]
        //[AbpAuthorize(PermissionNames.RescheduleAppointment)]
        public async Task<CdmAppointmentResponse> RescheduleAppointment(RescheduleInput input)
        {
            Validation.ValidateIdWithException(input?.Id, "Appointment Id cannot be empty");
            Validation.ValidateNullableType(input?.Start, "Appointment Date");
            Validation.ValidateReflist(input?.SlotType, "SlotType");

            var isAppointmentStatusBooked = await _bookingManagementHelper.IsAppointmentStatusBooked(input.Id);
            if (!isAppointmentStatusBooked)
                throw new UserFriendlyException("Cannot reschedule an appointment that does not have a booked status");

            var availableSlots = await _slotHelperCrudHelper.GetBookingSlots((RefListSlotCapacityTypes)input.SlotType.ItemValue, input.Start.Value);
            if (!availableSlots.Any())
                throw new UserFriendlyException("There are no available slots");

            return await _bookingManagementHelper.RescheduleAppointment(input, availableSlots.FirstOrDefault());
        }

        /// <summary>
        /// 
        /// </summary>  
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpPut, Route("Appointments/{appointmentId}/ConfirmArrival")]
        [AbpAuthorize(PermissionNames.RescheduleAppointment)]
        public async Task<CdmAppointmentResponse> ConfirmAppointmentArrival(Guid appointmentId)
        {
            var isAppointmentStatusBooked = await _bookingManagementHelper.IsAppointmentStatusBooked(appointmentId);
            if (!isAppointmentStatusBooked)
                throw new UserFriendlyException("Cannot reschedule an appointment that does not have a booked status");

            var confirmedAppointmentArrivalTime = await _bookingManagementHelper.ConfirmAppointmentArrival(appointmentId);

            return confirmedAppointmentArrivalTime;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpPut, Route("Appointments/CancelAppointment")]
        [Obsolete]
        public async Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId)
        {

            Validation.ValidateIdWithException(appointmentId, "Appointment Id cannot be null");
            var canceledAppointment = await _bookingManagementHelper.CancelAppointment(facilityId, appointmentId);

            return canceledAppointment;
        }

    }
}
