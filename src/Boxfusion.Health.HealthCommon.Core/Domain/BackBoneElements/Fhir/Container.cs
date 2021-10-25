using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Container")]
    public class Container : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSpecimenContainerTypes Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? Capacity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? SpecimenQuantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAdditives AdditiveCodeableConcept { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Substance AdditiveReference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Specimen Specimen { get; set; }
    }
}
