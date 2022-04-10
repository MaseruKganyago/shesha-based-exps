using Abp.Dependency;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.His.Admissions.Application.Domain.Views;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using Boxfusion.Health.His.Common.Enums;
using NHibernate.Transform;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportHelper : IReportHelper, ITransientDependency
    {
        private static readonly ISessionProvider _sessionProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>IMapper _mapper
        public ReportHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        static ReportHelper()
        {
            _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public async Task<List<ReportResponseDto>> GetReportAsync(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            IList<ReportModelQuery> reportQuery = null;
            if (reportType == RefListReportTypes.Daily)
            {
                reportQuery = await _sessionProvider.Session
                          .CreateSQLQuery(Util.DailyReportSqlQuery)
                          .SetResultTransformer(Transformers.AliasToBean<ReportModelQuery>())
                          .SetParameter("wardId", wardId)
                          .SetParameter("filterDate", filterDate)
                          .ListAsync<ReportModelQuery>();
            }
            else
            {
                reportQuery = await _sessionProvider.Session
                          .CreateSQLQuery(Util.MonthReportSqlQuery)
                          .SetResultTransformer(Transformers.AliasToBean<ReportModelQuery>())
                          .SetParameter("wardId", wardId)
                          .SetParameter("filterDate", filterDate)
                          .ListAsync<ReportModelQuery>();
            }

            return _mapper.Map<List<ReportResponseDto>>(reportQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<DashboardResponseDto>> GetDashboardAsync(Guid? hospitalId)
        {
            try
            {
                var dashboardQuery = await _sessionProvider.Session
                              .CreateSQLQuery(Util.Dashboards)
                              .SetResultTransformer(Transformers.AliasToBean<DashboardModelQuery>())
                              .SetParameter("hospitalId", hospitalId)
                              .ListAsync<DashboardModelQuery>();

                return _mapper.Map<List<DashboardResponseDto>>(dashboardQuery);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }

        }
    }
}
