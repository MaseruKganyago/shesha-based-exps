using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Schedules.Helpers;
using Boxfusion.Health.His.Bookings.Domain.Views;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Microsoft.AspNetCore.Http;
using NHibernate.Linq;
using NHibernate.Transform;
using Shesha.NHibernate;
using Shesha.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class BookingManagementHelper : IBookingManagementHelper, ITransientDependency
    {
        private readonly IRepository<CdmAppointment, Guid> _cdmAppointmentRepository;
        private static readonly ISessionProvider _sessionProvider;
        private readonly IScheduleHelper<CdmSchedule, CdmScheduleResponse> _scheduleHelperCrudHelper;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISmsGateway _smsSender;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdmAppointmentRepository"></param>
        /// <param name="scheduleHelperCrudHelper"></param>
        /// <param name="mapper"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="smsSender"></param>
        public BookingManagementHelper(
            IRepository<CdmAppointment, Guid> cdmAppointmentRepository,
            IScheduleHelper<CdmSchedule, CdmScheduleResponse> scheduleHelperCrudHelper,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            ISmsGateway smsSender)
        {
            _cdmAppointmentRepository = cdmAppointmentRepository;
            _scheduleHelperCrudHelper = scheduleHelperCrudHelper;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _smsSender = smsSender;
        }


        static BookingManagementHelper()
        {
            _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="filterStartDate"></param>
        /// <param name="pagination"></param>
        /// <param name="filterEndDate"></param>
        /// <returns></returns>
        public async Task<List<FlattenedAppointmentDto>> GetFlattenedAppointmentsAsync(Guid facilityId, Guid scheduleId, DateTime? filterStartDate, PaginationDto pagination, DateTime? filterEndDate)
        {
            var flattenedAppointmentQuery = await _sessionProvider.Session
                      .CreateSQLQuery(Util.FlattenedAppointmentSqlQuery)
                      .SetResultTransformer(Transformers.AliasToBean<FlattenedAppointments>())
                      .SetParameter("facilityId", facilityId)
                      .SetParameter("scheduleId", scheduleId)
                      .SetParameter("filterStartDate", filterStartDate)
                      .SetParameter("filterEndDate", filterEndDate)
                      .SetParameter("pageNumber", pagination.PageNumber)
                      .SetParameter("pageSize", pagination.PageSize)
                      .ListAsync<FlattenedAppointments>();

            return _mapper.Map<List<FlattenedAppointmentDto>>(flattenedAppointmentQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public async Task<List<CdmScheduleResponse>> GetAllAsync(Guid personId, string facilityId = null)
        {
            var schedules = await _scheduleHelperCrudHelper.GetAllAsync(personId, facilityId);

            return _mapper.Map<List<CdmScheduleResponse>>(schedules);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<CdmAppointmentResponse> GetAsync(Guid appointmentId)
        {
            var appointment = await _cdmAppointmentRepository.GetAsync(appointmentId);

            return _mapper.Map<CdmAppointmentResponse>(appointment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public async Task<CdmAppointmentResponse> BookAvailableSlotAsync(BookAppointmentInput input, CdmSlot slot)
        {
            var cdmAppointment = _mapper.Map<CdmAppointment>(input);
            _mapper.Map(slot, cdmAppointment);
            var insertedCdmAppointment = await _cdmAppointmentRepository.InsertAsync(cdmAppointment);

            return _mapper.Map<CdmAppointmentResponse>(insertedCdmAppointment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public async Task<CdmAppointmentResponse> RescheduleAppointment(RescheduleInput input, CdmSlot slot)
        {
            var cdmAppointment = await _cdmAppointmentRepository.GetAsync(input.Id);
            cdmAppointment.Status = RefListAppointmentStatuses.booked;
            _mapper.Map(input, cdmAppointment);
            _mapper.Map(slot, cdmAppointment);
            var updatedCdmAppointment = await _cdmAppointmentRepository.UpdateAsync(cdmAppointment);

            return _mapper.Map<CdmAppointmentResponse>(updatedCdmAppointment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<bool> IsAppointmentStatusBooked(Guid appointmentId)
        {
            var isAppointmentStatusBooked = await _cdmAppointmentRepository.GetAll().Where(x => x.Id == appointmentId).Select(x => x.Status).FirstOrDefaultAsync();

            if (isAppointmentStatusBooked != RefListAppointmentStatuses.booked)
                return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<CdmAppointmentResponse> ConfirmAppointmentArrival(Guid appointmentId)
        {
            var appointment = await _cdmAppointmentRepository.GetAsync(appointmentId);
            appointment.Status = RefListAppointmentStatuses.checkedIn;
            appointment.ArrivalTime = DateTime.Now;
            var updatedAppointment = await _cdmAppointmentRepository.UpdateAsync(appointment);

            return _mapper.Map<CdmAppointmentResponse>(updatedAppointment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CdmAppointmentResponse> GetAppointmentAsync(Guid Id)
        {
            return _mapper.Map<CdmAppointmentResponse>(await _cdmAppointmentRepository.GetAsync(Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<CdmAppointmentResponse> CancelAppointment(Guid facilityId, Guid appointmentId)
        {
            var facId = Guid.Parse(_httpContextAccessor.HttpContext.Request.Query["facilityId"].ToString());

            var appointment = await _cdmAppointmentRepository.GetAsync(appointmentId);

            if (appointment.Status == RefListAppointmentStatuses.booked || appointment.Status == RefListAppointmentStatuses.waitlist ||
                appointment.Status == RefListAppointmentStatuses.proposed || appointment.Status == RefListAppointmentStatuses.pending)
            {
                appointment.Status = RefListAppointmentStatuses.cancelled;
                appointment.ArrivalTime = DateTime.Now;
                appointment.DropOutTime = DateTime.Now;

                //Send Notification
                await _smsSender.SendSmsAsync(appointment.Patient.MobileNumber, $"Appointment for {appointment.RefNumber} is canceled");
                //await _smsSender.SendSmsAsync(appointment.AlternateContactCellphone, $"Appointment for {appointment.RefNumber} is canceled");

                await _cdmAppointmentRepository.UpdateAsync(appointment);
            }

            return _mapper.Map<CdmAppointmentResponse>(appointment);
        }
    }
}
