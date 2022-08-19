using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Bed
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.Beds")]
    public class Bed : FhirLocation
    {
        /// <summary>
        /// 
        /// </summary>
        public string BedName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BedDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BedType BedType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Room Room { get; set; }
    }
}
