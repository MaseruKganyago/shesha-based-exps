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
	[Entity(TypeShortAlias = "HealthCommon.Core.Specimen")]
	public class Specimen: FullAuditedEntity<Guid>
	{
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual string AccessionIdentifier { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSpecimenStatuses Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSpecimenTypes Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Patient Subject { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ReceivedTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual Specimen Parent { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ServiceRequest Request { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "SpecimenConditions")]
        public virtual RefListSpecimenConditions Condition { get; set; }
    }
}
