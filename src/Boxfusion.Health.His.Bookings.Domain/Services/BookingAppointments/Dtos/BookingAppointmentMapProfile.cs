using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Bookings.Domain.Views;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
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
            CreateMap<FlattenedAppointment, FlattenedAppointmentDto>()
                .ForMember(c => c.AppointmentType, options => options.MapFrom(c => GetRefListItemValueDto("Fhir", "AppointmentReasonCodes", (int?)c.AppointmentType)))
                .ForMember(c => c.Status, options => options.MapFrom(c => GetRefListItemValueDto("Fhir", "AppointmentStatuses", (int?)c.Status)))
                .MapReferenceListValuesToDto();

            //CreateMap<BookAppointmentInput, CdmAppointment>()
            //    .ForMember(c => c.Status, options => options.MapFrom(c => RefListAppointmentStatuses.booked))
            //    .ForMember(c => c.AppointmentType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.AppointmentType)))
            //    .ForMember(c => c.Patient, options => options.MapFrom(c => GetEntity<CdmPatient>(c.Patient)))
            //    .MapReferenceListValuesToDto();

            //CreateMap<RescheduleInput, CdmAppointment>()
            //    .ForMember(c => c.Status, options => options.MapFrom(c => RefListAppointmentStatuses.booked))
            //     .MapReferenceListValuesToDto();

            //CreateMap<CdmAppointment, CdmAppointmentResponse>()
            //    .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "AppointmentStatuses", (long?)c.Status)))
            //    .ForMember(c => c.CancelationReason, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "CancelationReasons", (long?)c.CancelationReason)))
            //    .ForMember(c => c.ServiceCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "HealthcareServiceCategories", (long?)c.ServiceCategory)))
            //    .ForMember(c => c.ServiceType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "ServiceTypes", (long?)c.ServiceType)))
            //    .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "PracticeSettingCodeValueSets", (long?)c.Speciality)))
            //    .ForMember(c => c.AppointmentType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "AppointmentReasonCodes", (long?)c.AppointmentType)))
            //    .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.ReasonCode != null ? (RefListEncounterReasonCodes)c.ReasonCode : 0)))
            //    .ForMember(c => c.BasedOn, options => options.MapFrom(c => c.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(c.BasedOn.Id, c.BasedOn.Identifier) : null))
            //    .ForMember(c => c.Patient, options => options.MapFrom(c => c.Patient != null ? new EntityWithDisplayNameDto<Guid?>(c.Patient.Id, c.Patient.FullName) : null))
            //    .ForMember(c => c.Practitioner, options => options.MapFrom(c => c.Practitioner != null ? new EntityWithDisplayNameDto<Guid?>(c.Practitioner.Id, c.Practitioner.FullName) : null))
            //    .ForMember(c => c.Slot, options => options.MapFrom(c => c.Slot != null ? new EntityWithDisplayNameDto<Guid?>(c.Slot.Id, c.Slot.Identifier) : null))
            //    .MapReferenceListValuesToDto();

            //CreateMap<CdmSlot, CdmAppointment>()
            //    .ForMember(c => c.Id, options => options.Ignore())
            //    .ForMember(c => c.Identifier, options => options.Ignore())
            //    .ForMember(c => c.Status, options => options.MapFrom(c => RefListAppointmentStatuses.booked))
            //    .ForMember(c => c.Slot, options => options.MapFrom(c => GetEntity<CdmSlot>(c.Id)))
            //    .ForMember(c => c.Start, options => options.MapFrom(c => c.StartDateTime))
            //    .ForMember(c => c.End, options => options.MapFrom(c => c.EndDateTime))
            //    .MapReferenceListValuesToDto();

            //CreateMap<CdmAppointment, CdmAppointmentResponse>()
            //    .ForMember(a => a.Practitioner, options => options.MapFrom(b => b.Practitioner != null ? new EntityWithDisplayNameDto<Guid?>(b.Practitioner.Id, b.ContactName) : null))
            //    .ForMember(a => a.Patient, options => options.MapFrom(b => b.Patient != null ? new EntityWithDisplayNameDto<Guid?>(b.Patient.Id, b.Patient.FirstName) : null))
            //    .ForMember(a => a.Slot, options => options.MapFrom(b => b.Slot != null ? new EntityWithDisplayNameDto<Guid?>(b.Slot.Id, b.Slot.Identifier) : null))
            //    .MapReferenceListValuesToDto();

            //CreateMap<CdmAppointmentResponse, CdmAppointment>()
            //     .ForMember(a => a.Practitioner, options => options.MapFrom(b => GetEntity<CdmPractitioner>(b.Practitioner)))
            //     .ForMember(a => a.Patient, options => options.MapFrom(b => GetEntity<CdmPatient>(b.Patient)))
            // .MapReferenceListValuesToDto();
        }
    }
}
