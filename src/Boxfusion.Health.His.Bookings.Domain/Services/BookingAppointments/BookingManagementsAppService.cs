using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Domain.Views;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Transform;
using Shesha;
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
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class BookingManagementsAppService : SheshaAppServiceBase //, IBookingManagementsAppService
    {

        /// <summary>
        /// 
        /// </summary>
        public BookingManagementsAppService()
        {

        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("Schedules/SchedulesAssociatedToUser")]
        //[Obsolete]
        //public async Task<List<CdmScheduleResponse>> GetSchedulesAssociatedToUser()
        //{
        //    var person = await GetCurrentLoggedPersonFhirBaseAsync();
        //    var manager = this.IocManager.Resolve<CmdScheduleManager>();

        //    //TODO: Introduce Context Facility limitation 
        //    var schedules = await manager.GetSchedulesAssociatedToUserAsync(person.Id, "Schedule Manager");

        //    //var schedules = await _scheduleHelperCrudHelper.GetAllAsync(person.Id, facilityId);

        //    return ObjectMapper.Map<List<CdmScheduleResponse>>(schedules);
        //}

        ////TODO:IH NOW START HERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! MAKE THIS WORK
        //[HttpPost, Route("Appointments/BookAvailableSlot")]
        //[AbpAuthorize(PermissionNames.BookAppointment)]
        //[Obsolete]
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


        ////TODO:IH NOW
        //[HttpGet, Route("Schedules/{scheduleId}/Slots")]
        //[Obsolete]
        //public async Task<List<CdmSlotResponse>> GetSlotsByScheduleAsync(Guid scheduleId)
        //{
        //    var slots = await _slotHelperCrudHelper.GetAllAsync(scheduleId);

        //    //TODO: SHOULD USE AUTO-GENERATED DTOs OR AT LEAST REPLACE Response with Dto

        //    return slots;
        //}


        //TODO:IH ELIMINATE ONCE ABLE TO USE MORE GENERIC APPROACH
        [HttpGet, Route("Appointments/FlattenedDailyFacilityAppointments")]
        //[AbpAuthorize(PermissionNames.DailyAppointmentBooking)]
        public async Task<PagedResponse> GetFlattenedAppointmentsAsync(Guid scheduleId, DateTime? startDate, PaginationDto pagination, DateTime? endDate)
        {
            if (!RequestContextHelper.HasFacilityId) throw new UserFriendlyException("Facility Context Id cannot be empty");
            Validation.ValidateIdWithException(scheduleId, "Schedule Id cannot be empty");
            Validation.ValidateNullableType(startDate, "Filtering Start Date");
            Validation.ValidateNullableType(pagination.PageNumber, "PageNumber");
            Validation.ValidateNullableType(pagination.PageSize, "PageSize");

            var scheduleRepo = IocManager.Resolve<IRepository<CdmSchedule, Guid>>();
            var schedule = await scheduleRepo.GetAsync(scheduleId);

            var facilityId = RequestContextHelper.FacilityId; 
            var flattenedAppointments = await GetFlattenedAppointmentsAsync(facilityId, scheduleId, startDate, pagination, endDate);

            return new PagedResponse(items: flattenedAppointments, paging: new Paging(pagination.PageNumber, pagination.PageSize, (flattenedAppointments.Any()) ? flattenedAppointments.FirstOrDefault().TotalCount : 0));
        }


        private async Task<List<FlattenedAppointmentDto>> GetFlattenedAppointmentsAsync(Guid facilityId, Guid scheduleId, DateTime? filterStartDate, PaginationDto pagination, DateTime? filterEndDate)
        {
            IList<FlattenedAppointment> appointments = null;

            using (var session = this.IocManager.Resolve<ISessionFactory>().OpenSession())
            {
                appointments = await session
                  .CreateSQLQuery(Util.FlattenedAppointmentSqlQuery)
                  .SetResultTransformer(Transformers.AliasToBean<FlattenedAppointment>())
                  .SetParameter("scheduleId", scheduleId)
                  .SetParameter("filterStartDate", filterStartDate)
                  .SetParameter("filterEndDate", filterEndDate)
                  .SetParameter("pageNumber", pagination.PageNumber)
                  .SetParameter("pageSize", pagination.PageSize)
                  .ListAsync<FlattenedAppointment>();
                session.Flush();
            }

            var mapper = IocManager.Resolve<IMapper>();

            return mapper.Map<List<FlattenedAppointmentDto>>(appointments);

        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPut, Route("Appointments/{appointmentId}/Reschedule")]
        ////[AbpAuthorize(PermissionNames.RescheduleAppointment)]
        //[Obsolete]
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
        //[Obsolete]
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
        ///// <param name="facilityId"></param>
        ///// <param name="appointmentId"></param>
        ///// <returns></returns>
        //[HttpPut, Route("Appointments/CancelAppointment")]
        //[Obsolete]
        //public async Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId)
        //{

        //    Validation.ValidateIdWithException(appointmentId, "Appointment Id cannot be null");
        //    var canceledAppointment = await _bookingManagementHelper.CancelAppointment(facilityId, appointmentId);

        //    return canceledAppointment;
        //}
    }
}
