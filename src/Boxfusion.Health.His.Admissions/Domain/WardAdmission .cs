using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain
{
    [Entity(TypeShortAlias = "His.WardAdmission ")]
    public class WardAdmission : Admission
    {
        public virtual string WardAdmissionNumber { get; set; }

        [ReferenceList("HisAdmis", "AdmissionType")]
        public virtual int? AdmissionType { get; set; }

        [ReferenceList("HisAdmis", "TransferRejectionReason")]
        public virtual int? TransferRejectionReason { get; set; }

        public virtual string TransferRejectionReasonComment { get; set; }

        [ReferenceList("HisAdmis", "SeparationType")]
        public virtual int? SeparationType { get; set; }

        public virtual Ward SeparationDestinationWard { get; set; }

        [ReferenceList("HisAdmis", "SeparationChildHealth")]
        public virtual int? SeparationChildHealth { get; set; }

        public virtual string SeparationComment { get; set; }


    }
}
