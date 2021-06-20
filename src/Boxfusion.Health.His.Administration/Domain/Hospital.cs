using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// Hospital facility inherits from Shesha facility
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Hospital")]
    public class Hospital : Organization
    {
        /// <summary>
        /// Province under which the hospital fall under
        /// </summary>
        public virtual RefListProvince? Province { get; set; }
        /// <summary>
        /// Total number of beds inside a facility
        /// </summary>
        public virtual int? TotalNumberOfBeds { get; set; }
    }
}
