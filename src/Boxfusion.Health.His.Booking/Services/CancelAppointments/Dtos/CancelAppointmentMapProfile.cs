using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
//using Boxfusion.Health.His.Bookings.Services.Appointments.Dtos;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.CancelAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class CancelAppointmentMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public CancelAppointmentMapProfile()
        {
            CreateMap<CdmAppointment, CdmAppointmentResponse>()
                .ForMember(a => a.Practitioner, options => options.MapFrom(b => b.Practitioner != null ? new EntityWithDisplayNameDto<Guid?>(b.Practitioner.Id, b.ContactName) : null))
                .ForMember(a => a.Patient, options => options.MapFrom(b => b.Patient != null ? new EntityWithDisplayNameDto<Guid?>(b.Patient.Id, b.Patient.FirstName) : null))
                .ForMember(a => a.Slot, options => options.MapFrom(b => b.Slot != null ? new EntityWithDisplayNameDto<Guid?>(b.Slot.Id, b.Slot.Identifier) : null))
                .MapReferenceListValuesToDto();

            //CreateMap<CdmAppointmentResponse, CdmAppointment>()
            //     .ForMember(a => a.Practitioner, options => options.MapFrom(b => GetEntity<CdmPractitioner>(b.Practitioner)))
            //     .ForMember(a => a.Patient, options => options.MapFrom(b => GetEntity<CdmPatient>(b.Patient)))
            // .MapReferenceListValuesToDto();

        }
    }
}
