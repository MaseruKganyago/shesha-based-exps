using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Helpers.Slots;
using Boxfusion.Health.His.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.BookingManagement.Tests
{
    public class ScheduleManager_Test : SheshaNhTestBase
    {
        private readonly IGenerateBookingSlotsHelper _generateBookingSlotsHelper;
        private readonly ScheduleManager _scheduleManager;
        private IRepository<CdmSchedule, Guid> _scheduleRepository;
        private IRepository<Hospital, Guid> _facilityRepository;
        private IRepository<ScheduleAvailabilityForBooking, Guid> _safbRepository;
        private IRepository<CdmSlot, Guid> _slotsRepository;
        private IUnitOfWorkManager _uowManager;

        public ScheduleManager_Test()
        {
            _scheduleRepository = Resolve<IRepository<CdmSchedule, Guid>>();
            _facilityRepository = Resolve<IRepository<Hospital, Guid>>();
            _safbRepository = Resolve<IRepository<ScheduleAvailabilityForBooking, Guid>>();
            _slotsRepository = Resolve<IRepository<CdmSlot, Guid>>();

            _generateBookingSlotsHelper = Resolve<IGenerateBookingSlotsHelper>();

            _uowManager = Resolve<IUnitOfWorkManager>();
            //   _generateBookingSlotsHelper = Resolve<>();

            //_generateBookingSlotsHelper = Resolve<IGenerateBookingSlotsHelper>();

            _scheduleManager = Resolve<ScheduleManager>();

            SeedTestData();
        }

        [Fact]
        public async Task Should_HaveSchedulesInDB_When_Starting()
        {
            LoginAsHost("admin");


            using (var uow = _uowManager.Begin())
            {
                var res = _scheduleRepository.GetAll().Count();
                await uow.CompleteAsync();

                Assert.True(res > 0);
            }
        }

        [Fact]
        public async Task Should_Generate_8_Slots_per_day_When_8_hour_day_with_no_breaks()
        {
            var testId = "Test64";

            CdmSchedule schedule;
            ScheduleAvailabilityForBooking safb;

            // Setting up test data
            using (var uow = _uowManager.Begin())
            {
                schedule = CreateNewSchedule(testId);

                safb = new ScheduleAvailabilityForBooking()
                {
                    Schedule = schedule,
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 10,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null, // May want to manipulate
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };
                safb = _safbRepository.Insert(safb);
                uow.Complete();
            }

            using (var uow = _uowManager.Begin())
            {
                // Generate Slots
                await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);

                uow.Complete();
            }

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var slots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id);
                    Assert.Equal(slots.Count, (14 + 1) * 8);  // 8 slots generated per day from today + the 14 day window

                    var updatedSafb = _safbRepository.Get(safb.Id);

                    // LastGeneratedSlotDate end of day of the last day of the booking horizon
                    Assert.True(updatedSafb.LastGeneratedSlotDate == DateTime.Now.Date.AddDays(safb.BookingHorizon.Value).Add(safb.EndTime.Value));

                    //no slots after LastGeneratedDate
                    Assert.True(slots.Count(e => e.StartDateTime > updatedSafb.LastGeneratedSlotDate) == 0);

                    // Not slots generated beyond the Horizon
                    Assert.True(slots.Count(e => e.StartDateTime.Value.Date > DateTime.Now.Date.AddDays(safb.BookingHorizon.Value)) == 0);

                    // Does not generate slots that end after the end of day
                    Assert.True(slots.Count(e => e.EndDateTime.Value.TimeOfDay > safb.EndTime) == 0);

                    // Does not generate slots that start before the start of day
                    Assert.True(slots.Count(e => e.StartDateTime.Value.TimeOfDay < safb.StartTime) == 0);

                    // First slot always starts at the start of the day
                    Assert.True(slots.Count(e => e.StartDateTime.Value.TimeOfDay == safb.StartTime) == 15);

                    // No Overflow slots since Overflow capacity specified as 0
                    Assert.True(slots.Count(e => e.CapacityType == RefListSlotCapacityTypes.Overflow) == 0);

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_Generate_6_Slots_per_day_When_have_15_min_break()
        {
            var testId = "Test147";

            CdmSchedule schedule;
            ScheduleAvailabilityForBooking safb;

            // Setting up test data
            using (var uow = _uowManager.Begin())
            {
                schedule = CreateNewSchedule(testId);

                safb = new ScheduleAvailabilityForBooking()
                {
                    Schedule = schedule,
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 15,
                    SlotRegularCapacity = 10,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null, // May want to manipulate
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };
                safb = _safbRepository.Insert(safb);

                uow.Complete();
            }

            using (var uow = _uowManager.Begin())
            {
                // Generate Slots
                await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);
                uow.Complete();
            }

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var slots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Regular);
                    Assert.Equal(slots.Count, (14 + 1) * 6);  // 6 slots generated per day from today + the 14 day window

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_generate_Overflow_slots_When_OverflowCapacity_is_configured()
        {
            var testId = "Test211";

            CdmSchedule schedule;
            ScheduleAvailabilityForBooking safb;

            // Setting up test data
            using (var uow = _uowManager.Begin())
            {
                schedule = CreateNewSchedule(testId);

                safb = new ScheduleAvailabilityForBooking()
                {
                    Schedule = schedule,
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 15,
                    SlotRegularCapacity = 10,
                    SlotOverflowCapacity = 5,
                    LastGeneratedSlotDate = null, // May want to manipulate
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };
                safb = _safbRepository.Insert(safb);

                uow.Complete();
            }

            using (var uow = _uowManager.Begin())
            {
                // Generate Slots
                await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);
                uow.Complete();
            }

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Regular);
                    Assert.Equal(regularSlots.Count, (14 + 1) * 6);  // 6 slots generated per day from today + the 14 day window

                    var overflowSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Overflow);
                    Assert.Equal(overflowSlots.Count, (14 + 1) * 6);  // 6 slots generated per day from today + the 14 day window

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_Generate_1_slot_per_resource_When_GenerationMode_is_OneSlotPerResource()
        {
            var testId = "Test276";

            CdmSchedule schedule;
            ScheduleAvailabilityForBooking safb;

            // Setting up test data
            using (var uow = _uowManager.Begin())
            {
                schedule = CreateNewSchedule(testId);

                safb = new ScheduleAvailabilityForBooking()
                {
                    Schedule = schedule,
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 5,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null, // May want to manipulate
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotPerResource,
                };
                safb = _safbRepository.Insert(safb);

                uow.Complete();
            }

            using (var uow = _uowManager.Begin())
            {
                // Generate Slots
                await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);
                uow.Complete();
            }

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.Count(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Regular && e.Capacity == 1);
                    Assert.Equal(regularSlots, (14 + 1) * 8 * 5);  // 8 time slots generated per day from today + the 14 day window * 5 slots for time

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_not_generate_slots_outside_of_validity_dates()
        {
            var testId = "Test341";

            CdmSchedule schedule;
            ScheduleAvailabilityForBooking safb;

            // Setting up test data
            using (var uow = _uowManager.Begin())
            {
                schedule = CreateNewSchedule(testId);

                safb = new ScheduleAvailabilityForBooking()
                {
                    Schedule = schedule,
                    Active = true,
                    ValidFromDate = DateTime.Now.Date.AddDays(2),
                    ValidToDate = DateTime.Now.Date.AddDays(4),
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 10,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null, // May want to manipulate
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };
                safb = _safbRepository.Insert(safb);

                uow.Complete();
            }

            using (var uow = _uowManager.Begin())
            {
                // Generate Slots
                await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);
                uow.Complete();
            }

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Regular);
                    Assert.Equal(regularSlots.Count, ((safb.ValidToDate.Value - safb.ValidFromDate.Value).Days + 1) * 8);  // 8 slots generated per day on the validity period

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_apply_public_holiday_ScheduleAvailability_When_PublicHoliday_falls_within_generation_horizon()
        {
            var testId = "Test400";

            CdmSchedule schedule;
            ScheduleAvailabilityForBooking safb;

            // Setting up test data
            using (var uow = _uowManager.Begin())
            {
                schedule = CreateNewSchedule(testId);

                safb = new ScheduleAvailabilityForBooking()
                {
                    Schedule = schedule,
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.pub,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 10,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null, // May want to manipulate
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };
                safb = _safbRepository.Insert(safb);

                //********************************************
                //TODO: NEED TO ADD ONE PUBLIC HOLIDAY WITHIN THE 14 DAY HORIZON
                //********************************************

                uow.Complete();
            }

            using (var uow = _uowManager.Begin())
            {
                // Generate Slots
                await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);
                uow.Complete();
            }

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Regular);
                    Assert.Equal(regularSlots.Count, 8);  // 8 slots generated on the Public Holiday generated 

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(schedule.Id);
            }
        }


        /// <summary>
        /// NOTE: This should NOT be async to ensure that Tests do not execute before completion of Data Seeding.
        /// </summary>
        private void SeedTestData()
        {
            LoginAsHost("admin");

            // Checking if test data has previously been added
            var hostpital = _facilityRepository.FirstOrDefault(e => e.Name == "ScheduleManager_Test");
            if (hostpital is null)
            {
                using (var uow = _uowManager.Begin())
                {
                    var newHospital = new Hospital()
                    {
                        Name = "ScheduleManager_Test",
                    };
                    newHospital = _facilityRepository.Insert(newHospital);

                    uow.Complete();
                }
            }
        }

        private CdmSchedule CreateNewSchedule(string testId)
        {
            var hostpital = _facilityRepository.FirstOrDefault(e => e.Name == "ScheduleManager_Test");
            var newSchedule = new CdmSchedule()
            {
                Active = true,
                Name = "ScheduleManager_Test:" + testId,
                ActorOwnerId = hostpital.Id.ToString(),
                ActorOwnerType = "His.HisHospital",
                SchedulingModel = RefListSchedulingModels.Appointment,
            };
            newSchedule = _scheduleRepository.Insert(newSchedule);

            return newSchedule;
        }

        private void CleanUpGeneratedTestData(Guid scheduleId)
        {
            using (var session = OpenSession())
            {
                //result = func(session);
                var query = session.CreateSQLQuery("DELETE FROM Fhir_Slots WHERE ScheduleId = '" + scheduleId.ToString() + "'");
                query.ExecuteUpdate(); 
                query = session.CreateSQLQuery("DELETE FROM Fhir_ScheduleAvailabilities WHERE ScheduleId = '" + scheduleId.ToString() + "'");
                query.ExecuteUpdate(); 
                query = session.CreateSQLQuery("DELETE FROM Fhir_Schedules WHERE Id = '" + scheduleId.ToString() + "'");
                query.ExecuteUpdate();

                session.Flush();
            }
        }

    }
}
