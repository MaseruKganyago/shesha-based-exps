using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Slots.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public SlotMapProfile()
        {
            CreateMap<CdmSlot, CdmSlotResponse>()
                .ForMember(c => c.Schedule, options => options.MapFrom(c => c.Schedule != null ? new EntityWithDisplayNameDto<Guid?>(c.Schedule.Id, c.Schedule.Identifier) : null))
                .ForMember(c => c.IsGeneratedFrom, options => options.MapFrom(c => c.IsGeneratedFrom != null ? new EntityWithDisplayNameDto<Guid?>(c.IsGeneratedFrom.Id, "") : null))
                .ForMember(c => c.ServiceType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "ServiceTypes", (long?)c.ServiceType)))
                .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "PracticeSettingCodeValueSets", (long?)c.Speciality)))
                .ForMember(c => c.AppointmentType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "AppointmentReasonCodes", (long?)c.AppointmentType)))
                .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "SlotStatuses", (int?)c.Status)))
                .ForMember(c => c.CapacityType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "SlotCapacityTypes", (int?)c.CapacityType)))
                .MapReferenceListValuesToDto();
        }
    }
}
