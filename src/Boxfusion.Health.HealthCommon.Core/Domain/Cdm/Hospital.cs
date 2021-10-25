using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Hospital")]
    public class Hospital : FhirOrganisation
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? Altitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListFacilityDistricts? District { get; set; }
    }
}
