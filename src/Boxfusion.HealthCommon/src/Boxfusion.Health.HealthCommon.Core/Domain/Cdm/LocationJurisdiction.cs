using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.LocationJurisdiction")]
    public class LocationJurisdiction : Area
    {
        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "LocationJurisdicationFlags")]
        public virtual int? Flags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Coordinates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Polygon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Center { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "AreaTypeCategory")]
        public virtual int? AreaCategory { get; set; }
    }
}
