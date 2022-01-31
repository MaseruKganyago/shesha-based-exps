using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Bookings.Domain.Views;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class BookingAppointmentMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public BookingAppointmentMapProfile()
        {
            CreateMap<FlattenedAppointments, FlattenedAppointmentDto>()
                .ForMember(c => c.AppointmentType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "AppointmentReasonCodes", (int?)c.AppointmentType)))
                .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "AppointmentStatuses", (long?)c.Status)))
                .MapReferenceListValuesToDto();//still needs to be fixed on the name part;
        }
    }
}
