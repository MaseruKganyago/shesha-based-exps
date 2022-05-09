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
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionProvider"></param>
        public WardMidnightCensusReportManager(ISessionProvider sessionProvider, IMapper mapper)
        {
            _sessionProvider = sessionProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> GetDailyStats(WardCensusInput2 input)
        {
            return (await _sessionProvider.Session
                   .CreateSQLQuery(@"Exec GetWardCensusDailyStats 
                            @WardId = :WardId,
                            @ReportDate = :ReportDate,
                            @TodaysAdmission = :todaysAdmission,
		                    @MidnightCount = :midnightCount,
		                    @DayPatients = :dayPatient
                    ")
                   .SetParameter("WardId", input.WardId)
                   .SetParameter("ReportDate", input.ReportDate)
                   .SetParameter("dayPatient", input.dayPatient)
                   .SetParameter("todaysAdmission", input.todaysAdmission)
                   .SetParameter("midnightCount", input.midnightCount)
                   .UniqueResultAsync<int>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> GetDayPatients(TodaysAdmissionInput input)
        {
            return (await _sessionProvider.Session
                    .CreateSQLQuery(@"
                            WITH DayPatients AS (
	                            SELECT  ROW_NUMBER() OVER(PARTITION BY AuditTrail.AdmissionId
                                                      ORDER BY AuditTrail.CreationTime DESC) AS FilterProp
	                            FROM His_HisAdmissionAuditTrails AuditTrail
		                            INNER JOIN Fhir_Encounters Enc 
			                            ON Enc.Id = AuditTrail.AdmissionId
	                            WHERE AuditTrail.isDeleted = 0
		                            AND Enc.His_WardId is not null
		                            AND Enc.IsDeleted = 0
		                            AND  AuditTrail.AdmissionStatusLkp = 1
		                            AND Enc.His_WardId =  :WardId
		                            AND CAST(AuditTrail.AuditTime AS DATE) = DATEADD(day, 0, CAST(:ReportDate AS date))
                            )
                            SELECT COUNT (1) AS DayPatients FROM DayPatients WHERE FilterProp = 1
                    ")
                    .SetParameter("WardId", input.WardId)
                    .SetParameter("ReportDate", input.ReportDate)
                    .UniqueResultAsync<int>());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> GetMidnightCount(TodaysAdmissionInput input)
        {
            return (await _sessionProvider.Session
                .CreateSQLQuery(@"
                        WITH MidnightCount AS (
                        SELECT  ROW_NUMBER() OVER(PARTITION BY AuditTrail.AdmissionId
                                                    ORDER BY AuditTrail.CreationTime DESC) AS FilterProp
                        FROM His_HisAdmissionAuditTrails AuditTrail
	                        INNER JOIN Fhir_Encounters Enc 
		                        ON Enc.Id = AuditTrail.AdmissionId
                        WHERE AuditTrail.isDeleted = 0
	                        AND Enc.His_WardId is not null
	                        AND Enc.IsDeleted = 0
	                        AND  AuditTrail.AdmissionStatusLkp = 1
	                        AND Enc.His_WardId =  :WardId
	                        AND CAST(AuditTrail.AuditTime AS DATE) < CAST(:ReportDate AS date)
                        )
                        SELECT count(1) AS MidnightCount FROM MidnightCount WHERE FilterProp = 1
                ")
                .SetParameter("WardId", input.WardId)
                .SetParameter("ReportDate", input.ReportDate)
                .UniqueResultAsync<int>());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MonthlyStats> GetMonthlyStats(WardCensusInput input)
        {
            return (await _sessionProvider.Session
                    .CreateSQLQuery(@"Exec GetWardCensusMonthlyStatsProc 
                            @WardId = :WardId,
                            @ReportDate = :ReportDate,
                            @DaysLapsed = :DaysLapsed,
                            @TotalAdmissions = :totalAdmissions
                    ")
                    .SetParameter("WardId", input.WardId)
                    .SetParameter("ReportDate", input.ReportDate)
                    .SetParameter("DaysLapsed", input.ReportDate.Value.Day)
                    .SetParameter("totalAdmissions", input.TotalMonthlyAdmissions)
                    .SetResultTransformer(Transformers.AliasToBean<MonthlyStats>())
                    .ListAsync<MonthlyStats>())
                    .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> GetMonthlyTotalAdmissions(TodaysAdmissionInput input)
        {
            return (await _sessionProvider.Session
                     .CreateSQLQuery(@"
                           WITH TotalAdmissions AS (
                            SELECT  ROW_NUMBER() OVER(PARTITION BY AuditTrail.AdmissionId
                                                        ORDER BY AuditTrail.CreationTime DESC) AS FilterProp
                            FROM His_HisAdmissionAuditTrails AuditTrail
	                            INNER JOIN Fhir_Encounters Enc 
		                            ON Enc.Id = AuditTrail.AdmissionId
                            WHERE AuditTrail.isDeleted = 0
	                            AND Enc.His_WardId is not null
	                            AND Enc.IsDeleted = 0
	                            AND  AuditTrail.AdmissionStatusLkp = 1
	                            AND Enc.His_WardId = :WardId
	                            AND month(Enc.StartDateTime) = month(:ReportDate) and year(Enc.StartDateTime) = year(:ReportDate)
                            )
                            SELECT count(1) AS TotalAdmissions FROM TotalAdmissions WHERE FilterProp = 1


                    ")
                     .SetParameter("WardId", input.WardId)
                     .SetParameter("ReportDate", input.ReportDate)
                     .UniqueResultAsync<int>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> GetTodaysAdmission(TodaysAdmissionInput input)
        {
            return (await _sessionProvider.Session
                    .CreateSQLQuery(@"
                        WITH TodaysAdmission AS ( SELECT
                            ROW_NUMBER() OVER(PARTITION BY AuditTrail.AdmissionId
                                                             ORDER BY AuditTrail.CreationTime DESC) AS FilterProp
                            FROM His_HisAdmissionAuditTrails AuditTrail
                            INNER JOIN Fhir_Encounters Enc
	                            ON Enc.Id = AuditTrail.AdmissionId
                            WHERE
	                            AuditTrail.isDeleted = 0
	                            AND Enc.His_WardId is not null
	                            AND Enc.IsDeleted = 0
	                            AND AuditTrail.AdmissionStatusLkp = 1
	                            AND Enc.His_WardId =  :WardId
	                            AND CAST(AuditTrail.AuditTime AS DATE) = DATEADD(day, 0, CAST(:ReportDate AS date))
                            )
                            Select count(1) AS  TodaysAdmission From TodaysAdmission Where FilterProp = 1
                    ")
                    .SetParameter("WardId", input.WardId)
                    .SetParameter("ReportDate", input.ReportDate)
                    .UniqueResultAsync<int>());
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
