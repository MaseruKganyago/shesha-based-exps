using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
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
    [Entity(TypeShortAlias = "HealthCommon.Core.PractitionerRole", GenerateApplicationService = false)]
    public class PractitionerRole : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Practitioner Practitioner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirOrganisation Organization { get; set; }

        /// <summary>
        /// Changed from being a MultiValueReferenceList because it contains a lot of items.
        /// </summary>
        public virtual RefListPractitionerRoles? Code { get; set; }

        /// <summary>
        /// Changed from being a MultiValueReferenceList because it contains a lot of items.
        /// </summary>
        public virtual RefListPracticeSettingCodeValueSets? Speciality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirLocation Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual HealthcareService HealthcareService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string AvailabilityExceptions { get; set; }
    }
}
