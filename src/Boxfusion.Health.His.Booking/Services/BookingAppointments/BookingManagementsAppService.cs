using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.HealthCommon.Core.Services.Schedules.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Slots.Helpers;
using Boxfusion.Health.His.Bookings.Authorization;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class BookingManagementsAppService : CdmAppServiceBase, IBookingManagementsAppService
    {
        private readonly IScheduleHelper<CdmSchedule, CdmScheduleResponse> _scheduleHelperCrudHelper;
        private readonly ISlotHelper<CdmSlot, CdmSlotResponse> _slotHelperCrudHelper;
        private readonly IBookingManagementHelper _bookingManagementHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        public BookingManagementsAppService(
            IBookingManagementHelper bookingManagementHelper,
            IScheduleHelper<CdmSchedule, CdmScheduleResponse> scheduleHelperCrudHelper,
            ISlotHelper<CdmSlot, CdmSlotResponse> slotCrudHelper,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookingManagementHelper = bookingManagementHelper;
            _scheduleHelperCrudHelper = scheduleHelperCrudHelper;
            _slotHelperCrudHelper = slotCrudHelper;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="startDate"></param>
        /// <param name="pagination"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet, Route("Appointments/FlattenedDailyFacilityAppointments")]
        //[AbpAuthorize(PermissionNames.DailyAppointmentBooking)]
        public async Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid facilityId, Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate)
        {
            facilityId = Guid.Parse(_httpContextAccessor.HttpContext.Request.Query["facilityId"].ToString());

            Validation.ValidateIdWithException(facilityId, "Facility Context Id cannot be empty");
            Validation.ValidateIdWithException(scheduleId, "Schedule Id cannot be empty");
            Validation.ValidateNullableType(startDate, "Filtering Start Date");
            Validation.ValidateNullableType(pagination.PageNumber, "PageNumber");
            Validation.ValidateNullableType(pagination.RowsOfPage, "RowsOfPage");

            var flattenedAppointments = await _bookingManagementHelper.GetFlattenedAppointments(facilityId, scheduleId, startDate, pagination, endDate);

            return flattenedAppointments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Appointments/BookAvailableSlot")]
        public async Task<BookAppointmentInput> BookAvailableSlot(BookAppointmentInput input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        [HttpGet, Route("Schedules/SchedulesAssociatedToUser")]
        public async Task<List<CdmScheduleResponse>> GetAllAsync(string facilityId = null)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();
            var schedules = await _scheduleHelperCrudHelper.GetAllAsync(person.Id, facilityId);

            return ObjectMapper.Map<List<CdmScheduleResponse>>(schedules);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        [HttpGet, Route("Schedules/{scheduleId}/Slots")]
        public async Task<List<CdmSlotResponse>> GetAllAsync(Guid scheduleId)
        {
            var slots = await _slotHelperCrudHelper.GetAllAsync(scheduleId);

            return slots;
        }
    }
}
