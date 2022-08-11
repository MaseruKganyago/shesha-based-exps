using Abp.Dependency;
using Boxfusion.Health.His.Bookings.Domain;
using Shesha.Scheduler;
using Shesha.Scheduler.Attributes;
using Shesha.Scheduler.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Jobs
{
    /// <summary>
    /// Creates booking slots so that they can be made available for the booking of appointments.
    /// </summary>
    [ScheduledJob("006e54fd-9af1-40e2-ad5d-c09554c457ca", 
        StartUpMode.Automatic, "0 2 * * *",
        description: "Generates additional booking slots to be made available for booking for all the Schedules")
        ]
    public class GenerateBookingSlotsJob : ScheduledJobBase, ITransientDependency
    {
        private readonly BookingSlotsGenerator _bookingSlotsGenerator; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="generateBookingSlots"></param>
        public GenerateBookingSlotsJob(BookingSlotsGenerator bookingSlotsGenerator)
        {
            _bookingSlotsGenerator = bookingSlotsGenerator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
        {
            await _bookingSlotsGenerator.GenerateBookingSlotsForAllSchedulesAsync();
        }
    }
}
