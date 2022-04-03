using Boxfusion.Health.His.Bookings.Jobs;
using Boxfusion.Health.His.Bookings.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Bookings.Domain.Tests.Jobs
{
    public class SendAppointmentReminderNotificationJob_Test : BookingManagementTestBase
    {
        [Fact]
        public async Task Should()
        {
            var job = new SendAppointmentReminderNotificationJob();

            await job.DoExecuteAsync(CancellationToken.None);

        }
    }
}
