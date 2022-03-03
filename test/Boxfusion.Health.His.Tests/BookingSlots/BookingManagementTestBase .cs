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
    public class BookingManagementTestBase : SheshaNhTestBase
    {
        protected IRepository<CdmSchedule, Guid> _scheduleRepository;
        protected IRepository<Hospital, Guid> _facilityRepository;
        protected IRepository<ScheduleAvailabilityForBooking, Guid> _availabilityRepository;
        protected readonly BookingSlotsGenerator _bookingSlotsGenerator;
        protected IRepository<CdmSlot, Guid> _slotsRepository;
        protected IUnitOfWorkManager _uowManager;

        public BookingManagementTestBase()
        {
            _scheduleRepository = Resolve<IRepository<CdmSchedule, Guid>>();
            _facilityRepository = Resolve<IRepository<Hospital, Guid>>();
            _availabilityRepository = Resolve<IRepository<ScheduleAvailabilityForBooking, Guid>>();
            _slotsRepository = Resolve<IRepository<CdmSlot, Guid>>();
            _bookingSlotsGenerator = Resolve<BookingSlotsGenerator>();

            _uowManager = Resolve<IUnitOfWorkManager>();
        }

        /// <summary>
        /// NOTE: This should NOT be async to ensure that Tests do not execute before completion of Data Seeding.
        /// </summary>
        protected void CreateTestData_HealthFacility(string name)
        {
            LoginAsHost("admin");

            // Checking if test data has previously been added
            var hostpital = _facilityRepository.FirstOrDefault(e => e.Name == name);
            if (hostpital is null)
            {
                using (var uow = _uowManager.Begin())
                {
                    var newHospital = new Hospital()
                    {
                        Name = name,
                    };
                    newHospital = _facilityRepository.Insert(newHospital);

                    uow.Complete();
                }
            }
        }

        protected CdmSchedule CreateTestData_NeedsUoW_NewSchedule(string name, string facilityName)
        {
            var hostpital = _facilityRepository.FirstOrDefault(e => e.Name == facilityName);
            var schedule = _scheduleRepository.FirstOrDefault(e => e.Name == facilityName);

            if (schedule is not null)
            {
                return schedule;
            }
            else
            {
                var newSchedule = new CdmSchedule()
                {
                    Active = true,
                    Name = name,
                    ActorOwnerId = hostpital.Id.ToString(),
                    ActorOwnerType = "His.HisHospital",
                    SchedulingModel = RefListSchedulingModels.Appointment,
                };
                newSchedule = _scheduleRepository.Insert(newSchedule);

                return newSchedule;
            }
        }

        protected void CleanUpTestData_ForSchedule(Guid scheduleId)
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

        protected async Task<CdmSchedule> CreateTestData_NewSchedule(string scheduleName, ScheduleAvailabilityForBooking safb, bool generateSlots)
        {
            CdmSchedule schedule;

            using (var uow = _uowManager.Begin())
            {
                schedule = new CdmSchedule()
                {
                    Active = true,
                    Name = scheduleName,
                    SchedulingModel = RefListSchedulingModels.Appointment,
                };
                schedule = _scheduleRepository.Insert(schedule);

                safb.Schedule = schedule;

                safb = _availabilityRepository.Insert(safb);

                uow.Complete();
            }

            if (generateSlots)
            {
                using (var uow = _uowManager.Begin())
                {
                    // Generate Slots
                    await _bookingSlotsGenerator.GenerateBookingSlotsForScheduleAsync(schedule);

                    uow.Complete();
                }
            }

            return schedule;
        }

    }
}
