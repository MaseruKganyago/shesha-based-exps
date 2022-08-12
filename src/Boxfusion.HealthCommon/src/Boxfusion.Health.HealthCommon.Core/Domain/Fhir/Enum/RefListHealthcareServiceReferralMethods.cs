using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "HealthcareServiceReferralMethods")]
    public enum RefListHealthcareServiceReferralMethods
    {
        [Description("Fax")]
        fax = 1,
        [Description("Phone")]
        phone = 2,
        [Description("Secure Messaging")]
        elec = 4,
        [Description("Secure Email")]
        semail = 8,
        [Description("Mail")]
        mail = 16,
        [Description("Video")]
        video = 32,
        [Description("Chat")]
        chat = 64
    }
}
