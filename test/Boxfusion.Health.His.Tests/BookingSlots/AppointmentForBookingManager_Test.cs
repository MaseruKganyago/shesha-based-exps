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
    public class AppointmentForBookingManager_Test : BookingManagementTestBase
    {
        private readonly AppointmentForBookingManager _bookingManager;

        public AppointmentForBookingManager_Test() : base()
        {
            _bookingManager = Resolve<AppointmentForBookingManager>();
        }

        [Fact]
        public async Task Should_return_expected_number_of_available_slots()
        {
            CdmSchedule schedule = null;

            try
            {
                // Creating test data - 8 slots per day for the next 10 days
                var availability = new ScheduleAvailabilityForBooking()
                {
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 14,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun | RefListDaysOfWeek.pub,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 1,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null,
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + ":SimpleTest", availability, true);


                // Performing Assertions
                using (var uow = _uowManager.Begin())
                {
                    var avaialbleSlots = await _bookingManager.GetAllAvailableBookingSlotsAsync(schedule, RefListSlotCapacityTypes.Regular, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3).AddHours(11));
                    
                    // Has generated the expected number of slots
                    Assert.Equal(8 * 2 + 3, avaialbleSlots.Count);  // 8 slots for days 1 and 2, plus 3 slots on third day before 11am

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

        //[Fact]
        //public async Task Should_be_able_to_complete_simple_booking()
        //{
        //    var res = await _bookingManager.BookAvailableSlotAsync();

        //    try
        //    {
        //        using (var uow = _uowManager.Begin())
        //        {
        //            // Has generated the expected number of slots
        //            var regularSlots = _slotsRepository.GetAllList(e => e.Schedule.Id == schedule.Id && e.CapacityType == RefListSlotCapacityTypes.Regular);
        //            Assert.Equal(regularSlots.Count, 8);  // 8 slots generated on the Public Holiday generated 

        //            await uow.CompleteAsync();
        //        }
        //    }
        //    finally
        //    {
        //        // Clean-up Generated data
        //        CleanUpTestData_ForSchedule(schedule.Id);
        //    }
        //}

        // Should_decrement_RemainingSlots_When_a_booking_is_made
        // Should_throw_exception_booking_for_time_when_When_all_capacity_used_up
        // Should_throw_exception_is_outside_of_operating_times_or_days
        // Should_not_allow_booking_When_all_capacity_used_up
        // Should_not_allow_booking_When_Patient_is_null
        // Should_release_capacity_When_Cancel_an_appointment
        // Should_release_capacity_When_Reschedule_an_appointment
        // Should_return_only_one_slot_per_time_slot_even_When_there_are_many_available_at_that_same_same

    }
}
