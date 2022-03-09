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
                    Assert.Equal(3, slot.Capacity);
                    Assert.Equal(3, slot.RemainingCapacity);

                    // Making two bookings so can then check if RemainingCapacity has decreased as expected.
                    var app1 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    var app2 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");

                    Assert.Equal(RefListAppointmentStatuses.booked, app1.Status);
                    Assert.Equal(bookingTime, app1.Start);

                    await uow.CompleteAsync();
                }

                Guid slotId;
                using (var uow = _uowManager.Begin())
                {
                    var avaialbleSlots = await _bookingManager.GetAllAvailableBookingSlotsAsync(schedule.Id, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2));
                    var slot = avaialbleSlots.Find(e => e.StartDateTime == bookingTime);
                    slotId = slot.Id;
                    Assert.Equal(3, slot.Capacity);
                    Assert.Equal(1, slot.RemainingCapacity);

                    // Making another booking to fully exhaust the capacity
                    var app3 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    var slot = _slotsRepository.Get(slotId);
                    Assert.Equal(0, slot.RemainingCapacity);

                    // Try to make a booking knowing that no longer have capacity.
                    await Assert.ThrowsAnyAsync<InvalidOperationException>(async () => 
                    {
                        await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    });

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
        public async Task Should_not_be_able_to_book_Regular_Slot_When_only_Overflow_capacity_is_available()
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
                    SlotRegularCapacity = 0,
                    SlotOverflowCapacity = 3,
                    LastGeneratedSlotDate = null,
                    SlotGenerationMode = RefListSlotGenerationModes.OneSlotPerResource,
                };

                schedule = await CreateTestData_NewSchedule(this.GetType().Name + ":Test4", availability, true);
                patient = await CreateTestData_NewPatient(this.GetType().Name + ":Test4");

                // Performing Assertions
                var bookingTime = DateTime.Now.Date.AddDays(1).AddHours(8);
                CdmAppointment app1;
                using (var uow = _uowManager.Begin())
                {
                    // Expecting to be able to make Overflow bookings
                    app1 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    var app2 = await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    Assert.NotEqual(app1.Slot, app2.Slot);  // Since using SlotGenerationMode = RefListSlotGenerationModes.OneSlotPerResource would expect Slot.Id to be different even though bookings are for the same time.
                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                   // Try to make a booking for Regular capacity.
                    await Assert.ThrowsAnyAsync<InvalidOperationException>(async () =>
                    {
                        await _bookingManager.BookAvailableSlotAsync(schedule.Id, bookingTime, null, patient.Id, "", "");
                    });

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

                    Assert.Equal(RefListAppointmentStatuses.booked, app.Status);
                }

                using (var uow = _uowManager.Begin())
                {
                    // Checking that capacity has decreased by one on the slot.
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    Assert.Equal(slot.Capacity - 1, slot.RemainingCapacity);

                    // Cancelling appointment and checking if status has been updated.
                    var app2 = await _bookingManager.CancelAppointment(app.Id);

                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    // Confirming that capacity has been released
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    Assert.Equal(slot.Capacity, slot.RemainingCapacity);
                    var app2 = await _appointmentRepository.GetAsync(app.Id);
                    Assert.Equal(RefListAppointmentStatuses.cancelled, app2.Status);

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

                    Assert.Equal(RefListAppointmentStatuses.booked, app.Status);
                }

                CdmAppointment newApp;
                using (var uow = _uowManager.Begin())
                {
                    // Checking that capacity has decreased by one on the slot.
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    Assert.Equal(slot.Capacity - 1, slot.RemainingCapacity);

                    // Reschedule appointment and checking if status has been updated.
                    newApp = await _bookingManager.RescheduleAppointment(app.Id, newBookingTime, "", "");

                    await uow.CompleteAsync();
                }

                using (var uow = _uowManager.Begin())
                {
                    // Confirming that capacity on original slot has been released
                    var slot = await _slotsRepository.GetAsync(app.Slot.Id);
                    Assert.Equal(slot.Capacity, slot.RemainingCapacity);

                    // Retrieving the new appointment and ensuring key properties are as expected
                    var newApp2 = await _appointmentRepository.GetAsync(newApp.Id);
                    Assert.Equal(RefListAppointmentStatuses.booked, newApp2.Status);
                    Assert.Equal(newBookingTime, newApp2.Start);

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
