using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmPatient")]
    public class CdmPatient : Patient
    {
        public virtual bool IsDisabled { get; set; }
        public virtual bool IsEmployed { get; set; }
        public virtual bool HasMedicalAid { get; set; }
        public virtual string MedicalAidName { get; set; }
        public virtual string MedicalAidNumber { get; set; }
        public virtual string MobilePin { get; set; }
    }
}
