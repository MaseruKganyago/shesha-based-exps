using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.FhirAddress")]
    public class FhirAddress : Address
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
        [ReferenceList("Fhir", "AddressUse")]
        public virtual int? Use { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "AddressType")]
        public virtual int? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string District { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }
    }
}
