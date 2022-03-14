using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Tests;
using Boxfusion.Health.His.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    public class AppointmentBookingManager_Test : BookingManagementTestBase
    {
        private readonly AppointmentBookingManager _bookingManager;

        public AppointmentBookingManager_Test() : base()
        {
            _bookingManager = Resolve<AppointmentBookingManager>();
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
                    var avaialbleSlots = await _bookingManager.GetAllAvailableBookingSlotsAsync(schedule.Id, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3).AddHours(11));

                    // Has generated the expected number of slots
                    avaialbleSlots.Count.ShouldBe(8 * 2 + 3);  // 8 slots for days 1 and 2, plus 3 slots on third day before 11am

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
        public async Task Should_return_expected_number_of_available_slots_even_when_several_slots_for_same_times()
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
                    SlotRegularCapacity = 3,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null,
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotPerResource,
                };

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + ":Test2", availability, true);


                // Performing Assertions
                using (var uow = _uowManager.Begin())
                {
                    var avaialbleSlots = await _bookingManager.GetAllAvailableBookingSlotsAsync(schedule.Id, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3).AddHours(11));

                    // Has generated the expected number of slots
                    avaialbleSlots.Count.ShouldBe(8 * 2 + 3);  // 8 slots for days 1 and 2, plus 3 slots on third day before 11am

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
        public async Task Should_be_able_to_book_and_exhaust_capacity()
        {
            CdmSchedule schedule = null;
            CdmPatient patient = null;

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
                    SlotRegularCapacity = 3,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null,
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + ":Test3", availability, true);
                patient = await CreateTestData_NewPatient(this.GetType().Name + ":Test3");

                // Performing Assertions
                var bookingTime = DateTime.Now.Date.AddDays(1).AddHours(8);
                using (var uow = _uowManager.Begin())
                {
                    var avaialbleSlots = await _bookingManager.GetAllAvailableBookingSlotsAsync(schedule.Id, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2));

                    // Confirming have expected capacity
                    var slot = avaialbleSlots.Find(e => e.StartDateTime == bookingTime);
                    slot.Capacity.ShouldBe(3);
                    slot.RemainingCapacity.ShouldBe(3);

                    // Making two bookings so can then check if RemainingCapacity has decreased as expected.
                    var app1 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    var app2 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");

                    app1.Status.ShouldBe(RefListAppointmentStatuses.booked);
                    app1.Start.ShouldBe(bookingTime);

                    await uow.CompleteAsync();
                }

                Guid slotId;
                using (var uow = _uowManager.Begin())
                {
                    var avaialbleSlots = await _bookingManager.GetAllAvailableBookingSlotsAsync(schedule.Id, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2));
                    var slot = avaialbleSlots.Find(e => e.StartDateTime == bookingTime);
                    slotId = slot.Id;
                    slot.Capacity.ShouldBe(3);
                    slot.RemainingCapacity.ShouldBe(1);

                    // Making another booking to fully exhaust the capacity
                    var app3 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    var slot = _slotsRepository.Get(slotId);
                    slot.RemainingCapacity.ShouldBe(0);

                    // Try to make a booking knowing that no longer have capacity.
                    var res = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    res.ShouldBeNull();

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);

                if (patient is not null)
                    CleanUpTestData_Patient(patient.Id);
            }
        }

        [Fact]
        public async Task Should_be_able_to_Cancel_appointment_and_release_capacity()
        {
            CdmSchedule schedule = null;
            CdmPatient patient = null;

            try
            {
                // Creating test data - 8 slots per day for the next 10 days
                var availability = new ScheduleAvailabilityForBooking()
                {
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 5,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun | RefListDaysOfWeek.pub,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 3,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null,
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + ":Test5", availability, true);
                patient = await CreateTestData_NewPatient(this.GetType().Name + ":Test5");

                // Performing Assertions
                var bookingTime = DateTime.Now.Date.AddDays(1).AddHours(8);
                CdmAppointment app;
                using (var uow = _uowManager.Begin())
                {
                    // Book an appointment
                    app = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    await uow.CompleteAsync();
                    app.Status.ShouldBe(RefListAppointmentStatuses.booked);
                }

                using (var uow = _uowManager.Begin())
                {
                    // Checking that capacity has decreased by one on the slot.
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    slot.RemainingCapacity.ShouldBe(slot.Capacity.Value - 1);

                    // Cancelling appointment and checking if status has been updated.
                    var app2 = await _bookingManager.CancelAppointment(app.Id);

                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    // Confirming that capacity has been released
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    slot.RemainingCapacity.ShouldBe(slot.Capacity.Value);
                    var app2 = await _appointmentRepository.GetAsync(app.Id);
                    app2.Status.ShouldBe(RefListAppointmentStatuses.cancelled);

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);

                if (patient is not null)
                    CleanUpTestData_Patient(patient.Id);
            }
        }


        [Fact]
        public async Task Should_be_able_to_Reschedule_appointment_ensure_release_capacity()
        {
            CdmSchedule schedule = null;
            CdmPatient patient = null;

            try
            {
                // Creating test data - 8 slots per day for the next 10 days
                var availability = new ScheduleAvailabilityForBooking()
                {
                    Active = true,
                    ValidFromDate = null,
                    ValidToDate = null,
                    BookingHorizon = 5,
                    ApplicableDays = RefListDaysOfWeek.mon | RefListDaysOfWeek.tue | RefListDaysOfWeek.wed | RefListDaysOfWeek.thu | RefListDaysOfWeek.fri | RefListDaysOfWeek.sat | RefListDaysOfWeek.sun | RefListDaysOfWeek.pub,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    SlotDuration = 60,
                    BreakIntervalAfterSlot = 0,
                    SlotRegularCapacity = 3,
                    SlotOverflowCapacity = 0,
                    LastGeneratedSlotDate = null,
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotForAllResources,
                };

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + ":Test6", availability, true);
                patient = await CreateTestData_NewPatient(this.GetType().Name + ":Test6");

                // Performing Assertions
                var bookingTime = DateTime.Now.Date.AddDays(1).AddHours(8);
                var newBookingTime = bookingTime.AddDays(1);
                CdmAppointment app;
                using (var uow = _uowManager.Begin())
                {
                    // Book an appointment
                    app = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    await uow.CompleteAsync();

                    app.Status.ShouldBe(RefListAppointmentStatuses.booked);
                }

                CdmAppointment newApp;
                using (var uow = _uowManager.Begin())
                {
                    // Checking that capacity has decreased by one on the slot.
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    slot.RemainingCapacity.ShouldBe(slot.Capacity.Value - 1);

                    // Reschedule appointment and checking if status has been updated.
                    newApp = await _bookingManager.RescheduleAppointment(app.Id, newBookingTime, "", "");

                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    // Confirming that capacity on original slot has been released
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    slot.RemainingCapacity.ShouldBe(slot.Capacity.Value);

                    // Retrieving the new appointment and ensuring key properties are as expected
                    var newApp2 = await _appointmentRepository.GetAsync(newApp.Id);
                    newApp2.Status.ShouldBe(RefListAppointmentStatuses.booked);
                    newApp2.Start.ShouldBe(newBookingTime);

                    await uow.CompleteAsync();
                }
            }
            finally
            {
                // Clean-up Generated data
                if (schedule is not null)
                    CleanUpTestData_ForSchedule(schedule.Id);

                if (patient is not null)
                    CleanUpTestData_Patient(patient.Id);
            }
        }

    }
}
