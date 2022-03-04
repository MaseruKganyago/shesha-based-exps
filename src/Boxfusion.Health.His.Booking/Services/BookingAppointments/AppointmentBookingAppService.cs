using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.HealthCommon.Core.Services.Schedules.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Slots.Helpers;
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
        //private readonly IScheduleHelper<CdmSchedule, CdmScheduleResponse> _scheduleHelperCrudHelper;
        //private readonly ISlotHelper<CdmSlot, CdmSlotResponse> _slotHelperCrudHelper;
        //private readonly IBookingManagementHelper _bookingManagementHelper;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        ///// <summary>
        ///// 
        ///// </summary>
        //public AppointmentForBookingAppService(           
        //    IBookingManagementHelper bookingManagementHelper,
        //    IScheduleHelper<CdmSchedule, CdmScheduleResponse> scheduleHelperCrudHelper,
        //    ISlotHelper<CdmSlot, CdmSlotResponse> slotCrudHelper,
        //    IHttpContextAccessor httpContextAccessor)
        //{
        //    _bookingManagementHelper = bookingManagementHelper;
        //    _scheduleHelperCrudHelper = scheduleHelperCrudHelper;
        //    _slotHelperCrudHelper = slotCrudHelper;
        //    _httpContextAccessor = httpContextAccessor;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("Schedules/SchedulesAssociatedToUser")]
        //public async Task<List<CdmScheduleResponse>> GetAllAsync()
        //{
        //    var facilityId = _httpContextAccessor.HttpContext.Request.Query["facilityId"].ToString();
        //    var person = await GetCurrentLoggedPersonFhirBaseAsync();
        //    var schedules = await _scheduleHelperCrudHelper.GetAllAsync(person.Id, facilityId);

        //    return ObjectMapper.Map<List<CdmScheduleResponse>>(schedules);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="scheduleId"></param>
        ///// <returns></returns>
        //[HttpGet, Route("Schedules/{scheduleId}/Slots")]
        //public async Task<List<CdmSlotResponse>> GetSlotsByScheduleAsync(Guid scheduleId)
        //{
        //    var slots = await _slotHelperCrudHelper.GetAllAsync(scheduleId);

        //    return slots;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPost, Route("Appointments/BookAvailableSlot")]
        ////[AbpAuthorize(PermissionNames.BookAppointment)]
        //public async Task<CdmAppointmentResponse> BookAvailableSlotAsync(BookAppointmentInput input)
        //{
        //    Validation.ValidateEntityWithDisplayNameDto(input?.Schedule, "Schedule");
        //    Validation.ValidateNullableType(input?.Start, "Appointment Date");
        //    Validation.ValidateReflist(input?.AppointmentType, "AppointmentType");
        //    Validation.ValidateReflist(input?.SlotType, "SlotType");
        //    Validation.ValidateEntityWithDisplayNameDto(input?.Patient, "Patient");

        //    var isScheduleActive = await _scheduleHelperCrudHelper.IsScheduleActive(input.Schedule.Id.Value);
        //    if (!isScheduleActive) throw new UserFriendlyException("The schedule is not active");

        //    var availableSlots = await _slotHelperCrudHelper.GetBookingSlots((RefListSlotCapacityTypes)input.SlotType.ItemValue, input.Start.Value);
        //    if (!availableSlots.Any())
        //        throw new UserFriendlyException("There are no available slots");

        //    return await _bookingManagementHelper.BookAvailableSlotAsync(input, availableSlots.FirstOrDefault());
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPut, Route("Appointments/{appointmentId}/Reschedule")]
        ////[AbpAuthorize(PermissionNames.RescheduleAppointment)]
        //public async Task<CdmAppointmentResponse> RescheduleAppointment(RescheduleInput input)
        //{
        //    Validation.ValidateIdWithException(input?.Id, "Appointment Id cannot be empty");
        //    Validation.ValidateNullableType(input?.Start, "Appointment Date");
        //    Validation.ValidateReflist(input?.SlotType, "SlotType");

        //    var isAppointmentStatusBooked = await _bookingManagementHelper.IsAppointmentStatusBooked(input.Id);
        //    if (!isAppointmentStatusBooked)
        //        throw new UserFriendlyException("Cannot reschedule an appointment that does not have a booked status");

        //    var availableSlots = await _slotHelperCrudHelper.GetBookingSlots((RefListSlotCapacityTypes)input.SlotType.ItemValue, input.Start.Value);
        //    if (!availableSlots.Any())
        //        throw new UserFriendlyException("There are no available slots");

        //    return await _bookingManagementHelper.RescheduleAppointment(input, availableSlots.FirstOrDefault());
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="appointmentId"></param>
        ///// <returns></returns>
        //[HttpPut, Route("Appointments/{appointmentId}/ConfirmArrival")]
        //[AbpAuthorize(PermissionNames.RescheduleAppointment)]
        //public async Task<CdmAppointmentResponse> ConfirmAppointmentArrival(Guid appointmentId)
        //{
        //    var isAppointmentStatusBooked = await _bookingManagementHelper.IsAppointmentStatusBooked(appointmentId);
        //    if (!isAppointmentStatusBooked)
        //        throw new UserFriendlyException("Cannot reschedule an appointment that does not have a booked status");

        //    var confirmedAppointmentArrivalTime = await _bookingManagementHelper.ConfirmAppointmentArrival(appointmentId);

        //    return confirmedAppointmentArrivalTime;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="appointmentId"></param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //[HttpGet, Route("Appointments/{appointmentId}")]
        //public async Task<CdmAppointmentResponse> GetAppointmentAsync(Guid appointmentId)
        //{
        //    return await _bookingManagementHelper.GetAppointmentAsync(appointmentId);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="scheduleId"></param>
        ///// <param name="startDate"></param>
        ///// <param name="pagination"></param>
        ///// <param name="endDate"></param>
        ///// <returns></returns>
        //[HttpGet, Route("Appointments/FlattenedDailyFacilityAppointments")]
        ////[AbpAuthorize(PermissionNames.DailyAppointmentBooking)]
        //public async Task<PagedResponse> GetFlattenedAppointmentsAsync(Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate)
        //{
        //    var facilityId = Guid.Parse(_httpContextAccessor.HttpContext.Request.Query["facilityId"].ToString());

        //    Validation.ValidateIdWithException(facilityId, "Facility Context Id cannot be empty");
        //    Validation.ValidateIdWithException(scheduleId, "Schedule Id cannot be empty");
        //    Validation.ValidateNullableType(startDate, "Filtering Start Date");
        //    Validation.ValidateNullableType(pagination.PageNumber, "PageNumber");
        //    Validation.ValidateNullableType(pagination.PageSize, "PageSize");
            
        //    var flattenedAppointments = await _bookingManagementHelper.GetFlattenedAppointmentsAsync(facilityId, scheduleId, startDate, pagination, endDate);

        //    return new PagedResponse(items: flattenedAppointments, paging: new Paging(pagination.PageNumber, pagination.PageSize, (flattenedAppointments.Any()) ? flattenedAppointments.FirstOrDefault().TotalCount : 0));
        //}

    }
}
