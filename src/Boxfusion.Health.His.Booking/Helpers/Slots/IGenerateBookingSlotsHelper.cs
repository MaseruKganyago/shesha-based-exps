using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Helpers.Slots
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGenerateBookingSlotsHelper : ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task GenerateBookingSlotsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<CdmSchedule>> Getschedules();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        Task<List<ScheduleAvailabilityForBooking>> GetscheduleAvailability(CdmSchedule schedule);
    }
}
