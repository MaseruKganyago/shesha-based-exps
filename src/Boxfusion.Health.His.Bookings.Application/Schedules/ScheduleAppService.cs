using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Bookings.Authorization;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Authorization;
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

            Guid? facilityId = RequestContextHelper.HasFacilityId ? RequestContextHelper.FacilityId : null;
            var schedules = await _scheduleManager.GetSchedulesAssociatedToUserAsync(person.Id, BookingsRoles.ScheduleManager, facilityId);

            var list = new List<DynamicDto<CdmSchedule, Guid>>();

            foreach (var schedule in schedules)
            {
                var scheduleDto = await this.MapToDynamicDtoAsync<CdmSchedule, Guid>(schedule);
                list.Add(scheduleDto);
            }

            return list;
        }

        /// <summary>
        /// Generate booking slots for all active Schedules where SchedulingModel is Appointment.
        /// </summary>
        [HttpPost, Route("GenerateSlotsForAll")]
        public async Task<object> GenerateSlotsForAllAsync()
        {
            var bookingSlotsGenerator = this.IocManager.Resolve<BookingSlotsGenerator>();

            await bookingSlotsGenerator.GenerateBookingSlotsForAllSchedulesAsync();

            return new object();
        }

        /// <summary>
        /// Generate booking slots for the specified schedule
        /// </summary>
        [HttpPost, Route("{id}/GenerateSlots")]
        public async Task<object> GenerateSlotsAsync(Guid id)
        {
            var bookingSlotsGenerator = this.IocManager.Resolve<BookingSlotsGenerator>();

            await bookingSlotsGenerator.GenerateBookingSlotsForScheduleAsync(id);

            return new object();
        }

        /// <summary>
        /// Returns the number of Pending appointments (appointment which have been booked but are yet to be fullfiled including proposed and waitlisted) 
        /// for the specified schedule.
        /// </summary>
        [HttpPost, Route("{scheduleId}/GetNumPendingAppointments")]
        public async Task<object> GetNumPendingAppointments(Guid scheduleId)
        {
            var bookingSlotsGenerator = this.IocManager.Resolve<BookingSlotsGenerator>();

            await bookingSlotsGenerator.GenerateBookingSlotsForScheduleAsync(scheduleId);

            return new object();
        }

    }
}
