using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain
{
    [Entity(TypeShortAlias = "His.HospitalAdmission")]
    public class HospitalAdmission : Admission
    {
        public virtual string HospitalAdmissionNumber { get; set; }

        [ReferenceList("HisAdmis", "Classification")]
        public virtual int? Classification { get; set; }

        [ReferenceList("HisAdmis", "OtherCategories")]
        public virtual int? OtherCategories { get; set; }

        public virtual FhirOrganisation TransferFromHospital { get; set; }

        public virtual FhirOrganisation TransferToHospital { get; set; }

    }
}
