using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Encounter))]
    public class FhirEncounterResponse : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Class { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto ServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> EpisodeOfCare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> BasedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Performer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Appointment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ReferenceListItemValueDto> ReasonCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReasonReferenceOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReasonReferenceOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> ServiceProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> PartOf { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public List<ParticipantResponse> Participants { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public List<DiagnosisResponse> Diagnosis { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public List<EncounterLocationResponse> Locations { get; set; }
    }
}
