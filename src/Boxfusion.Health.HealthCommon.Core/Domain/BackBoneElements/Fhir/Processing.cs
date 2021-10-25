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
    [Entity(TypeShortAlias = "HealthCommon.Core.Processing")]
    public class Processing : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
              
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSpecimeProcessingProcedures Procedure { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual Substance Addditive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? TimeDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? TimePeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? TimePeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Specimen Specimen { get; set; }
    }
}
