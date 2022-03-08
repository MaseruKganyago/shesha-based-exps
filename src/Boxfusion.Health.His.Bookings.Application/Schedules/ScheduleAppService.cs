using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers;
using Boxfusion.Health.His.Domain.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/Bookings/[controller]")]
    public class ScheduleAppService : CdmAppServiceBase
    {
        private readonly CmdScheduleManager _scheduleManager;

        /// <summary>
        /// 
        /// </summary>
        public ScheduleAppService(CmdScheduleManager scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("SchedulesAssociatedToUser")]
        public async Task<List<DynamicDto<CdmSchedule, Guid>>> GetSchedulesAssociatedToUserAsync()
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            //TODO: Introduce Context Facility limitation 
            var schedules = await _scheduleManager.GetSchedulesAssociatedToUserAsync(person.Id, "Schedule Manager");

            //var schedules = await _scheduleHelperCrudHelper.GetAllAsync(person.Id, facilityId);
            var list = new List<DynamicDto<CdmSchedule, Guid>>();
            schedules.ForEach(async o => list.Add(await this.MapToDynamicDtoAsync<CdmSchedule, Guid>(o)));
            return ObjectMapper.Map<List<DynamicDto<CdmSchedule, Guid>>>(schedules);
        }

        /// <summary>
        /// Generate booking slots for all active Schedules where SchedulingModel is Appointment.
        /// </summary>
        [HttpPost, Route("GenerateSlotsForAll")]
        public async Task<object> GenerateSlotsAsync()
        {
            var bookingSlotsGenerator = this.IocManager.Resolve<BookingSlotsGenerator>();

            await bookingSlotsGenerator.GenerateBookingSlotsForAllSchedulesAsync();

            return new object();
        }


    }
}
