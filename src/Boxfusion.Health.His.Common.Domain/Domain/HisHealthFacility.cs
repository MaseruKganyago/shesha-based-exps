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
        /// <summary>
        /// 
        /// </summary>
        public string FacilityPracticeNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Area District { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "PracticeSettingCodeValueSets")]
        public long? Speciality { get; set; }
    }
}
