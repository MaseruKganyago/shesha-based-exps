using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.RelatedPerson")]
    public class RelatedPerson : PersonFhirBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListPatientRelationshipTypes? Relationship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Preferred { get; set; }
    }
}
