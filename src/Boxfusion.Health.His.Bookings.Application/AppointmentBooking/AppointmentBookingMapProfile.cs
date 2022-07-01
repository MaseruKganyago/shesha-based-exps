using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.Cdm.Practitioners;
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
                .ForMember(@out => @out.Status, options => options.MapFrom(@in => RefListAppointmentStatuses.booked))
                .ForMember(@out => @out.AppointmentType, options => options.MapFrom(@in => UtilityHelper.GetRefListItemValue(@in.AppointmentType)))
                .ForMember(@out => @out.Patient, options => options.MapFrom(@in => GetEntity<CdmPatient>(@in.Patient)))
                .ForMember(@out => @out.Practitioner, options => options.MapFrom(@in => GetEntity<CdmPractitioner>(@in.Practitioner)))
                .IgnoreNotMapped()
                .MapReferenceListValuesToDto();


        }
    }
}
