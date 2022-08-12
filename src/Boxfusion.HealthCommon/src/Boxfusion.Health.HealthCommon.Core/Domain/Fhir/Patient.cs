using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Patient")]
	public class Patient: PersonFhirBase
	{
        /// <summary>
        /// 
        /// </summary>
        public virtual string OtherIdentityNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool MultipleBirthBoolean { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int? MultipleBirthInteger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool DeceasedBoolean { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeceasedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "MaritalStatus")]
        public virtual int? MaritalStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string GeneralPractitioner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Patient LinkToOtherPatient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "LinkTypes")]
        public virtual int? TypeOfLinkToOtherPatient { get; set; }
    }
}
