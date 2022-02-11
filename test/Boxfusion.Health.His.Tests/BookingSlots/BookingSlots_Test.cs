using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Bookings.Helpers.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Tests.BookingSlots
{
    public class BookingSlots_Test : SheshaNhTestBase<HisTestModule>
    {
        private readonly IGenerateBookingSlotsHelper _generateBookingSlotsHelper;
        public List<CdmSchedule> Schedules { get; set; }
        public List<ScheduleAvailabilityForBooking> ScheduleAvailabilities { get; set; }
        public BookingSlots_Test()
        {            
            _generateBookingSlotsHelper = Resolve<IGenerateBookingSlotsHelper>();
            Schedules = new List<CdmSchedule>();
            ScheduleAvailabilities = new List<ScheduleAvailabilityForBooking>();
        }

        [Fact]
        public async Task Should_Getschedules()
        {
            LoginAsHost("admin");
            Schedules = await _generateBookingSlotsHelper.Getschedules();

            Assert.NotNull(Schedules);

           
        }
       
        [Fact]
        public async Task Should_GetscheduleAvailability()
        {
            LoginAsHost("admin");
            foreach (var schedule in Schedules)
            {
                ScheduleAvailabilities.AddRange(await _generateBookingSlotsHelper.GetscheduleAvailability(schedule));
            }

            Assert.NotNull(ScheduleAvailabilities);
        }

        [Fact]
        public async Task Should_Have_ApplicableDays()
        {
            foreach(var scheduleAvailability in ScheduleAvailabilities)
            {
                Assert.NotNull(scheduleAvailability.ApplicableDays);
            }
        } 

        [Fact]
        public async Task ApplicableDays_Should_Not_Fall_On_Public_Holiday()
        {
            foreach(var scheduleAvailability in ScheduleAvailabilities)
            {
                Assert.True(scheduleAvailability.ApplicableDays != RefListDaysOfWeek.pub);
            }
        }

        [Fact]
        public async Task LastGeneratedSlotDateShouldbeBiggerThanValidFromDate()
        {
            foreach (var scheduleAvailability in ScheduleAvailabilities)
            {
                Assert.True(scheduleAvailability.LastGeneratedSlotDate > scheduleAvailability.ValidFromDate);
            }
        }
        
        [Fact]
        public async Task LastGeneratedSlotDateShouldbeSmallerThanValidFromDate()
        {
            foreach (var scheduleAvailability in ScheduleAvailabilities)
            {
                Assert.True(scheduleAvailability.LastGeneratedSlotDate > scheduleAvailability.ValidToDate);
            }
        }
    }
}
