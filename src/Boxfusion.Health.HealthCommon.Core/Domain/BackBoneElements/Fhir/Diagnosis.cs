using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Diagnosis")]
    public class Diagnosis : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Condition Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "EncounterDiagnosisRoles")]
        public virtual int? Use { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? Rank { get; set; }
    }
}
