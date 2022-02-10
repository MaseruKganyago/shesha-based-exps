using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookingManagementHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="startDate"></param>
        /// <param name="pagination"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid facilityId, Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        Task<List<CdmScheduleResponse>> GetAllAsync(Guid person, string facilityId = null);
    }
}
