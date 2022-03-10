using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Domain.Notifications
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
    }
}
