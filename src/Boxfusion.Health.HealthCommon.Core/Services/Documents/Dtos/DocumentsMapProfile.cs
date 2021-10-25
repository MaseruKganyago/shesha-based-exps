using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Documents.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentsMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public DocumentsMapProfile()
        {
            CreateMap<DocumentInput, Document>()
                .ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
                .ForMember(a => a.Practitioner, options => options.MapFrom(b => GetEntity<Practitioner>(b.Practitioner)))
                .ForMember(a => a.Encounter, options => options.MapFrom(b => GetEntity<Encounter>(b.Encounter)))
            .MapReferenceListValuesToDto();

            CreateMap<Document, DocumentResponse>()
                .ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
                .ForMember(a => a.Practitioner, options => options.MapFrom(b => b.Practitioner != null ? new EntityWithDisplayNameDto<Guid?>(b.Practitioner.Id, b.Practitioner.FullName) : null))
                .ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? new EntityWithDisplayNameDto<Guid?>(b.Encounter.Id, b.Encounter.Identifier) : null))
                .ForMember(a => a.StoredFile, options => options.MapFrom(b => b.StoredFile != null ? new EntityWithDisplayNameDto<Guid?>(b.StoredFile.Id, b.StoredFile.GetFileUrl()) : null))
            .MapReferenceListValuesToDto();
        }
    }
}
