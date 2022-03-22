using Shesha.Utilities;
using System;

namespace Boxfusion.Health.His.Bookings.Notifications
{
    /// <summary>
    /// Notification template identifiers
    /// </summary>
    public static class NotificationTemplateIds
    {
        /// <summary>
        /// All The Bursary Management Notifications Will be under this category of notifications
        /// </summary>
        public static Guid CompletionOfNewBooking = "643D0631-AD92-48C0-88CB-3BDA6AED8EC4".ToGuid();

        public static Guid BookingCancelled = "5766aaff-ecd6-4b69-a4ad-4fc5f1fb6c9e".ToGuid();

        public static Guid BookingRescheduled = "416dceb5-6e8e-40e2-b9bc-e1a243274d24".ToGuid();

        public static Guid AppointmentReminder = "a4cc40c7-7c85-44b3-a7cc-dc04d1c9ea24".ToGuid();
    }
}
