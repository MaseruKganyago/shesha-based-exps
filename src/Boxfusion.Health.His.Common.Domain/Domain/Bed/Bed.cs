using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Bed
{
    [Entity(TypeShortAlias = "His.Beds")]
    public class Bed : FhirLocation
    {
        public string BedName { get; set; }
        public string BedDescription { get; set; }
        public BedType BedType { get;set; }
       

    }
}
