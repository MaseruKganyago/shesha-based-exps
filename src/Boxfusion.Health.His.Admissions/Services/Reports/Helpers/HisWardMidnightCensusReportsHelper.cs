using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Application.Helpers;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Common;
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
    public class HisWardMidnightCensusReportsHelper : IHisWardMidnightCensusReportsHelper
    {
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly ISessionProvider _sessionProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardMidnightCensusReport"></param>
        /// <param name="sessionProvider"></param>
        public HisWardMidnightCensusReportsHelper(IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport
            , ISessionProvider sessionProvider)
        {
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _sessionProvider = sessionProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ResertReportAsync(ResertReportInput input)
        {
            try
            {
                await _sessionProvider.Session
                    .CreateSQLQuery(@"
                            UPDATE His_WardMidnightCensusReports
                            SET ApprovalStatusLkp = 1
                            WHERE WardId = :WardId
                            AND ReportDate = :ReportDate   
                    ")
                    .SetParameter("WardId", input.wardId)
                    .SetParameter("ReportDate", input.reportDate)
                    .ExecuteUpdateAsync()
                    ;
            }
            catch (Exception Ex)
            {

                throw new UserFriendlyException(Ex.Message);
            }
        }
    }
}
