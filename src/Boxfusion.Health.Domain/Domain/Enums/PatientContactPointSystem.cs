using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Details for all kinds of technology mediated contact points for a person or organization, including telephone, email, etc.
    /// </summary>
    [ReferenceList("HealthDomain", "PatientContactPointSystem")]
    public enum RefListPatientContactPointSystem : int
    {
        /// <summary>
        /// The value is a telephone number used for voice calls. Use of full international numbers starting with + is recommended 
        /// to enable automatic dialing support but not required.
        /// </summary>
        [Description("Phone")]
        phone = 1,
        /// <summary>
        /// The value is a fax machine. Use of full international numbers starting with + is recommended to enable automatic dialing 
        /// support but not required.
        /// </summary>
        [Description("Fax")]
        fax = 2,
        /// <summary>
        /// The value is an email address.
        /// </summary>
        [Description("Email")]
        email = 3,
        /// <summary>
        /// The value is a pager number. These may be local pager numbers that are only usable on a particular pager system.
        /// </summary>
        [Description("Pager")]
        pager = 4,
        /// <summary>
        /// A contact that is not a phone, fax, pager or email address and is expressed as a URL. This is intended for various 
        /// institutional or personal contacts including web sites, blogs, Skype, Twitter, Facebook, etc. Do not use for 
        /// email addresses.
        /// </summary>
        [Description("Url")]
        url = 5,
        /// <summary>
        /// A contact that can be used for sending an sms message (e.g. mobile phones, some landlines).
        /// </summary>
        [Description("SMS")]
        sms = 6,
        /// <summary>
        /// A contact that is not a phone, fax, page or email address and is not expressible as a URL. E.g. Internal mail address. 
        /// This SHOULD NOT be used for contacts that are expressible as a URL (e.g. Skype, Twitter, Facebook, etc.) Extensions may be 
        /// used to distinguish "other" contact types.
        /// </summary>
        [Description("Other")]
        other = 7
    }
}
