using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Tests;
using Boxfusion.Health.His.Tests;
using Shesha.Domain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Bookings.Schedules
{
    public class BookingSlotsGenerator_Test : BookingManagementTestBase
    {


        public BookingSlotsGenerator_Test() : base()
        {
            CreateTestData_HealthFacility(this.GetType().Name);
        }

        [Fact]
        public async Task Should_Generate_8_Slots_per_day_When_8_hour_day_with_no_breaks()
        {
            //Creating the test data
            var safb = new ScheduleAvailabilityForTimeBooking()
            {
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

            var schedule = await CreateTestData_NewSchedule(this.GetType().Name + "Test1", safb, true);

            try
            {
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var slots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id);
                   slots.Count.ShouldBe((14 + 1) * 8);  // 8 slots generated per day from today + the 14 day window

                    var updatedSafb = _availabilityRepository.Get(safb.Id);

                    // LastGeneratedSlotDate end of day of the last day of the booking horizon
                    updatedSafb.LastGeneratedSlotDate.ShouldBe(DateTime.Now.Date.AddDays(safb.BookingHorizon.Value).Add(safb.EndTime.Value));

                    //no slots after LastGeneratedDate
                    slots.Count(e => e.StartDateTime > updatedSafb.LastGeneratedSlotDate).ShouldBe(0);

                    // Not slots generated beyond the Horizon
                    slots.Count(e => e.StartDateTime.Value.Date > DateTime.Now.Date.AddDays(safb.BookingHorizon.Value)).ShouldBe(0);

                    // Does not generate slots that end after the end of day
                    slots.Count(e => e.EndDateTime.Value.TimeOfDay > safb.EndTime).ShouldBe(0);

                    // Does not generate slots that start before the start of day
                    slots.Count(e => e.StartDateTime.Value.TimeOfDay < safb.StartTime).ShouldBe(0);

                    // First slot always starts at the start of the day
                    slots.Count(e => e.StartDateTime.Value.TimeOfDay == safb.StartTime).ShouldBe(15);

                    // No Overflow slots since Overflow capacity specified as 0
                    slots.Count(e => e.OverflowCapacity > 0).ShouldBe(0);

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                CleanUpTestData_ForSchedule(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_Generate_6_Slots_per_day_When_have_15_min_break()
        {
            CdmSchedule schedule = null;
            try
            {
                //Creating the test data
                var safb = new ScheduleAvailabilityForTimeBooking()
                {
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

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + "Test2", safb, true);

                // Perform Assertions
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var slots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id);
                   slots.Count.ShouldBe((14 + 1) * 6);  // 6 slots generated per day from today + the 14 day window

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_generate_Overflow_slots_When_OverflowCapacity_is_configured()
        {
            CdmSchedule schedule = null;
            try
            {
                //Creating the test data
                var safb = new ScheduleAvailabilityForTimeBooking()
                {
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

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + "Test3", safb, true);

                // Perform Assertions
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var slots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id);
                    slots.Count.ShouldBe((14 + 1) * 6);  // 6 slots generated per day from today + the 14 day window
                    slots.ForEach(o => o.RegularCapacity.ShouldBe(10));
                    slots.ForEach(o => o.OverflowCapacity.ShouldBe(5));

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_Generate_1_slot_per_resource_When_GenerationMode_is_OneSlotPerResource()
        {
            CdmSchedule schedule = null;
            try
            {
                //Creating the test data
                var safb = new ScheduleAvailabilityForTimeBooking()
                {
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

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + "Test4", safb, true);

                // Perform Assertions
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.Count(e => e.Schedule.Id == schedule.Id && e.RegularCapacity == 1);
                    regularSlots.ShouldBe((14 + 1) * 8 * 5);  // 8 time slots generated per day from today + the 14 day window * 5 slots for time

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_not_generate_slots_outside_of_validity_dates()
        {
            CdmSchedule schedule = null;
            try
            {
                //Creating the test data
                var safb = new ScheduleAvailabilityForTimeBooking()
                {
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

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + "Test5", safb, true);

                // Perform Assertions
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id);
                    regularSlots.Count.ShouldBe(((safb.ValidToDate.Value - safb.ValidFromDate.Value).Days + 1) * 8);  // 8 slots generated per day on the validity period

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);
            }
        }

        [Fact]
        public async Task Should_apply_public_holiday_ScheduleAvailability_When_PublicHoliday_falls_within_generation_horizon()
        {
            CdmSchedule schedule = null;
            try
            {
                //Creating the test data


                // Creating some holidays
                using (var uow = _uowManager.Begin())
                {
                    var holiday1 = new PublicHoliday()
                    {
                        Date = DateTime.Now.Date.AddDays(2),
                        Name = "Test6: Holiday 1"
                    };
                    _holidayRepository.Insert(holiday1);

                    var holiday2 = new PublicHoliday()
                    {
                        Date = DateTime.Now.Date.AddDays(5),
                        Name = "Test6: Holiday 2"
                    };

                    _holidayRepository.Insert(holiday2); 
                    
                    uow.Complete();
                }

                var safb = new ScheduleAvailabilityForTimeBooking()
                {
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

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + "Test6", safb, true);

                // Perform Assertions
                using (var uow = _uowManager.Begin())
                {
                    // Has generated the expected number of slots
                    var regularSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id);
                    regularSlots.Count.ShouldBe(8 * 2);  // 8 slots generated on each of the two Public Holiday generated 

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                {
                    CleanUpTestData_ForSchedule(schedule.Id);
                    CleanUpTestData_ForPublicHolidays("Test6");
                }
            }
        }

    }
}
