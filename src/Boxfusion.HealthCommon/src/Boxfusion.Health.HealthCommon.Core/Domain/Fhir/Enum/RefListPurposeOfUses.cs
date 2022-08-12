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
    [ReferenceList("Fhir", "PurposeOfUses")]
    public enum RefListPurposeOfUses : long
    {
        /// <summary>
        /// 
        /// </summary>
        
        [Description("purpose of use")]
        PurposeOfUse = 1,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare marketing")]
        HMARKT = 2,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare operations")]
        HOPERAT = 3,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("care management")]
        CAREMGT = 4,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("donation")]
        DONAT = 5,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("fraud")]
        FRAUD = 6,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("government")]
        GOV = 7,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("health accreditation")]
        HACCRED = 8,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("health compliance")]
        HCOMPL = 9,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("decedent")]
        HDECD = 10,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("directory")]
        HDIRECT = 11,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare delivery management")]
        HDM = 12,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("legal")]
        HLEGAL = 13,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("health outcome measure")]
        HOUTCOMS = 14,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("health program reporting")]
        HPRGRP = 15,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("health quality improvement")]
        HQUALIMP = 16,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("health system administration")]
        HSYSADMIN = 17,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("labeling")]
        LABELING = 18,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("metadata management")]
        METAMGT = 19,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("member administration")]
        MEMADMIN = 20,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("military command")]
        MILCDM = 21,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("patient administration")]
        PATADMIN = 22,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("patient safety")]
        PATSFTY = 23,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("performance measure")]
        PERFMSR = 24,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("records management")]
        RECORDMGT = 25,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("system development")]
        SYSDEV = 26,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("test health data")]
        HTEST = 27,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("training")]
        TRAIN = 28,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare payment")]
        HPAYMT = 29,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("claim attachment")]
        CLMATTCH = 30,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("coverage authorization")]
        COVAUTH = 31,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("coverage under policy or program")]
        COVERAGE = 32,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("eligibility determination")]
        ELIGDTRM = 33,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("eligibility verification")]
        ELIGVER = 34,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("enrollment")]
        ENROLLM = 35,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("military discharge")]
        MILDCRG = 36,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("remittance advice")]
        REMITADV = 37,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("healthcare research")]
        HRESCH = 38,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("biomedical research")]
        BIORCH = 39,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("clinical trial research")]
        CLINTRCH = 40,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("clinical trial research without patient care")]
        CLINTRCHNPC = 41,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("clinical trial research with patient care")]
        CLINTRCHPC = 42,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("preclinical trial research")]
        PRECLINTRCH = 43,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("disease specific healthcare research")]
        DSRCH = 44,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("population origins or ancestry healthcare research")]
        POARCH = 45,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("translational healthcare research")]
        TRANSRCH = 46,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("patient requested")]
        PATRQT = 47,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("family requested")]
        FAMRQT = 48,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("power of attorney")]
        PWATRNY = 49,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("support network")]
        SUPNWK = 50,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("public health")]
        PUBHLTH = 51,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("disaster")]
        DISASTER = 52,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("threat")]
        THREAT = 53,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("treatment")]
        TREAT = 54,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("clinical trial")]
        CLINTRL = 55,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("coordination of care")]
        COC = 56,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency Treatment")]
        ETREAT = 57,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("break the glass")]
        BTG = 58,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("emergency room treatment")]
        ERTREAT = 59,
         
        /// <summary>
        /// 
        /// </summary>
        [Description("population health")]
        POPHLTH = 60

    }
}
