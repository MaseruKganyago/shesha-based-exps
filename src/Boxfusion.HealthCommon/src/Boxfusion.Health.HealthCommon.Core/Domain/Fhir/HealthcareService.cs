using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.HealthcareService")]
    public class HealthcareService : FullAuditedEntity<Guid>
    {
        public virtual FhirOrganisation ProvidedBy { get; set; }
        [ReferenceList("Fhir", "HealthcareServiceCategories")]
        public virtual int? Category { get; set; }
        [ReferenceList("Fhir", "HealthcareServiceTypes")]
        public virtual int? Type { get; set; }
        [ReferenceList("Fhir", "HealthcareServicec80PracticeCodes")]
        public virtual int? Speciality { get; set; }
        public virtual FhirLocation Location { get; set; }
        public virtual string Name { get; set; }
        public virtual string Comment { get; set; }
        public virtual string ExtraServiceDetail { get; set; }
        public virtual StoredFile Photo { get; set; }
        public virtual LocationJurisdiction CoverageArea { get; set; }
        [ReferenceList("Fhir", "HealthcareServiceProvisionConditions")]
        public virtual int? ServiceProvisionCode { get; set; }
        //public virtual int? EligibilityCode { get; set; }
        public virtual string EligibilityComment { get; set; }
        //public virtual int? Program { get; set; }
        //public virtual int? Characteristic { get; set; }
        [MultiValueReferenceList("Shesha.Core", "CommonLanguage")]
        public virtual int? Communication { get; set; }
        [MultiValueReferenceList("Fhir", "HealthcareServiceReferralMethods")]
        public virtual int? ReferralMethod { get; set; }
        public virtual bool AppointmentRequired { get; set; }
        public virtual string AvailabilityException { get; set; }
    }
}
