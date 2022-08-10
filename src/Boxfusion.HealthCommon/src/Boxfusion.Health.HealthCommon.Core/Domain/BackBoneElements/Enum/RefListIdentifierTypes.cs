using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "IdentifierTypes")]
    public enum RefListIdentifierTypes
    {
        [Description("Boxfusion Health CDM GUID")]
        CDMGUID = 1,

        [Description("South African ID Number")]
        SAID = 2,

        [Description("Driver's license number")]
        DL = 3,

        [Description("Passport number")]
        PPN = 4,

        [Description("Medical record number")]
        MR = 5,

        [Description("Medical License number")]
        MD = 6,

        [Description("Provider number")]
        PRN = 7,

        [Description("Donor Registration Number")]
        DR = 8,

        [Description("Accession ID")]
        ACSN = 9,

        [Description("Universal Device Identifier")]
        UDI = 10,

        [Description("Serial Number")]
        SNO = 11,

        [Description("Social Beneficiary Identifier")]
        SB = 12
    }
}
