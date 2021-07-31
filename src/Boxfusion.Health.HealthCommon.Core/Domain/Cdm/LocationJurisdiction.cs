using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.LocationJurisdiction")]
    public class LocationJurisdiction : Area
    {
        [MultiValueReferenceList("Fhir", "LocationJurisdicationFlags")]
        public virtual int? Flags { get; set; }

        public virtual string Coordinates { get; set; }

        public virtual string Polygon { get; set; }

        public virtual string Center { get; set; }

        [ReferenceList("Cdm", "AreaTypeCategory")]
        public virtual int? AreaCategory { get; set; }
    }
}
