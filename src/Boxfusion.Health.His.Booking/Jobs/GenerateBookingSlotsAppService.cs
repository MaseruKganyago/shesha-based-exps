using Abp.Application.Services;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Bookings.Helpers.Slots;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Jobs
{
    public class GenerateBookingSlotsAppService : IApplicationService
    {        
        private readonly IGenerateBookingSlotsHelper _generateBookingSlots;

        public GenerateBookingSlotsAppService(IGenerateBookingSlotsHelper generateBookingSlots)
        {
            _generateBookingSlots = generateBookingSlots;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task GenerateBookingSlotsAsync()
        {
            await _generateBookingSlots.GenerateBookingSlotsAsync();
        }
    }
}
