using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Encounter")]
    [Table("Fhir_Encounters")]
    [Discriminator]
    public class Encounter: FullAuditedEntity<Guid>
	{
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListEncounterStatuses Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListRefListEncounterClasses Class { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListEncounterTypes Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListEncounterServiceTypes ServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListEncounterPriorities Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Patient Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual EpisodeOfCare EpisodeOfCare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ServiceRequest BasedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Person Performer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Appointment Appointment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "EncounterReasonCodes")]
        public virtual RefListEncounterReasonCodes ReasonCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ReasonReferenceOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ReasonReferenceOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual  FhirOrganisation ServiceProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Encounter PartOf { get; set; }
    }
}
