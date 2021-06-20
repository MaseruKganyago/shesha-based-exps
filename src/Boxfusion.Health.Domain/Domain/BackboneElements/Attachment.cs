using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    /// <summary>
    /// For referring to data content defined in other formats.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Attachment")]
    public class Attachment : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Identifies the type of the data in the attachment and allows a method to be chosen to interpret or render the data. Includes mime type parameters such as 
        /// charset where appropriate.
        /// </summary>
        public virtual RefListMimeType? ContentType { get; set; }

        /// <summary>
        /// The human language of the content. The value can be any valid value according to BCP 47.
        /// </summary>
        public virtual RefListCommonLanguage? Language { get; set; }

        /// <summary>
        /// The human language of the content. The value can be any valid value according to BCP 47.
        /// </summary>
        public virtual byte[] Data { get; set; }

        /// <summary>
        /// A location where the data can be accessed.
        /// </summary>
        public virtual string Url { get; set; }


        /// <summary>
        /// The number of bytes of data that make up this attachment (before base64 encoding, if that is done).
        /// </summary>
        public virtual ushort Size { get; set; }

        /// <summary>
        /// The calculated hash of the data using SHA-1. Represented using base64.
        /// </summary>
         public virtual byte[] Hash { get; set; }

        /// <summary>
        /// A label or set of text to display in place of the data.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// A label or set of text to display in place of the data.
        /// </summary>
        public virtual DateTime? Creation { get; set; }

        /// <summary>
        /// End Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }
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
