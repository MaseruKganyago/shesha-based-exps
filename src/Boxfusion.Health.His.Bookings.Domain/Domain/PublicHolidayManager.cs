using Abp;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Runtime.Caching;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shesha.Enterprise.PublicHolidays
{
    /// <summary>
    /// Domain Service for Managing Public Holidays
    /// </summary>
    public class PublicHolidayManager : DomainService, IEventHandler<EntityChangedEventData<PublicHoliday>>, ITransientDependency
    {
        private const string PUBLIC_HOLIDAYS_CACHE_KEY = "Shesha.Enterprise.PublicHolidays.Cache";

        private readonly IRepository<PublicHoliday, Guid> _holidayRepo;
        private readonly ICacheManager _cacheManager;

        protected ITypedCache<string, SortedList<DateTime, String>> HolidaysCache => _cacheManager.GetCache<string, SortedList<DateTime, String>>(PUBLIC_HOLIDAYS_CACHE_KEY);

        /// <summary>
        /// 
        /// </summary>
        public PublicHolidayManager(IRepository<PublicHoliday, Guid> holidayRepo,
                                            ICacheManager cacheManager)
        {
            _holidayRepo = holidayRepo;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Checks if the specified date is a Public Holiday or not.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment.</param>
        /// <returns>Returns true if the specified date is a Public Holiday, otherwise returns false.</returns>
        public async Task<bool> IsHolidayAsync(DateTime date)
        {
            // Checking the cache first
            var holidays = await HolidaysCache.GetOrDefaultAsync(PUBLIC_HOLIDAYS_CACHE_KEY);

            if (holidays is null)
            {
                // Not available from cache so will retrieve from DB an store in cache
                holidays = new SortedList<DateTime, string>();

                var allHolidays = await _holidayRepo.GetAllListAsync();

                allHolidays.ForEach(o => holidays.Add(o.Date.Value.Date, o.Name));

                // Update the cache
                await HolidaysCache.SetAsync(PUBLIC_HOLIDAYS_CACHE_KEY,
                                            holidays,
                                            absoluteExpireTime: TimeSpan.FromMinutes(60));
            }

            return holidays.ContainsKey(date.Date);
        }


        /// <summary>
        /// Ckears the cache with all public holidays.
        /// </summary>
        /// <returns></returns>
        public async Task ClearCacheAsync()
        {
            await HolidaysCache.ClearAsync();
        }

        /// <summary>
        /// Clears the Holiday cache any time a new holiday has been added/modified.
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(EntityChangedEventData<PublicHoliday> eventData)
        {
            ClearCacheAsync();
        }


    }
}
