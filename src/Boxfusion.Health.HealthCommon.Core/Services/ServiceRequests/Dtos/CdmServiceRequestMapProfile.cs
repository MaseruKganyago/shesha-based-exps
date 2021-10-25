using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class CdmServiceRequestMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public CdmServiceRequestMapProfile()
        {
            //BackBoneElements' mappings
            CreateMap<NoteInput, Note>()
                .ForMember(e => e.Parent, e => e.MapFrom(e => GetEntity<Note>(e.Parent)))
                .ForMember(e => e.Author, e => e.MapFrom(e => GetEntity<CdmPatient>(e.Author)))
            .MapReferenceListValuesFromDto();

            CreateMap<Note, NoteResponse>()
                .ForMember(c => c.Parent, options => options.MapFrom(c => c.Parent != null ? new EntityWithDisplayNameDto<Guid?>(c.Parent.Id, "") : null))
                .ForMember(c => c.Author, options => options.MapFrom(c => c.Author != null ? new EntityWithDisplayNameDto<Guid?>(c.Author.Id, c.Author.FullName) : null))
            .MapReferenceListValuesToDto();
        }
    }
}
