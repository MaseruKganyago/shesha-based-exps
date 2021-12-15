﻿using Abp.UI;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
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

        public async Task<List<DailyStats>> GetDailyStats(WardCensusInput input)
        {
            try
            {
                return (await _sessionProvider.Session
                    .CreateSQLQuery(@"Exec GetWardCensusDailyStats 
                            @WardId = :WardId,
                            @ReportDate = :ReportDate                           
                    ")
                    .SetParameter("WardId", input.WardId)
                    .SetParameter("ReportDate", input.ReportDate)
                    .SetResultTransformer(Transformers.AliasToBean<DailyStats>())
                    .ListAsync<DailyStats>())
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
                            @DaysLapsed = :DaysLapsed
                    ")
                    .SetParameter("WardId", input.WardId)
                    .SetParameter("ReportDate", input.ReportDate)
                    .SetParameter("DaysLapsed", input.ReportDate.Value.Day)
                    .SetResultTransformer(Transformers.AliasToBean<MonthlyStats>())
                    .ListAsync<MonthlyStats>())
                    .ToList();
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }
    }
}
