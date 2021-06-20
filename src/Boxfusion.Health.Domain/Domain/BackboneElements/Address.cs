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
    /// An address expressed using postal conventions (as opposed to GPS or other location definition formats). This data type may be used to 
    /// convey addresses for use in delivering mail as well as for visiting locations which might not be valid for mail delivery. There are a 
    /// variety of postal address formats defined around the world.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Address")]
    public class Address : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The purpose of this address.
        /// </summary>
        public virtual RefListAddressUse? Use { get; set; }

        /// <summary>
        /// Distinguishes between physical addresses (those you can visit) and mailing addresses (e.g. PO Boxes and care-of addresses). 
        /// Most addresses are both.
        /// </summary>
        public virtual RefListAddressType? Type { get; set; }

        /// <summary>
        /// Specifies the entire address as it should be displayed e.g. on a postal label. This may be provided instead of or as well as the specific parts
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// This component contains the house number, apartment number, street name, street direction, P.O. Box number, delivery hints, and similar address information.
        /// </summary>
        public virtual string Line { get; set; }

        /// <summary>
        /// The name of the city, town, suburb, village or other community or delivery center.
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// The name of the administrative area (county).
        /// </summary>
        public virtual string District { get; set; }

        /// <summary>
        /// Sub-unit of a country with limited sovereignty in a federally organized country. A code may be used if codes are in common use 
        /// (e.g. US 2 letter state codes).
        /// </summary>
        public virtual string State { get; set; }

        /// <summary>
        /// A postal code designating a region defined by the postal service.
        /// </summary>
        public virtual string PostalCode { get; set; }

        /// <summary>
        /// Country - a nation as commonly understood or generally accepted.
        /// </summary>
        public virtual string Country { get; set; }

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
