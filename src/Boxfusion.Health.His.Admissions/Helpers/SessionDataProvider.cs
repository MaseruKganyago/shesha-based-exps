using Abp.UI;
using Boxfusion.Health.His.Admissions.Helpers.Dtos;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using NHibernate.Transform;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public class SessionDataProvider : ISessionDataProvider
    {
        private readonly ISessionProvider _sessionProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionProvider"></param>
        public SessionDataProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<List<DailyStats>> GetDailyStats(WardCensusInput2 input)
        {
            try
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
                    .SetResultTransformer(Transformers.AliasToBean<DailyStats>())
                    .ListAsync<DailyStats>())
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }

        public async Task<List<DayPatientsResponse>> GetDayPatients(TodaysAdmissionInput input)
        {
            try
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
                    .SetResultTransformer(Transformers.AliasToBean<DayPatientsResponse>())
                    .ListAsync<DayPatientsResponse>())
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }

        public async Task<List<MidnightCountResponse>> GetMidnightCount(TodaysAdmissionInput input)
        {
            try
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
                    .SetResultTransformer(Transformers.AliasToBean<MidnightCountResponse>())
                    .ListAsync<MidnightCountResponse>())
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }

        public async Task<List<MonthlyStats>> GetMonthlyStats(WardCensusInput input)
        {
            try
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
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }

        public async Task<List<TotalAdmissionsResponse>> GetMonthlyTotalAdmissions(TodaysAdmissionInput input)
        {
            try
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
                    .SetResultTransformer(Transformers.AliasToBean<TotalAdmissionsResponse>())
                    .ListAsync<TotalAdmissionsResponse>())
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }

        public async Task<List<TodaysAdmissionResponse>> GetTodaysAdmission(TodaysAdmissionInput input)
        {
            try
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
                    .SetResultTransformer(Transformers.AliasToBean<TodaysAdmissionResponse>())
                    .ListAsync<TodaysAdmissionResponse>())
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }
    }
}
