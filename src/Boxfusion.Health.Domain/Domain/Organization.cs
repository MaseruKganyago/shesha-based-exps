using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.BackboneElements;
using Boxfusion.Health.Domain.Domain.CodeableConceptLists;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// A formally or informally recognized grouping of people or organizations formed for the purpose of achieving some form of 
    /// collective action. Includes companies, institutions, corporations, departments, community groups, healthcare practice groups, 
    /// payer/insurer, etc.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Organization")]
    public class Organization : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Identifies this organization across multiple systems
        /// </summary>
        public virtual Identifier Identifier { get; set; }

        /// <summary>
        /// Whether the organization's record is still in active use
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// Kind of organization
        /// </summary>
        public virtual OrganizationType Type { get; set; }

        /// <summary>
        /// A name associated with the organization.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// A list of alternate names that the organization is known as, or was known as in the past
        /// </summary>
        public virtual string Alias { get; set; }

        /// <summary>
        /// A contact detail for the organization
        /// </summary>
        public virtual ContactPoint Telecom { get; set; }

        /// <summary>
        /// An address for the organization
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// The organization of which this organization forms a part
        /// </summary>
        public virtual Organization PartOf { get; set; }

        /// <summary>
        /// Contact for the organization for a certain purpose
        /// </summary>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// Technical endpoints providing access to services operated for the organization.
        /// </summary>
        public virtual Endpoint Endpoint { get; set; }
    }
}
