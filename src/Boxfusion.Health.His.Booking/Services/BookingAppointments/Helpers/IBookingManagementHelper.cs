using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
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
        /// <param name="filterEndDate"></param>
        /// <returns></returns>
        Task<List<FlattenedAppointmentDto>> GetFlattenedAppointmentsAsync(Guid facilityId, Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? filterEndDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        Task<List<CdmScheduleResponse>> GetAllAsync(Guid person, string facilityId = null);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="scheduleId"></param>
        ///// <returns></returns>
        //Task<List<CdmSlotResponse>> GetAllAsync(Guid scheduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        Task<bool> IsAppointmentStatusBooked(Guid appointmentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> BookAvailableSlotAsync(BookAppointmentInput input, CdmSlot slot);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> RescheduleAppointment(RescheduleInput input, CdmSlot slot);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> ConfirmAppointmentArrival(Guid appointmentId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> GetAppointmentAsync(Guid Id);
    }
}
