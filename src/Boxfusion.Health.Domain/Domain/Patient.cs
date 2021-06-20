using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.BackboneElements;
using Boxfusion.Health.Domain.Domain.CodeableConceptLists;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.Patient")]
    public class Patient : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// An identifier for this patient.
        /// </summary>
        public virtual Identifier Identifier { get; set; }

        /// <summary>
        /// Whether this patient record is in active use. Many systems use this property to mark as non-current patients, 
        /// such as those that have not been seen for a period of time based on an organization's business rules.
        ///It is often used to filter patient lists to exclude inactive patients
        /// Deceased patients may also be marked as inactive for the same reasons, but may be active for some time after death.
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// A name associated with the individual.
        /// </summary>
        public virtual HumanName HumanName { get; set; }

        /// <summary>
        /// A contact detail for the individual
        /// </summary>
        public virtual ContactPoint Telecom { get; set; }

        /// <summary>
        /// Administrative Gender - the gender that the patient is considered to have for administration and record keeping purposes.
        /// </summary>
        public virtual RefListGender? Gender { get; set; }

        /// <summary>
        /// The date of birth for the individual.
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// Indicates if the individual is deceased or not.
        /// </summary>
        public virtual DateTime? Deceased { get; set; }

        /// <summary>
        /// An address for the individual.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// This field contains a patient's most recent marital (civil) status.
        /// </summary>
        public virtual MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Indicates whether the patient is part of a multiple (boolean) or indicates the actual birth order (integer).
        /// </summary>
        public virtual int? MultipleBirth { get; set; }

        /// <summary>
        /// Image of the patient
        /// </summary>
        public virtual Attachment Photo { get; set; }

        /// <summary>
        /// A contact party (e.g. guardian, partner, friend) for the patient
        /// </summary>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// A language which may be used to communicate with the patient about his or her health
        /// </summary>
        public virtual Communication Communication { get; set; }

        /// <summary>
        /// Patient's nominated care provider.
        /// </summary>
        public virtual Practioner GeneralPractioner { get; set; }

        /// <summary>
        /// Organization that is the custodian of the patient record.
        /// </summary>
        public virtual Organization ManagingOrganization { get; set; }

        /// <summary>
        /// Link to another patient resource that concerns the same actual person
        /// </summary>
        public virtual Link Link { get; set; }
    }
}
