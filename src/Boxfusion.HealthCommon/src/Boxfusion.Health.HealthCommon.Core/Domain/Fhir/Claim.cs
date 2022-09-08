using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Claim")]
    [Discriminator]
    public class Claim: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListClaimStatus? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "ClaimType")]
        public virtual long? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "ClaimSubType")]
        public virtual long? SubType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "ClaimUse")]
        public virtual long? Use { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? BillablePeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? BillablePeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirOrganisation Insurer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Practitioner Provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "ClaimPriority")]
        public virtual long? Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Payee Payee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirLocation Facility { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Insurance Insurance { get; set; }
    }
}
