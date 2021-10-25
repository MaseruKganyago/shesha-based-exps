using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Conditions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
	public class ConsultationSummaryMapProfile: ShaProfile
	{
        /// <summary>
        /// 
        /// </summary>
		public ConsultationSummaryMapProfile()
		{
            //Condition
            CreateMap<ConditionInput, Condition>()
                .ForMember(e => e.Category, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.Category)))
                .ForMember(e => e.BodySite, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.BodySite)))
                .ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? GetEntity<Patient>(b.Subject.Id) : null))
                .ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? GetEntity<Encounter>(b.Encounter.Id) : null))
                .ForMember(a => a.Recorder, options => options.MapFrom(b => b.Recorder != null ? GetEntity<PersonFhirBase>(b.Recorder.Id) : null))
                .ForMember(a => a.Asserter, options => options.MapFrom(b => b.Asserter != null ? GetEntity<PersonFhirBase>(b.Asserter.Id) : null))
                .MapReferenceListValuesFromDto();

            CreateMap<Condition, ConditionResponse>()
                .ForMember(c => c.Category, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.Category != null ? (RefListConditionCategory)c.Category : 0)))
                .ForMember(c => c.BodySite, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.BodySite != null ? (RefListBodySite)c.Category : 0)))
                .ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, $"{b.Subject.FirstName} {b.Subject.LastName}") : null))
                .ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? new EntityWithDisplayNameDto<Guid?>(b.Encounter.Id, b.Encounter.Identifier) : null))
                .ForMember(a => a.Recorder, options => options.MapFrom(b => b.Recorder != null ? new EntityWithDisplayNameDto<Guid?>(b.Recorder.Id, $"{b.Recorder.FirstName} {b.Recorder.LastName}") : null))
                .ForMember(a => a.Asserter, options => options.MapFrom(b => b.Asserter != null ? new EntityWithDisplayNameDto<Guid?>(b.Asserter.Id, $"{b.Asserter.FirstName} {b.Asserter.LastName}") : null))
                .MapReferenceListValuesToDto();

            CreateMap<ConditionIcdTenCode, EntityWithDisplayNameDto<Guid?>>()
                .ForMember(a => a.Id, options => options.MapFrom(b => b.Id))
                .ForMember(a => a.DisplayText, options => options.MapFrom(b => $"{b.IcdTenCode.ICDTenThreeCode} {b.IcdTenCode.WHOFullDesc}"));
        }
	}
}
