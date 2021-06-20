using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Link to another patient resource that concerns the same actual patient.
    /// </summary>
    [ReferenceList("HealthDomain", "LinkType")]
    public enum RefListLinkType : int
    {
        /// <summary>
        /// The patient resource containing this link must no longer be used. The link points forward to another patient resource 
        /// that must be used in lieu of the patient resource that contains this link.
        /// </summary>
        [Description("Replaced-by")]
        replacedBy = 1,
        /// <summary>
        /// The patient resource containing this link is the current active patient record. The link points back to an inactive 
        /// patient resource that has been merged into this resource, and should be consulted to retrieve additional referenced information.
        /// </summary>
        [Description("Replaces")]
        replaces = 2,
        /// <summary>
        /// The patient resource containing this link is in use and valid but not considered the main source of information about a 
        /// patient. The link points forward to another patient resource that should be consulted to retrieve additional patient information.
        /// </summary>
        [Description("Refer")]
        refer = 3,
        /// <summary>
        /// The patient resource containing this link is in use and valid, but points to another patient resource that is known to 
        /// contain data about the same person. Data in this resource might overlap or contradict information found in the other 
        /// patient resource. This link does not indicate any relative importance of the resources concerned, and both should be 
        /// regarded as equally valid.
        /// </summary>
        [Description("See also")]
        seealso = 4
    }
}
