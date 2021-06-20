using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// The list of diagnosis relevant to this encounter.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Diagnosis")]
    public class Diagnosis<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// The diagnosis or procedure relevant to the encounter
        /// </summary>
        public virtual Condition<T> Condition { get; set; }
        /// <summary>
        /// Role that this diagnosis has within the encounter (e.g. admission, billing, discharge …)
        /// </summary>
        public virtual RefListDiagnosisRole? Use { get; set; }
        /// <summary>
        /// Ranking of the diagnosis (for each role type)
        /// </summary>
        public virtual int? Rank { get; set; }
        /// <summary>
        /// Encouter that triggered this diagnosis
        /// </summary>
        public virtual Encounter<T> Encounter { get; set; }
    }
}
