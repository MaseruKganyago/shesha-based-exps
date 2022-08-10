using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Substance", GenerateApplicationService = false)]
    public class Substance : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListFhirSubstanceStatuses? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "SubstanceCategoryCodes")]
        public virtual RefListSubstanceCategoryCodes? Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSubstanceCodes? Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
        
    }
}
