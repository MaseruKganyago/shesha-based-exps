using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Domain.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AppointmentBookingTestDataAppService : CdmAppServiceBase //, IBookingManagementsAppService
    {
        protected IRepository<CdmSchedule, Guid> _scheduleRepository;
        protected IRepository<HisHospital, Guid> _facilityRepository;
        protected IRepository<ScheduleAvailabilityForBooking, Guid> _availabilityRepository;
        protected readonly BookingSlotsGenerator _bookingSlotsGenerator;
        protected IRepository<CdmSlot, Guid> _slotsRepository;
        protected IRepository<CdmPatient, Guid> _patientRepository;
        protected IRepository<CdmAppointment, Guid> _appointmentRepository;
        protected IRepository<ScheduleRoleAppointment, Guid> _scheduleRoleAppointmentRepository;
        

        public AppointmentBookingTestDataAppService(
                IRepository<CdmSchedule, Guid> scheduleRepository,
                IRepository<HisHospital, Guid> facilityRepository,
                IRepository<ScheduleAvailabilityForBooking, Guid> availabilityRepository,
                IRepository<CdmSlot, Guid> slotsRepository,
                IRepository<CdmPatient, Guid> patientRepository,
                IRepository<CdmAppointment, Guid> appointmentRepository,
                IRepository<ScheduleRoleAppointment, Guid> scheduleRoleAppointmentRepository,
                BookingSlotsGenerator bookingSlotsGenerator
            )
        {
            _scheduleRepository = scheduleRepository;
            _facilityRepository = facilityRepository;
            _availabilityRepository = availabilityRepository;
            _bookingSlotsGenerator = bookingSlotsGenerator;
            _slotsRepository = slotsRepository;
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
            _scheduleRoleAppointmentRepository = scheduleRoleAppointmentRepository;
        }


        [HttpGet, Route("BookingManagement/TestData/Generate")]
        //[AbpAuthorize(PermissionNames.DailyAppointmentBooking)]
        public async Task<object> GenerateTestData()
        {
            var availability = new ScheduleAvailabilityForBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 14,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 10,
                SlotOverflowCapacity = 3,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };

            await this.CreateTestData_NewSchedule("TestSchedule1228", availability, true);
            await this.CreateTestData_NewPatient("TestPatient1228-1");
            await this.CreateTestData_NewPatient("TestPatient1228-2");
            await this.CreateTestData_NewPatient("TestPatient1228-3");

            return new object();
        }

        protected async Task<CdmSchedule> CreateTestData_NewSchedule(string scheduleName, ScheduleAvailabilityForBooking safb, bool generateSlots)
        {

            var hospital = await CreateTestData_HealthFacility("TestHospital1228");

            CdmSchedule schedule = new CdmSchedule()
            {
                Active = true,
                Name = scheduleName,
                SchedulingModel = RefListSchedulingModels.Appointment,
                ActorOwnerId = hospital.Id.ToString(),
                ActorOwnerType = "His.HisHospital"
            };
            schedule = await _scheduleRepository.InsertAsync(schedule);

            safb.Schedule = schedule;

            safb = await _availabilityRepository.InsertAsync(safb);

            //Schedule Manager
            var roleRepo = Abp.Dependency.IocManager.Instance.Resolve<IRepository<ShaRole, Guid>>();
            var scheduleManagerRole = await roleRepo.FirstOrDefaultAsync(e => e.Name == "Schedule Manager");

            await _scheduleRoleAppointmentRepository.InsertAsync(new ScheduleRoleAppointment()
            {
                Schedule = schedule,
                Person = await this.GetCurrentPersonAsync(),
                Role = scheduleManagerRole
            });

            await this.CurrentUnitOfWork.SaveChangesAsync(); // Needs to commit changes to the DB or else won't be available for the SlotGeneration Logic


            if (generateSlots)
            {
                // Generate Slots
                await _bookingSlotsGenerator.GenerateBookingSlotsForScheduleAsync(schedule);
            }

            return schedule;
        }

        protected async Task<Hospital> CreateTestData_HealthFacility(string name)
        {
            // Checking if test data has previously been added
            var hostpital = await _facilityRepository.FirstOrDefaultAsync(e => e.Name == name);
            if (hostpital is null)
            {
                var newHospital = new HisHospital()
                {
                    Name = name,
                };
                newHospital = await _facilityRepository.InsertAsync(newHospital);
                return newHospital;
            }
            else
                return hostpital;
        }

        protected async Task<CdmPatient> CreateTestData_NewPatient(string name)
        {
            HisPatient patient = new HisPatient()
            {
                FirstName = name,
                LastName = name
            };
            return await _patientRepository.InsertAsync(patient);
        }
    }
}
