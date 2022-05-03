using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
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
            CreateMap<AdmissionInput, WardAdmission>()
                .ForMember(a => a.ReasonCode, b => b.MapFrom(c => UtilityHelper.SetMultiValueReferenceList(c.ReasonCode)))
                .ForMember(a => a.Subject, b => b.MapFrom(c => GetEntity<HisPatient>(c.Subject.Id)))
                .ForMember(a => a.PartOf, b => b.MapFrom(c => GetEntity<HospitalAdmission>(c.PartOf.Id)))
                .ForMember(a => a.ServiceProvider, b => b.MapFrom(c => GetEntity<FhirOrganisation>(c.ServiceProvider.Id)))
                .ForMember(a => a.Appointment, b => b.MapFrom(c => GetEntity<Appointment>(c.Appointment.Id)))
                .ForMember(a => a.Performer, b => b.Ignore())
                .ForMember(a => a.BasedOn, b => b.MapFrom(c => GetEntity<ServiceRequest>(c.BasedOn.Id)))
                .ForMember(a => a.EpisodeOfCare, b => b.MapFrom(c =>  GetEntity<EpisodeOfCare>(c.EpisodeOfCare.Id)))
                .ForMember(a => a.Ward, b => b.MapFrom(c => GetEntity<HisWard>(c.Ward.Id)))
                .ForMember(a => a.SeparationDestinationWard, b => b.MapFrom(c => GetEntity<HisWard>(c.SeparationDestinationWard.Id)))
                .ForMember(a => a.InternalTransferOriginalWard, b => b.MapFrom(c => GetEntity<WardAdmission>(c.InternalTransferOriginalWard.Id)))
                .ForMember(a => a.InternalTransferDestinationWard, b => b.MapFrom(c => GetEntity<WardAdmission>(c.InternalTransferDestinationWard.Id)))
                .MapReferenceListValuesFromDto();

            //HospitalAdmission
            CreateMap<AdmissionInput, HospitalAdmission>()
                .ForMember(a => a.Id, options => options.Ignore())
                 .ForMember(a => a.HospitalAdmissionNumber, options => options.MapFrom(c => c.HospitalAdmissionNumber))
                 .ForMember(a => a.OriginOwnerId, options => options.MapFrom(c => c.OriginOwnerId))
                 .ForMember(a => a.OriginOwnerType, options => options.MapFrom(c => c.OriginOwnerType))
                 .ForMember(a => a.DestinationOwnerId, options => options.MapFrom(c => c.DestinationOwnerId))
                 .ForMember(a => a.EndDateTime, options => options.MapFrom(c => c.EndDateTime))
                 .ForMember(a => a.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
                 .ForMember(a => a.HospitalAdmissionStatus, options => options.MapFrom(u => RefListHospitalAdmissionStatuses.admitted))
                 .ForMember(a => a.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Classification)))
                 .ForMember(a => a.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.OtherCategory)))
                 .ForMember(a => a.TransferFroHospital, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.TransferFroHospital)))
                 .ForMember(a => a.TransferToHospital, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.TransferToHospital)))
                 .ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
                 .ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
                 .ForMember(a => a.TransferToNonGautengHospital, options => options.MapFrom(c => c.TransferToNonGautengHospital))
                 .ForMember(a => a.IsGautengGovFacility, options => options.MapFrom(c => c.IsGautengGovFacility))
                 .ForMember(a => a.Performer, b => b.Ignore())
                 .IgnoreNotMapped()
                 .MapReferenceListValuesFromDto();
        }
		
	}
}
