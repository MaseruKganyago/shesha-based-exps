using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Beds.Enums;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Shesha.Domain.Attributes;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds
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
        public virtual string BedName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string BedDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual BedType BedType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Room Room { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListBedAvailability? BedAvailability { get; set; }
    }
}
