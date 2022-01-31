﻿using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
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
        /// <param name="scheduleId"></param>
        /// <param name="startDate"></param>
        /// <param name="pagination"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate);
    }
}
