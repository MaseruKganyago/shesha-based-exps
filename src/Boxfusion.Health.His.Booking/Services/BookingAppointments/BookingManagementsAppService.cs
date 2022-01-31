using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Bookings.Authorization;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers;
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
        private readonly IBookingManagementHelper _bookingManagementHelper;

        /// <summary>
        /// 
        /// </summary>
        public BookingManagementsAppService(
            IBookingManagementHelper bookingManagementHelper)
        {
            _bookingManagementHelper = bookingManagementHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <param name="startDate"></param>
        /// <param name="pagination"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet, Route("Appointments/DailyFaclityFlattenedApppointments")]
        //[AbpAuthorize(PermissionNames.DailyAppointmentBooking)]
        public async Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate)
        {
            Validation.ValidateIdWithException(scheduleId, "Schedule Id cannot be empty");
            Validation.ValidateNullableType(startDate, "Filtering Start Date");
            Validation.ValidateNullableType(pagination.PageNumber, "PageNumber");
            Validation.ValidateNullableType(pagination.RowsOfPage, "RowsOfPage");

            var flattenedAppointments = await _bookingManagementHelper.GetFlattenedAppointments(scheduleId, startDate, pagination, endDate);

            return flattenedAppointments;
        }
    }
}
