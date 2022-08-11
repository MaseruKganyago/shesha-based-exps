using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisHealthFacility")]
    public class HisHealthFacility : Hospital
    {
        public string FacilityPracticeNumber { get; set; }
        public Area District { get; set; }
        [MultiValueReferenceList("Fhir", "PracticeSettingCodeValueSets")]
        public long? Speciality { get; set; }
    }
}
