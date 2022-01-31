using Abp.Application.Services;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookingManagementsAppService: IApplicationService
    {
        Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate);
    }
}
