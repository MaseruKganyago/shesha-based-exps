using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    /// <summary>
    /// 
    /// </summary>
    public class AppointmentBookingMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public AppointmentBookingMapProfile()
        {
            CreateMap<BookAppointmentInput, CdmAppointment>()
                .ForMember(c => c.Status, options => options.MapFrom(c => RefListAppointmentStatuses.booked))
                .ForMember(c => c.AppointmentType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.AppointmentType)))
                .ForMember(c => c.Patient, options => options.MapFrom(c => GetEntity<CdmPatient>(c.Patient)))
                .IgnoreNotMapped()
                .MapReferenceListValuesToDto();

            CreateMap<RescheduleInput, CdmAppointment>()
                .ForMember(c => c.Status, options => options.MapFrom(c => RefListAppointmentStatuses.booked))
                 .MapReferenceListValuesToDto();

        }
    }
}
