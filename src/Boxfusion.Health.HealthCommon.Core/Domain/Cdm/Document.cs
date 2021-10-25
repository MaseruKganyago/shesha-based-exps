using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Document")]
    public class Document : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Person Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person Practitioner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Encounter Encounter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListDocumentTypeValueSets? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile StoredFile { get; set; }
    }
}
