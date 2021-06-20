using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// The verification status to support or decline the clinical status of the condition or diagnosis.
    /// </summary>
    [ReferenceList("HealthDomain", "ConditionVerificationStatus")]
    public enum RefListConditionVerificationStatus : int
    {
        /// <summary>
        /// There is not sufficient diagnostic and/or clinical evidence to treat this as a confirmed condition.
        /// </summary>
        Unconfirmed = 1,
        /// <summary>
        /// This is a tentative diagnosis - still a candidate that is under consideration.
        /// </summary>
        Provisional = 2,
        /// <summary>
        /// One of a set of potential (and typically mutually exclusive) diagnoses asserted to further guide the diagnostic process and preliminary treatment.
        /// </summary>
        Differential = 3,
        /// <summary>
        /// There is sufficient diagnostic and/or clinical evidence to treat this as a confirmed condition.
        /// </summary>
        Confirmed = 4,
        /// <summary>
        /// This condition has been ruled out by diagnostic and clinical evidence.
        /// </summary>
        Refuted = 5,
        /// <summary>
        /// The statement was entered in error and is not valid.
        /// </summary>
        [Description("Entered in Error")]
        EnteredInError = 6
    }
}
