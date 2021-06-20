using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Indicates whether a resource instance represents a specific location or a class of locations.
    /// </summary>
    [ReferenceList("HealthDomain", "LocationMode")]
    public enum RefListLocationMode : int
    {
        /// <summary>
        /// The Location resource represents a specific instance of a location (e.g. Operating Theatre 1A).
        /// </summary>
        [Description("Instance")]
        instance = 1,
        /// <summary>
        /// The Location represents a class of locations (e.g. Any Operating Theatre) although this class of locations could be 
        /// constrained within a specific boundary (such as organization, or parent location, address etc.).
        /// </summary>
        [Description("Kind")]
        kind = 2
    }
}
