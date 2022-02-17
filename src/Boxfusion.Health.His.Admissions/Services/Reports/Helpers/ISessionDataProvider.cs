using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Helpers
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<TodaysAdmissionResponse>> GetTodaysAdmission(TodaysAdmissionInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<MidnightCountResponse>> GetMidnightCount(TodaysAdmissionInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<DayPatientsResponse>> GetDayPatients(TodaysAdmissionInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<TotalAdmissionsResponse>> GetMonthlyTotalAdmissions(TodaysAdmissionInput input);

    }
}
