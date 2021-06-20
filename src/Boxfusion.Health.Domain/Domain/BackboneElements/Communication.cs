using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    /// <summary>
    /// A language which may be used to communicate with the patient about his or her health.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Communication")]
    public class Communication : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The ISO-639-1 alpha 2 code in lower case for the language, optionally followed by a hyphen and the ISO-3166-1 alpha 2 code 
        /// for the region in upper case; e.g. "en" for English, or "en-US" for American English versus "en-EN" for England English.
        /// </summary>
        public virtual RefListCommonLanguage? Language { get; set; }

        /// <summary>
        /// Indicates whether or not the patient prefers this language (over other languages he masters up a certain level).
        /// </summary>
        public virtual bool Preferred { get; set; }

        /// <summary>
        /// The Id of the entity this audit entry relates to.
        /// </summary>
        [Column("Frwk_OwnerId")]
        [StringLength(40)]
        public virtual string OwnerId { get; protected set; }

        /// <summary>
        /// The Type of entity this audit entry relates to.
        /// </summary>
        [Column("Frwk_OwnerType")]
        [StringLength(100)]
        public virtual string OwnerType { get; protected set; }
    }
}
