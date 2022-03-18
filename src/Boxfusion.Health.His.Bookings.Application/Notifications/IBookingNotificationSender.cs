using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Notifications
{
    /// <summary>
    /// Booking notification sender
    /// </summary>
    public interface IBookingNotificationSender
    {
        /// <summary>
        /// 
        /// </summary>
        Task NotifyCompletionOfNewBookingAsync(CdmAppointment appointment);

        Task NotifyBookingCancelledAsync(CdmAppointment appointment);

        Task NotifyBookingRescheduledAsync(CdmAppointment appointment);

        Task NotifyAppointmentReminderAsync(CdmAppointment appointment);

    }
}
