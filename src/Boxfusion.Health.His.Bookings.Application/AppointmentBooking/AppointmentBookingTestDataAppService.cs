using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.Domain;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AppointmentBookingTestDataAppService : SheshaAppServiceBase //, IBookingManagementsAppService
    {
        protected IRepository<CdmSchedule, Guid> _scheduleRepository;
        protected IRepository<HisHealthFacility, Guid> _facilityRepository;
        protected IRepository<ScheduleAvailabilityForTimeBooking, Guid> _availabilityRepository;
        protected readonly BookingSlotsGenerator _bookingSlotsGenerator;
        protected IRepository<CdmSlot, Guid> _slotsRepository;
        protected IRepository<CdmPatient, Guid> _patientRepository;
        protected IRepository<CdmAppointment, Guid> _appointmentRepository;
        protected IRepository<ScheduleRoleAppointment, Guid> _scheduleRoleAppointmentRepository;
        

        public AppointmentBookingTestDataAppService(
                IRepository<CdmSchedule, Guid> scheduleRepository,
                IRepository<HisHealthFacility, Guid> facilityRepository,
                IRepository<ScheduleAvailabilityForTimeBooking, Guid> availabilityRepository,
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
            var availability = new ScheduleAvailabilityForTimeBooking()
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

            await this.CreateTestData_NewSchedule("TestSchedule1228", "TestSchedule1228", 29, availability, true);
            await this.CreateTestData_NewPatient("TestPatient1228-1");
            await this.CreateTestData_NewPatient("TestPatient1228-2");
            await this.CreateTestData_NewPatient("TestPatient1228-3");

            return new object();
        }

        [HttpGet, Route("BookingManagement/TestData/Generate2")]
        public async Task<object> GenerateTestData2()
        {
            var availability = new ScheduleAvailabilityForTimeBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 90,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 40,
                SlotOverflowCapacity = 20,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };
            await this.CreateTestData_NewSchedule("Rob Ferreira Hospital", "RFH-General Practice", 29, availability, true);

            var availability2 = new ScheduleAvailabilityForTimeBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 90,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 40,
                SlotOverflowCapacity = 20,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };
            await this.CreateTestData_NewSchedule("Rob Ferreira Hospital", "RFH-Ophthalmology", 52, availability2, true);


            var availability3 = new ScheduleAvailabilityForTimeBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 90,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 40,
                SlotOverflowCapacity = 20,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };
            await this.CreateTestData_NewSchedule("Middleburg Hospital", "Middleburg-Dermatology", 20, availability3, true);

            var availability4 = new ScheduleAvailabilityForTimeBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 90,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 40,
                SlotOverflowCapacity = 20,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };
            await this.CreateTestData_NewSchedule("Middleburg Hospital", "Middleburg-Clinical physiology", 15, availability4, true);


            var availability5 = new ScheduleAvailabilityForTimeBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 90,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 40,
                SlotOverflowCapacity = 20,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };
            await this.CreateTestData_NewSchedule("Charlotte Maxeke", "Charlotte Maxke-General Practice", 29, availability5, true);

            var availability6 = new ScheduleAvailabilityForTimeBooking()
            {
                Active = true,
                ValidFromDate = null,
                ValidToDate = null,
                BookingHorizon = 90,
                ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                SlotDuration = 60,
                BreakIntervalAfterSlot = 0,
                SlotRegularCapacity = 40,
                SlotOverflowCapacity = 20,
                LastGeneratedSlotDate = null,
                SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
            };
            await this.CreateTestData_NewSchedule("Charlotte Maxeke", "Charlotte Maxeke-Dermatology", 20, availability6, true);

            /*
General practice    29
Ophthalmology   52
Clinical physiology 15
Dermatology 20*/

            return new object();
        }


        protected async Task<CdmSchedule> CreateTestData_NewSchedule(string hospitalName, string scheduleName, int speciality, ScheduleAvailabilityForTimeBooking safb, bool generateSlots)
        {

            var hospital = await CreateTestData_HealthFacility(hospitalName);

            CdmSchedule schedule = new CdmSchedule()
            {
                Active = true,
                Name = scheduleName,
                SchedulingModel = RefListSchedulingModels.TimeBasedAppointment,
                Speciality = speciality,
                HealthFacilityOwner = hospital,
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
                var newHospital = new HisHealthFacility()
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
