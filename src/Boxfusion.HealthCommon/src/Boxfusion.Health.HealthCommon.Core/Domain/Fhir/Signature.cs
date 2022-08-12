using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Signature", GenerateApplicationService = false)]
    public class Signature: FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "SignatureTypeCodes")]
        public virtual RefListSignatureTypeCodes? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? When { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string  WhoOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string WhoOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OnBehalfOfOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OnBehalfOfOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListMimeTypes? TargetFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListMimeTypes? SigFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile Data { get; set; }
    }
}
