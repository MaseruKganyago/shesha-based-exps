﻿using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Bookings.Domain.Dtos;
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
        Task<List<CdmSchedule>> GetSchedules();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        Task<List<ScheduleAvailabilityForBooking>> GetScheduleAvailability(CdmSchedule schedule);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<PublicHolidaysDto>> GetPublicHolidays();
    }
}
