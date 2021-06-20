using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.BackboneElements;
using Boxfusion.Health.Domain.Domain.CodeableConceptLists;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.Location")]
    public class Location : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Unique code or number identifying the location to its users
        /// </summary>
        public virtual Identifier Identifier { get; set; }

        /// <summary>
        /// The status property covers the general availability of the resource, not the current value which may be covered by the 
        /// operationStatus, or by a schedule/slots if they are configured for the location.
        /// </summary>
        public virtual RefListLocationStatus? Status { get; set; }

        /// <summary>
        /// The operational status of the location (typically only for a bed/room)
        /// </summary>
        public virtual BedStatus OperationalStatus { get; set; }

        /// <summary>
        /// Name of the location as used by humans
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// A list of alternate names that the location is known as, or was known as, in the past
        /// </summary>
        public virtual string Alias { get; set; }

        /// <summary>
        /// Additional details about the location that could be displayed as further information to identify the location beyond its name
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Indicates whether a resource instance represents a specific location or a class of locations.
        /// </summary>
        public virtual RefListLocationMode? Mode { get; set; }

        /// <summary>
        /// Type of function performed
        /// </summary>
        public virtual ServiceDeliveryLocationRoleType Type { get; set; }

        /// <summary>
        /// Contact details of the location
        /// </summary>
        public virtual ContactPoint Telecom { get; set; }

        /// <summary>
        /// Physical location
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Physical form of the location
        /// </summary>
        public virtual LocationPhysicalType PhysicalType { get; set; }

        /// <summary>
        /// The absolute geographic location of the Location, expressed using the WGS84 datum (This is the same co-ordinate system used in KML).
        /// </summary>
        public virtual Position Position { get; set; }

        /// <summary>
        /// Organization responsible for provisioning and upkeep
        /// </summary>
        public virtual Organization ManagingOrganization { get; set; }

        /// <summary>
        /// Another Location this one is physically a part of
        /// </summary>
        public virtual Location PartOf { get; set; }

        /// <summary>
        /// What days/times during a week is this location usually open
        /// </summary>
        public virtual HoursOfOperation HoursOfOperation { get; set; }

        /// <summary>
        /// A description of when the locations opening ours are different to normal, e.g. public holiday availability. Succinctly 
        /// describing all possible exceptions to normal site availability as detailed in the opening hours Times.
        /// </summary>
        public virtual string AvailabilityExceptions { get; set; }

        /// <summary>
        /// Technical endpoints providing access to services operated for the location
        /// </summary>
        public virtual Endpoint Endpoint { get; set; }
    }
}
