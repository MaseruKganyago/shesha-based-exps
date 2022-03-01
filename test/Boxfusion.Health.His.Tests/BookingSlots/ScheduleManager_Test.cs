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
            var testId = System.Reflection.MethodBase.GetCurrentMethod().Name.GetHashCode().ToString(); // Gets a unique id based on current method name

            CleanUpGeneratedTestData(testId);

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
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat| RefListDaysOfWeek.sun,
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

            try
            {
                // Generate Slots
                //await _scheduleManager.GenerateBookingSlotsForScheduleAsync(schedule);
                await _generateBookingSlotsHelper.GenerateBookingSlotsForScheduleAsync(schedule);

                // Assertions
                var slots = _slotsRepository.GetAllList(e => e.Schedule == schedule);
                Assert.Equal(slots.Count, 14 * 8);  // 8 slots generated per day over the 14 day window

                var updatedSafb = _safbRepository.Get(safb.Id);

                // LastGeneratedSlotDate within range expected
                Assert.True(updatedSafb.LastGeneratedSlotDate > DateTime.Now.AddDays(safb.BookingHorizon.Value - 1));
                Assert.True(updatedSafb.LastGeneratedSlotDate < DateTime.Now.AddDays(safb.BookingHorizon.Value + 1));

                //no slots after LastGeneratedDate
                Assert.True(slots.Count(e => e.StartDateTime > updatedSafb.LastGeneratedSlotDate) == 0);

                // Not slots generated beyond the Horizon
                Assert.True(slots.Count(e => e.StartDateTime > DateTime.Now.Date.AddDays(safb.BookingHorizon.Value)) == 0);

                // Does not generate slots that end after the end of day
                Assert.True(slots.Count(e => e.EndDateTime.Value.TimeOfDay > safb.EndTime) == 0);

                // Does not generate slots that start before the start of day
                Assert.True(slots.Count(e => e.StartDateTime.Value.TimeOfDay < safb.StartTime) == 0);

                // First slot always starts at the start of the day
                Assert.True(slots.Count(e => e.StartDateTime.Value.TimeOfDay == safb.StartTime) == 14);

                // No Overflow slots since Overflow capacity specified as 0
                Assert.True(slots.Count(e => e.CapacityType == RefListSlotCapacityTypes.Overflow) == 0);
            }
            finally
            {
                // Clean-up Generated data
                CleanUpGeneratedTestData(testId);
            }
        }


        ///     Should not generate before the last Generated date
        /// Should_Generate_6_Slots_per_day_When_have_15_min_break
        /// Should_generate_Overflow_slots_When_OverflowCapacity_is_configured
        /// Should_apply_public_holiday_ScheduleAvailability_When_PublicHoliday_falls_within_generation_horizon
        /// Should_Generate_1_slot_per_resource_When_GenerationMode_is_OneSlotPerResource
        /// Should_not_generate_slots_after_the_ValidToDate
        /// Should_not_generate_slots_before_the_ValidFromDate


        /// <summary>
        /// NOTE: This should NOT be async to ensure that Tests do not execute before completion of Data Seeding.
        /// </summary>
        private void SeedTestData()
        {
            LoginAsHost("admin");

            // Checking if test data has previously been added
            if (_scheduleRepository.Count(e => e.Name.StartsWith("ScheduleManager_Test")) == 0)
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


        private void CleanUpGeneratedTestData(string testId)
        {
            //LoginAsHost("admin");

            using (var uow = _uowManager.Begin())
            {
                var schedules = _scheduleRepository.GetAllList(e => e.Name.StartsWith("ScheduleManager_Test:" + testId));
                foreach (var schedule in schedules)
                {
                    var safbs =  _safbRepository.GetAllList(e => e.Schedule == schedule);
                    foreach (var safb in safbs)
                    {
                        var slots = _slotsRepository.GetAllList(e => e.Schedule == schedule);
                        foreach (var slot in slots)
                        {
                            _slotsRepository.HardDelete(slot);
                        }

                        _safbRepository.HardDelete(safb);
                    }

                    _scheduleRepository.HardDelete(schedule);
                }

                uow.CompleteAsync();
            }
        }

    }
}
