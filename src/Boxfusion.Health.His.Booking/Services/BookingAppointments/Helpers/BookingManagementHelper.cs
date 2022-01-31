using Abp.Dependency;
using AutoMapper;
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
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public BookingManagementHelper(IMapper mapper)
        {
            _mapper = mapper;
        }


        static BookingManagementHelper()
        {
            _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ScheduleId"></param>
        /// <param name="FilterStartDate"></param>
        /// <param name="pagination"></param>
        /// <param name="FilterEndDate"></param>
        /// <returns></returns>
        public async Task<List<FlattenedAppointmentDto>> GetFlattenedAppointments(Guid ScheduleId, DateTime? FilterStartDate, PaginationDto pagination, DateTime? FilterEndDate)
        {
            var flattenedAppointmentQuery = await _sessionProvider.Session
                      .CreateSQLQuery(Util.FlattenedAppointmentSqlQuery)
                      .SetResultTransformer(Transformers.AliasToBean<FlattenedAppointments>())
                      .SetParameter("ScheduleId", ScheduleId)
                      .SetParameter("FilterStartDate", FilterStartDate)
                      .SetParameter("FilterEndDate", FilterEndDate ?? FilterStartDate)
                      .SetParameter("PageNumber", pagination.PageNumber)
                      .SetParameter("RowsOfPage", pagination.RowsOfPage)
                      .ListAsync<FlattenedAppointments>();

            return _mapper.Map<List<FlattenedAppointmentDto>>(flattenedAppointmentQuery);
        }
    }
}
