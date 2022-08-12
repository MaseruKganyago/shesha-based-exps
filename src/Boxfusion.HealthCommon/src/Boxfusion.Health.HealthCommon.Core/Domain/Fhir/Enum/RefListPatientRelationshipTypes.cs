using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "PatientRelationshipTypes")]
    public enum RefListPatientRelationshipTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency Contact")]
        C = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Employer")]
        E = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Federal Agency")]
        F = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Insurance Company")]
        I = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Next-of-Kin")]
        N = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other")]
        O = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("State Agency")]
        S = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Unknown")]
        U = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("family member")]
        FAMMEMB = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("child")]
        CHILD = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("adopted child")]
        CHLDADOPT = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("adopted daughter")]
        DAUADOPT = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("adopted son")]
        SONADOPT = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("foster child")]
        CHLDFOST = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("foster daughter")]
        DAUFOST = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("foster son")]
        SONFOST = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("daughter")]
        DAUC = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural daughter")]
        DAU = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("stepdaughter")]
        STPDAU = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural child")]
        NCHILD = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural son")]
        SON = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("son")]
        SONC = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("stepson")]
        STPSON = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("step child")]
        STPCHLD = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("extended family member")]
        EXT = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("aunt")]
        AUNT = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal aunt")]
        MAUNT = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal aunt")]
        PAUNT = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("cousin")]
        COUSN = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal cousin")]
        MCOUSN = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal cousin")]
        PCOUSN = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("great grandparent")]
        GGRPRN = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("great grandfather")]
        GGRFTH = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal great-grandfather")]
        MGGRFTH = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal great-grandfather")]
        PGGRFTH = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("great grandmother")]
        GGRMTH = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal great-grandmother")]
        MGGRMTH = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal great-grandmother")]
        PGGRMTH = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal great-grandparent")]
        MGGRPRN = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal great-grandparent")]
        PGGRPRN = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("grandchild")]
        GRNDCHILD = 41,

        /// <summary>
        /// 
        /// </summary>
        [Description("granddaughter")]
        GRNDDAU = 42,

        /// <summary>
        /// 
        /// </summary>
        [Description("grandson")]
        GRNDSON = 43,

        /// <summary>
        /// 
        /// </summary>
        [Description("grandparent")]
        GRPRN = 44,

        /// <summary>
        /// 
        /// </summary>
        [Description("grandfather")]
        GRFTH = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal grandfather")]
        MGRFTH = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal grandfather")]
        PGRFTH = 47,

        /// <summary>
        /// 
        /// </summary>
        [Description("grandmother")]
        GRMTH = 48,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal grandmother")]
        MGRMTH = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal grandmother")]
        PGRMTH = 50,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal grandparent")]
        MGRPRN = 51,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal grandparent")]
        PGRPRN = 52,

        /// <summary>
        /// 
        /// </summary>
        [Description("inlaw")]
        INLAW = 53,

        /// <summary>
        /// 
        /// </summary>
        [Description("child-in-law")]
        CHLDINLAW = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("daughter in-law")]
        DAUINLAW = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("son in-law")]
        SONINLAW = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("parent in-law")]
        PRNINLAW = 57,

        /// <summary>
        /// 
        /// </summary>
        [Description("father-in-law")]
        FTHINLAW = 58,

        /// <summary>
        /// 
        /// </summary>
        [Description("mother-in-law")]
        MTHINLAW = 59,

        /// <summary>
        /// 
        /// </summary>
        [Description("sibling in-law")]
        SIBINLAW = 60,

        /// <summary>
        /// 
        /// </summary>
        [Description("brother-in-law")]
        BROINLAW = 61,

        /// <summary>
        /// 
        /// </summary>
        [Description("sister-in-law")]
        SISINLAW = 62,

        /// <summary>
        /// /
        /// </summary>
        [Description("niece/nephew")]
        NIENEPH = 63,

        /// <summary>
        /// 
        /// </summary>
        [Description("nephew")]
        NEPHEW = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("niece")]
        NIECE = 65,

        /// <summary>
        /// 
        /// </summary>
        [Description("uncle")]
        UNCLE = 66,

        /// <summary>
        /// 
        /// </summary>
        [Description("maternal uncle")]
        MUNCLE = 67,

        /// <summary>
        /// 
        /// </summary>
        [Description("paternal uncle")]
        PUNCLE = 68,

        /// <summary>
        /// 
        /// </summary>
        [Description("parent")]
        PRN = 69,

        /// <summary>
        /// 
        /// </summary>
        [Description("adoptive parent")]
        ADOPTP = 70,

        /// <summary>
        /// 
        /// </summary>
        [Description("adoptive father")]
        ADOPTF = 71,

        /// <summary>
        /// /
        /// </summary>
        [Description("adoptive mother")]
        ADOPTM = 72,

        /// <summary>
        /// 
        /// </summary>
        [Description("father")]
        FTH = 73,

        /// <summary>
        /// 
        /// </summary>
        [Description("foster father")]
        FTHFOST = 74,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural father")]
        NFTH = 75,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural father of fetus")]
        NFTHF = 76,

        /// <summary>
        /// 
        /// </summary>
        [Description("stepfather")]
        STPFTH = 77,

        /// <summary>
        /// 
        /// </summary>
        [Description("mother")]
        MTH = 78,

        /// <summary>
        /// 
        /// </summary>
        [Description("gestational mother")]
        GESTM = 79,

        /// <summary>
        /// 
        /// </summary>
        [Description("foster mother")]
        MTHFOST = 80,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural mother")]
        NMTH = 81,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural mother of fetus")]
        NMTHF = 82,

        /// <summary>
        /// 
        /// </summary>
        [Description("stepmother")]
        STPMTH = 83,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural parent")]
        NPRN = 84,

        /// <summary>
        /// 
        /// </summary>
        [Description("foster parent")]
        PRNFOST = 85,

        /// <summary>
        /// 
        /// </summary>
        [Description("step parent")]
        STPPRN = 86,

        /// <summary>
        /// 
        /// </summary>
        [Description("sibling")]
        SIB = 87,

        /// <summary>
        /// 
        /// </summary>
        [Description("brother")]
        BRO = 88,

        /// <summary>
        /// 
        /// </summary>
        [Description("half-brother")]
        HBRO = 89,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural brother")]
        NBRO = 90,

        /// <summary>
        /// 
        /// </summary>
        [Description("twin brother")]
        TWINBRO = 91,

        /// <summary>
        /// 
        /// </summary>
        [Description("fraternal twin brother")]
        FTWINBRO = 92,

        /// <summary>
        /// 
        /// </summary>
        [Description("identical twin brother")]
        ITWINBRO = 93,

        /// <summary>
        /// 
        /// </summary>
        [Description("stepbrother")]
        STPBRO = 94,

        /// <summary>
        /// 
        /// </summary>
        [Description("half-sibling")]
        HSIB = 95,

        /// <summary>
        /// 
        /// </summary>
        [Description("half-sister")]
        HSIS = 96,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural sibling")]
        NSIB = 97,

        /// <summary>
        /// 
        /// </summary>
        [Description("natural sister")]
        NSIS = 98,

        /// <summary>
        /// 
        /// </summary>
        [Description("twin sister")]
        TWINSIS = 99,

        /// <summary>
        /// 
        /// </summary>
        [Description("fraternal twin sister")]
        FTWINSIS = 100,

        /// <summary>
        /// 
        /// </summary>
        [Description("identical twin sister")]
        ITWINSIS = 101,

        /// <summary>
        /// 
        /// </summary>
        [Description("twin")]
        TWIN = 102,

        /// <summary>
        /// 
        /// </summary>
        [Description("fraternal twin")]
        FTWIN = 103,

        /// <summary>
        /// 
        /// </summary>
        [Description("identical twin")]
        ITWIN = 104,

        /// <summary>
        /// 
        /// </summary>
        [Description("sister")]
        SIS = 105,

        /// <summary>
        /// 
        /// </summary>
        [Description("stepsister")]
        STPSIS = 106,

        /// <summary>
        /// 
        /// </summary>
        [Description("step sibling")]
        STPSIB = 107,

        /// <summary>
        /// 
        /// </summary>
        [Description("significant other")]
        SIGOTHR = 108,

        /// <summary>
        /// 
        /// </summary>
        [Description("domestic partner")]
        DOMPART = 109,

        /// <summary>
        /// 
        /// </summary>
        [Description("former spouse")]
        FMRSPS = 110,

        /// <summary>
        /// 
        /// </summary>
        [Description("spouse")]
        SPS = 111,

        /// <summary>
        /// 
        /// </summary>
        [Description("husband")]
        HUSB = 112,

        /// <summary>
        /// 
        /// </summary>
        [Description("wife")]
        WIFE = 113,

        /// <summary>
        /// 
        /// </summary>
        [Description("unrelated friend")]
        FRND = 114,

        /// <summary>
        /// 
        /// </summary>
        [Description("neighbor")]
        NBOR = 115,

        /// <summary>
        /// 
        /// </summary>
        [Description("self")]
        ONESELF = 116,

        /// <summary>
        /// 
        /// </summary>
        [Description("Roommate")]
        ROOM = 117
    }
}
