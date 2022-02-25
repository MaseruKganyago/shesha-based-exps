﻿using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        Task<List<CdmScheduleResponse>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        Task<List<CdmSlotResponse>> GetSlotsByScheduleAsync(Guid scheduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="startDate"></param>
        /// <param name="pagination"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<PagedResponse> GetFlattenedAppointmentsAsync(Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> BookAvailableSlotAsync(BookAppointmentInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> GetAppointmentAsync(Guid Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId);
    }
}
