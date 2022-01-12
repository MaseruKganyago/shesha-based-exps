using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Helpers.Dtos;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISessionDataProvider : ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<DailyStats>> GetDailyStats(WardCensusInput2 input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<MonthlyStats>> GetMonthlyStats(WardCensusInput input);
        Task<List<TodaysAdmissionResponse>> GetTodaysAdmission(TodaysAdmissionInput input);
        Task<List<MidnightCountResponse>> GetMidnightCount(TodaysAdmissionInput input);
        Task<List<DayPatientsResponse>> GetDayPatients(TodaysAdmissionInput input);

    }
}
