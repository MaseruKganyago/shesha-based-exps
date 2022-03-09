using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="paging"></param>
		public PagedResponse(List<FlattenedAppointmentDto> items, Paging paging)
        {
            Items = items;
            Paging = paging;
        }

        /// <summary>
        /// 
        /// </summary>
        public Paging Paging { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "consultationEncounter", EmitDefaultValue = false)]
        public List<FlattenedAppointmentDto> Items { get; set; }
    }
}
