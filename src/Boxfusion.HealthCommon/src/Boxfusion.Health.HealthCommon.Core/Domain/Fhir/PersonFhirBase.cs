using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.PersonFhirBase")]
	public class PersonFhirBase: Person
	{
        /// <summary>
        /// 
        /// </summary>
        public virtual string PassportNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string PermitNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PersalNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Shesha.Core", "CommonLanguage")]
        public virtual int? CommunicationLanguage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile IDDocument { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "IdentityVerificationStatus")]
        public virtual int? IdentityVerificationStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Countries")]
        public virtual int? Nationality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "PersonEthnicity")]
        public virtual int? Ethnicity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsSupervisor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "IdentificationTypes")]
        public virtual long? IdentificationType { get; set; }
	}
}
