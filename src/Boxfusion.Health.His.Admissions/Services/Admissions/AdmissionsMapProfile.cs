using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Services.Admissions
{
	/// <summary>
	/// 
	/// </summary>
	public class AdmissionsMapProfile: ShaProfile
	{
        /// <summary>
        /// 
        /// </summary>
		public AdmissionsMapProfile()
		{
			//IcdTenCodes
			CreateMap<IcdTenCode, EntityWithDisplayNameDto<Guid?>>()
				.ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
				.ForMember(a => a.DisplayText, b => b.MapFrom(c => $"{c.ICDTenCode} {c.WHOFullDesc}"));

            //WardAdmission
            CreateMap<WardAdmission, AdmissionResponse>()
                .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList((RefListServiceRequestProcedureReasons)c.ReasonCode)))
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Identifier) : null))
                .ForMember(c => c.ServiceProvider, options => options.MapFrom(c => c.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(c.ServiceProvider.Id, c.ServiceProvider.Name) : null))
                .ForMember(c => c.Appointment, options => options.MapFrom(c => c.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(c.Appointment.Id, c.Appointment.Identifier) : null))
                .ForMember(c => c.Performer, options => options.Ignore())
                .ForMember(c => c.BasedOn, options => options.MapFrom(c => c.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(c.BasedOn.Id, c.BasedOn.Identifier) : null))
                .ForMember(c => c.EpisodeOfCare, options => options.MapFrom(c => c.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(c.EpisodeOfCare.Id, "") : null))
                .ForMember(c => c.Ward, options => options.MapFrom(c => c.Ward != null ? new EntityWithDisplayNameDto<Guid?>(c.Ward.Id, c.Ward.Name) : null))
                .ForMember(c => c.SeparationDestinationWard, options => options.MapFrom(c => c.SeparationDestinationWard != null ? new EntityWithDisplayNameDto<Guid?>(c.SeparationDestinationWard.Id, c.SeparationDestinationWard.Name) : null))
                //.ForMember(c => c.AgeBreakdown, options => options.MapFrom(c => c.Subject.DateOfBirth != null ? UtilityHelper.AgeBreakdown(c.Subject.DateOfBirth.Value, DateTime.Now) : ""))
                .ForMember(c => c.InternalTransferOriginalWard, options => options.MapFrom(c => c.InternalTransferOriginalWard != null ? new EntityWithDisplayNameDto<Guid?>(c.InternalTransferOriginalWard.Id, c.InternalTransferOriginalWard.Identifier) : null))
                .ForMember(c => c.InternalTransferDestinationWard, options => options.MapFrom(c => c.InternalTransferDestinationWard != null ? new EntityWithDisplayNameDto<Guid?>(c.InternalTransferDestinationWard.Id, c.InternalTransferDestinationWard.Identifier) : null))
                .MapReferenceListValuesToDto();

            //HospitalAdmission
            CreateMap<HospitalAdmission, AdmissionResponse>()
                .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList((RefListServiceRequestProcedureReasons)c.ReasonCode)))
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Identifier) : null))
                .ForMember(c => c.ServiceProvider, options => options.MapFrom(c => c.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(c.ServiceProvider.Id, c.ServiceProvider.Name) : null))
                .ForMember(c => c.Appointment, options => options.MapFrom(c => c.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(c.Appointment.Id, c.Appointment.Identifier) : null))
                .ForMember(c => c.Performer, options => options.MapFrom(c => c.Performer != null ? new EntityWithDisplayNameDto<Guid?>(c.Performer.Id, c.Performer.FullName) : null))
                .ForMember(c => c.BasedOn, options => options.MapFrom(c => c.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(c.BasedOn.Id, c.BasedOn.Identifier) : null))
                .ForMember(c => c.EpisodeOfCare, options => options.MapFrom(c => c.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(c.EpisodeOfCare.Id, "") : null))
                .ForMember(c => c.TransferToHospital, options => options.MapFrom(c => c.TransferToHospital != null ? new EntityWithDisplayNameDto<Guid?>(c.TransferToHospital.Id, c.TransferToHospital.Name) : null))
                .ForMember(c => c.TransferFroHospital, options => options.MapFrom(c => c.TransferFroHospital != null ? new EntityWithDisplayNameDto<Guid?>(c.TransferFroHospital.Id, c.TransferFroHospital.Name) : null))
                .MapReferenceListValuesToDto();

            //Patient
            CreateMap<HisPatient, AdmissionResponse>()
                //.ForMember(c => c.IdentityNumber, opt => opt.MapFrom(c => c.IdentityNumber))
                //.ForMember(c => c.DateOfBirth, opt => opt.MapFrom(c => c.DateOfBirth))
                //.ForMember(c => c.FirstName, opt => opt.MapFrom(c => c.FirstName))
                //.ForMember(c => c.LastName, opt => opt.MapFrom(c => c.LastName))
                //.ForMember(c => c.HospitalAdmissionNumber, opt => opt.MapFrom(c => c.HospitalPatientNumber))
                .MapReferenceListValuesToDto();

        }
		
	}
}
