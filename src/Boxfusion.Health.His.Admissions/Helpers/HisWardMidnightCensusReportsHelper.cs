using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public class HisWardMidnightCensusReportsHelper : IHisWardMidnightCensusReportsHelper
    {
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly ISessionProvider _sessionProvider;
        public HisWardMidnightCensusReportsHelper(IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport
            , ISessionProvider sessionProvider)
        {
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _sessionProvider = sessionProvider;
        }

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
                            AND ApprovalStatusLkp = 2
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
