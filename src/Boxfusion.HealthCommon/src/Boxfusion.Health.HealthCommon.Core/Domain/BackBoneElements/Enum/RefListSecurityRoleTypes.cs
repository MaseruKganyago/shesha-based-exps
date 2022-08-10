using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "SecurityRoleTypes")]
    public enum RefListSecurityRoleTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Amender")]
        AMENDER = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Co-Author")]
        CoAUTH = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Contact")]
        CONT = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Event Witness")]
        EVTWIT = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Primary Author")]
        PRIMAUTH = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reviewer")]
        REVIEWER = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source")]
        SOURCE = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transcriber")]
        TRANS = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Validator")]
        VALID = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Verifier")]
        VERF = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("affiliate")]
        AFFL = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("agent")]
        AGNT = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("assigned entity")]
        ASSIGNED = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("claimant")]
        CLAIM = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("covered party")]
        COVPTY = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("dependent")]
        DEPEN = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("emergency contact")]
        ECON = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("employee")]
        EMP = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("guardian")]
        GUARD = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Investigation Subject")]
        INVSBJ = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("named insured")]
        NAMED = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("next of kin ")]
        NOK = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("patient")]
        PAT = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare provider")]
        PROV = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("notary public ")]
        NOT = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("classifier")]
        CLASSIFIER = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("consenter")]
        CONSENTER = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("consent witness")]
        CONSWIT = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("co-participant")]
        COPART = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("declassifier")]
        DECLASSIFIER = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("delegatee")]
        DELEGATEE = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("delegator")]
        DELEGATOR = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("downgrader")]
        DOWNGRDER = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("durable power of attorney")]
        DPOWATT = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("executor of estate")]
        EXCEST = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("grantee")]
        GRANTEE = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("grantor")]
        GRANTOR = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("guarantor")]
        GT = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("guardian ad lidem")]
        GUARDLTM = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare power of attorney")]
        HPOWATT = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("interpreter")]
        INTPRTER = 41,

        /// <summary>
        /// 
        /// </summary>
        [Description("power of attorney")]
        POWATT = 42,

        /// <summary>
        /// 
        /// </summary>
        [Description("responsible party")]
        RESPRSN = 43,

        /// <summary>
        /// 
        /// </summary>
        [Description("special power of attorney")]
        SPOWATT = 44,

        /// <summary>
        /// 
        /// </summary>
        [Description("CitizenRoleType")]
        CitizenRoleType = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("asylum seeker")]
        CAS = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("single minor asylum seeker")]
        CASM = 47,

        /// <summary>
        /// 
        /// </summary>
        [Description("national")]
        CN = 48,

        /// <summary>
        /// 
        /// </summary>
        [Description("non-country member without residence permit")]
        CNRP = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("non-country member minor without residence permit")]
        CNRPM = 50,

        /// <summary>
        /// From here it started to be to the exponent 15.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        [Description("permit card applicant")]
        CPCA = 51,

        /// <summary>
        /// 
        /// </summary>
        [Description("non-country member with residence permit")]
        CRP = 52,

        /// <summary>
        /// 
        /// </summary>
        [Description("non-country member minor with residence permit")]
        CRPM = 53,

        /// <summary>
        /// 
        /// </summary>
        [Description("caregiver information receiver")]
        AUCG = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("legitimate relationship information receiver")]
        AULR = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("care team information receiver")]
        AUTM = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("work area information receiver")]
        AUWA = 57,

        /// <summary>
        /// 
        /// </summary>
        [Description("authorized provider masking author")]
        PROMSK = 58,

        /// <summary>
        /// 
        /// </summary>
        [Description("author (originator)")]
        AUT = 59,

        /// <summary>
        /// 
        /// </summary>
        [Description("custodian")]
        CST = 60,

        /// <summary>
        /// 
        /// </summary>
        [Description("informant")]
        INF = 61,

        /// <summary>
        /// 
        /// </summary>
        [Description("information recipient")]
        IRCP = 62,

        /// <summary>
        /// 
        /// </summary>
        [Description("legal authenticator")]
        LA = 63,

        /// <summary>
        /// 
        /// </summary>
        [Description("tracker")]
        TRC = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("witness")]
        WIT = 65,

        /// <summary>
        /// 
        /// </summary>
        [Description("authorization server")]
        authserver = 66,

        /// <summary>
        /// 
        /// </summary>
        [Description("data collector")]
        datacollector = 67,

        /// <summary>
        /// 
        /// </summary>
        [Description("data processor")]
        dataprocesssor = 68,

        /// <summary>
        /// 
        /// </summary>
        [Description("data subject")]
        datasubject = 69,

        /// <summary>
        /// 
        /// </summary>
        [Description("human user")]
        humanuser = 70,

        /// <summary>
        /// 
        /// </summary>
        [Description("Application")]
        application = 71,

        /// <summary>
        /// 
        /// </summary>
        [Description("Application Launcher")]
        applicationLauncher = 72,

        /// <summary>
        /// 
        /// </summary>
        [Description("Destination Role ID")]
        destinationRoleID = 73,

        /// <summary>
        /// /
        /// </summary>
        [Description("Source Role ID")]
        sourceRoleID = 74,

        /// <summary>
        /// 
        /// </summary>
        [Description("Destination Media")]
        destinationMedia = 75,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source Media")]
        sourceMedia = 76
    }
}
