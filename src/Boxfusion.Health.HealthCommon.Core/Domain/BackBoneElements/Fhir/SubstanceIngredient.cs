using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.BackBoneElements.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.SubstanceIngredient")]
    public class SubstanceIngredient : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Type 
        /// </summary>
        public virtual decimal? QuantityRatioNumerator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? QuantityRatioDenominator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSubstanceCodes SubstanceCodeableConcept { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Substance SubstanceReference { get; set; }

    }
}
