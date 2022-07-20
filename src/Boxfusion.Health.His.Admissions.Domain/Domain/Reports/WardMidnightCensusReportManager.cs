using Abp.Domain.Services;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Helpers;
using Boxfusion.Health.His.Common.Enums;
using NHibernate.Transform;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class WardMidnightCensusReportManager : DomainService
    {
        private readonly ISessionProvider _sessionProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionProvider"></param>
        public WardMidnightCensusReportManager(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WardId"></param>
        /// <param name="reportDate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<WardCensusDailyStats> GetDailyStats(Guid WardId, DateTime reportDate)
        {
            //return (await _sessionProvider.Session
            //       .CreateSQLQuery(@"Exec GetWardCensusDailyStats 
            //                @WardId = :WardId,
            //                @ReportDate = :ReportDate,
            //                @TodaysAdmission = :todaysAdmission,
		          //          @MidnightCount = :midnightCount,
		          //          @DayPatients = :dayPatient
            //        ")
            //       .SetParameter("WardId", input.WardId)
            //       .SetParameter("ReportDate", input.ReportDate)
            //       .SetParameter("dayPatient", input.dayPatient)
            //       .SetParameter("todaysAdmission", input.todaysAdmission)
            //       .SetParameter("midnightCount", input.midnightCount)
            //       .SetResultTransformer(Transformers.AliasToBean<WardCensusDailyStats>())
            //       .ListAsync<WardCensusDailyStats>())
            //       .FirstOrDefault();

            //TODO: Update implementation
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MonthlyStats> GetMonthlyStats(WardCensusQueryInput input)
        {
            return (await _sessionProvider.Session
                    .CreateSQLQuery(@"Exec GetWardCensusMonthlyStatsProc 
                            @WardId = :WardId,
                            @ReportDate = :ReportDate,
                            @DaysLapsed = :DaysLapsed
                    ")
                    .SetParameter("WardId", input.WardId)
                    .SetParameter("ReportDate", input.ReportDate)
                    .SetParameter("DaysLapsed", input.ReportDate.Value.Day)
                    .SetResultTransformer(Transformers.AliasToBean<MonthlyStats>())
                    .ListAsync<MonthlyStats>())
                    .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public async Task<ReportModelQuery> GetReportAsync(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            if (reportType == RefListReportTypes.Daily)
            {
                return (await _sessionProvider.Session
                          .CreateSQLQuery(SqlHelper.DailyReportSqlQuery)
                          .SetResultTransformer(Transformers.AliasToBean<ReportModelQuery>())
                          .SetParameter("wardId", wardId)
                          .SetParameter("filterDate", filterDate)
                          .ListAsync<ReportModelQuery>())
                          .FirstOrDefault();
            }
            else
            {
                return (await _sessionProvider.Session
                          .CreateSQLQuery(SqlHelper.MonthReportSqlQuery)
                          .SetResultTransformer(Transformers.AliasToBean<ReportModelQuery>())
                          .SetParameter("wardId", wardId)
                          .SetParameter("filterDate", filterDate)
                          .ListAsync<ReportModelQuery>())
                          .FirstOrDefault();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<DashboardModelQuery> GetDashboardAsync(Guid? hospitalId)
        {
            return (await _sessionProvider.Session
                    .CreateSQLQuery(SqlHelper.Dashboards)
                    .SetResultTransformer(Transformers.AliasToBean<DashboardModelQuery>())
                    .SetParameter("hospitalId", hospitalId)
                    .ListAsync<DashboardModelQuery>())
                    .FirstOrDefault();
        }
    }
}
