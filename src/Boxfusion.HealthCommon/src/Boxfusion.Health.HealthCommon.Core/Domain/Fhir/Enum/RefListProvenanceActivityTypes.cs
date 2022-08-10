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
    [ReferenceList("Fhir", "ProvenanceActivityTypes")]
    public enum RefListProvenanceActivityTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("legally authenticated")]
        LA = 1,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("anonymize")]
        ANONY = 2,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("deidentify")]
        DEID = 3,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("mask")]
        MASK = 4,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("assign security label")]
        LABEL = 5,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("pseudonymize")]
        PSEUD = 6,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("create")]
        CREATE = 7,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("delete")]
        DELETE = 8,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("revise")]
        UPDATE = 9,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("append")]
        APPEND = 10,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("nullify")]
        NULLIFY = 11,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Participation")]
        PART = 12,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("admitter")]
        ADM = 13,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("attender")]
        ATND = 14,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("callback contact")]
        CALLBCK = 15,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("consultant")]
        CON = 16,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("discharger")]
        DIS = 17,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("escort")]
        ESC = 18,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("referrer")]
        REF = 19,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("author (originator)")]
        AUT = 20,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("informant")]
        INF = 21,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Transcriber")]
        TRANS = 22,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("data entry person")]
        ENT = 23,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("witness")]
        WIT = 24,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("custodian")]
        CST = 25,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("direct target")]
        DIR = 26,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("analyte")]
        ALY = 27,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("baby")]
        BBY = 28,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("catalyst")]
        CAT = 29,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("consumable")]
        CSM = 30,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("therapeutic agent")]
        TPA = 31,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("device")]
        DEV = 32,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("non-reuseable device")]
        NRD = 33,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("reusable device")]
        RDV = 34,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("donor")]
        DON = 35,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("ExposureAgent")]
        EXPAGNT = 36,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("ExposureParticipation")]
        EXPART = 37,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("ExposureTarget")]
        EXPTRGT = 38,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("ExposureSource")]
        EXSRC = 39,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("product")]
        PRD = 40,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("subject")]
        SBJ = 41,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("specimen")]
        SPC = 42,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("indirect target")]
        IND = 43,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("beneficiary")]
        BEN = 44,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("causative agent")]
        CAGNT = 45,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("coverage target")]
        COV = 46,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("guarantor party")]
        GUAR = 47,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("holder")]
        HLD = 48,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("record target")]
        RCT = 49,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("receiver")]
        RCV = 50,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("information recipient")]
        IRCP = 51,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("ugent notification contact")]
        NOT = 52,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("primary information recipient")]
        PRCP = 53,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Referred By")]
        REFB = 54,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Referred to")]
        REFT = 55,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("tracker")]
        TRC = 56,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("location")]
        LOC = 57,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("destination")]
        DST = 58,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("entry location")]
        ELOC = 59,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("origin")]
        ORG = 60,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("remote")]
        RML = 61,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("via")]
        VIA = 62,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("performer")]
        PRF = 63,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("distributor")]
        DIST = 64,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("primary performer")]
        PPRF = 65,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("secondary performer")]
        SPRF = 66,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("responsible party")]
        RESP = 67,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("verifier")]
        VRF = 68,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("authenticator")]
        AUTHEN = 69,
        
        [Description("legal authenticator")]
        LAUTH = 70
    }
}
