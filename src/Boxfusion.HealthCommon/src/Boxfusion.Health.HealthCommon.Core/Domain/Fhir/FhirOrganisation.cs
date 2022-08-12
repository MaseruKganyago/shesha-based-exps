using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
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
    [Entity(TypeShortAlias = "HealthCommon.Core.FhirOrganisation")]
    public class FhirOrganisation : Organisation
    {
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "OrganisationTypes")]
        public virtual int? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PrimaryContactEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PrimaryContactTelephone { get; set; }
    }
}
