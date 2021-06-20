using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.CodeableConceptLists
{
    /// <summary>
    /// Whether this hospitalization is a readmission and why if known.
    /// The type of hospital re-admission that has occurred (if any). If the value is absent, then this is not identified as a readmission
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.HospitalizationReAdmission")]
    public class HospitalizationReAdmission : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// A few code lists that FHIR defines are hierarchical - each code is assigned a level. See Code System for further information.
        /// </summary>
        public virtual int? Level { get; set; }

        /// <summary>
        /// The source of the definition of the code (when the value set draws in codes defined elsewhere)
        /// </summary>
        public virtual string Source { get; set; }

        /// <summary>
        /// The code (used as the code in the resource instance). If the code is in italics, this indicates that the code is not 
        /// selectable ('Abstract')
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// The display (used in the display element of a Coding). If there is no display, implementers should not simply display the code, 
        /// but map the concept into their application
        /// </summary>
        public virtual string Display { get; set; }

        /// <summary>
        /// An explanation of the meaning of the concept
        /// </summary>
        public virtual string Definition { get; set; }

        /// <summary>
        /// Additional notes about how to use the code
        /// </summary>
        public virtual string Comments { get; set; }
    }
}
