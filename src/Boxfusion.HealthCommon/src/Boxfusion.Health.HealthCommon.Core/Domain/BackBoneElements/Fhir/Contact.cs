using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Contact")]
    public class Contact : FullAuditedEntity<Guid>
    {
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }
        [ReferenceList("Fhir", "PatientContactRelationship")]
        public virtual int? Relationship { get; set; }
        public virtual string Name { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string OfficeNumber { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Address { get; set; }
        [ReferenceList("Shesha.Core", "Gender")]
        public virtual int? Gender { get; set; }
        public virtual FhirOrganisation Organisation { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
    }
}
