using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Domain
{
    /// <summary>
    /// Domain Service for managing Appointments specifically where they belong to schedules
    /// where Schedule.SchedulingModel is Appointment Booking.
    /// </summary>
    public class CmdScheduleManager : DomainService
    {
        private readonly IRepository<CdmSchedule, Guid> _scheduleRepo;
        private readonly IRepository<CdmSlot, Guid> _slotRepo;
        private readonly IRepository<CdmAppointment, Guid> _appointmentRepo;
        private readonly IRepository<ScheduleRoleAppointment, Guid> _scheduleRoleAppointRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulesRepo"></param>
        /// <param name="scheduleAvailabilityRepo"></param>
        /// <param name="slotsRepo"></param>
        public CmdScheduleManager(IRepository<CdmSchedule, Guid> schedulesRepo,
            IRepository<ScheduleAvailabilityForTimeBooking, Guid> scheduleAvailabilityRepo,
            IRepository<CdmSlot, Guid> slotsRepo,
            IRepository<CdmAppointment, Guid> appointmentsRepo,
            IRepository<CdmSchedule, Guid> scheduleRepo,
            IRepository<ScheduleRoleAppointment, Guid> scheduleRoleAppointRepo)
        {
            _slotRepo = slotsRepo;
            _appointmentRepo = appointmentsRepo;
            _scheduleRepo = scheduleRepo;
            _scheduleRoleAppointRepo = scheduleRoleAppointRepo;
        }


        /// <summary>
        /// Returns the list of schedules associated with to the specified user through a Role appointment.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="roleName"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public async Task<List<CdmSchedule>> GetSchedulesAssociatedToUserAsync(Guid personId, string roleName, Guid? facilityId = null)
        {
            if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentNullException("role");


            //TODO: REMOVE TEMP - WANT TO SHOW ALL SCHEDULES FOR FACILITY
            var schedules = await _scheduleRepo.GetAllListAsync(o => o.HealthFacilityOwner.Id == facilityId && o.Active == true);

            //var roleRepo = Abp.Dependency.IocManager.Instance.Resolve<IRepository<ShaRole, Guid>>();
            //var role = await roleRepo.FirstOrDefaultAsync(e => e.Name == roleName);
            //if (role is null) throw new InvalidOperationException("No such role exists");


            //var roleAppointments = await _scheduleRoleAppointRepo.GetAllListAsync(e => e.Person.Id == personId && e.Role.Id == role.Id && (facilityId == null || e.Schedule.HealthFacilityOwner.Id == facilityId));

            //var schedules = new List<CdmSchedule>();

            //foreach (var roleApp in roleAppointments)
            //{
            //    if (!schedules.Exists(e => e.Id == roleApp.Schedule.Id))
            //    {
            //        schedules.Add(_scheduleRepo.Get(roleApp.Schedule.Id));
            //    }

            //}

            return schedules;
        }


    }
}
