using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public interface ISessionDataProvider : ITransientDependency
    {
        Task<List<DailyStats>> GetDailyStats(WardCensusInput input);
        Task<List<DailyStats>> GetMonthlyStats(WardCensusInput input);
        Task<List<MidnightCensusApprovalModels>> GetApprovalModels(Guid wardId);
    }
}
