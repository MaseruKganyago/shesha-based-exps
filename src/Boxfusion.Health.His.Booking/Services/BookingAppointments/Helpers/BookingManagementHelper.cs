using Abp.Dependency;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Schedules.Helpers;
using Boxfusion.Health.His.Bookings.Domain.Views;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using NHibernate.Transform;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class BookingManagementHelper : IBookingManagementHelper, ITransientDependency
    {
        private static readonly ISessionProvider _sessionProvider;
        private readonly IScheduleHelper<CdmSchedule, CdmScheduleResponse> _scheduleHelperCrudHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleHelperCrudHelper"></param>
        /// <param name="mapper"></param>
        public BookingManagementHelper(
            IScheduleHelper<CdmSchedule, CdmScheduleResponse> scheduleHelperCrudHelper,
            IMapper mapper)
        {
            _scheduleHelperCrudHelper = scheduleHelperCrudHelper;
            _mapper = mapper;
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
        public async Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid facilityId, Guid scheduleId, DateTime? filterStartDate, PaginationDto pagination, DateTime? filterEndDate)
        {
            var flattenedAppointmentQuery = await _sessionProvider.Session
                      .CreateSQLQuery(Util.FlattenedAppointmentSqlQuery)
                      .SetResultTransformer(Transformers.AliasToBean<FlattenedAppointments>())
                      .SetParameter("facilityId", facilityId)
                      .SetParameter("scheduleId", scheduleId)
                      .SetParameter("filterStartDate", filterStartDate)
                      .SetParameter("filterEndDate", filterEndDate)
                      .SetParameter("pageNumber", pagination.PageNumber)
                      .SetParameter("rowsOfPage", pagination.RowsOfPage)
                      .ListAsync<FlattenedAppointments>();

            return _mapper.Map<List<FlattenedAppointmentDto>>(flattenedAppointmentQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public async Task<List<CdmScheduleResponse>> GetAllAsync(Guid personId, string facilityId = null)
        {
            var schedules = await _scheduleHelperCrudHelper.GetAllAsync(personId, facilityId);

            return _mapper.Map<List<CdmScheduleResponse>>(schedules);
        }
    }
}
