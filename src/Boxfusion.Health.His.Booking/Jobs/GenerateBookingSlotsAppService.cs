using Abp.Application.Services;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Bookings.Helpers.Slots;
using NHibernate.Linq;
using Shesha.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Jobs
{
    /// <summary>
    /// 
    /// </summary>
    public class GenerateBookingSlotsAppService : IApplicationService
    {        
        private readonly IGenerateBookingSlotsHelper _generateBookingSlots;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="generateBookingSlots"></param>
        public GenerateBookingSlotsAppService(IGenerateBookingSlotsHelper generateBookingSlots)
        {
            _generateBookingSlots = generateBookingSlots;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task GenerateBookingSlotsAsync()
        {
            //var start = new TimeSpan(8, 30, 0).Ticks;
            //var end = new TimeSpan(17, 00, 0).Ticks;
            await _generateBookingSlots.GenerateBookingSlotsAsync();
        }
    }
}
