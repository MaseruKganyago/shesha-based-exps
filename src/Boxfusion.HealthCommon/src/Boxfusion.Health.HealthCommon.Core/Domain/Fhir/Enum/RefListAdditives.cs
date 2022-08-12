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
    [ReferenceList("Fhir", "Additives")]
    public enum RefListAdditives : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("ACD Solution A")]
        ACDA = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("ACD Solution B")]
        ACDB = 2,

        /// <summary>
        /// /
        /// </summary>
        [Description("Acetic Acid")]
        ACET = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Amies transport medium")]
        AMIES = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bacterial Transport medium")]
        BACTM = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Buffered 10% formalin")]
        BF10 = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Borate Boric Acid")]
        BOR = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bouin's solution")]
        BOUIN = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Buffered skim milk")]
        BSKM = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("3.2% Citrate")]
        C32 = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("3.8% Citrate")]
        C38 = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Carson's Modified 10% formalin")]
        CARS = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cary Blair Medium")]
        CARY = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chlamydia transport medium")]
        CHLTM = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("CTAD (this should be spelled out if not universally understood)")]
        CTAD = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Potassium/K EDTA")]
        EDTK = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Potassium/K EDTA 15%")]
        EDTK15 = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Potassium/K EDTA 7.5%")]
        EDTK75 = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sodium/Na EDTA")]
        EDTN = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Enteric bacteria transport medium")]
        ENT = 20,

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        [Description("Enteric plus")]
        ENT1 = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("10% Formalin")]
        F10 = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thrombin NIH; soybean trypsin inhibitor (Fibrin Degradation Products)")]
        FDP = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sodium Fluoride, 10mg")]
        FL10 = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sodium Fluoride, 100mg")]
        FL100 = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("6N HCL")]
        HCL6 = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ammonium heparin")]
        HEPA = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lithium/Li Heparin")]
        HEPL = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sodium/Na Heparin")]
        HEPN = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nitric Acid")]
        HNO3 = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Jones Kendrick Medium")]
        JKM = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("Karnovsky's fixative")]
        KARN = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Potassium Oxalate")]
        KOX = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lithium iodoacetate")]
        LIA = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("M4")]
        M4 = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("M4-RT")]
        M4RT = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("M5")]
        M5 = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("Michel's transport medium")]
        MICHTM = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("MMD transport medium")]
        MMDTM = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sodium Fluoride")]
        NAF = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sodium polyanethol sulfonate 0.35% in 0.85% sodium chloride")]
        NAPS = 41,

        /// <summary>
        /// 
        /// </summary>
        [Description("None")]
        NONE = 42,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pages's Saline")]
        PAGE = 43,

        /// <summary>
        /// 
        /// </summary>
        [Description("Phenol")]
        PHENOL = 44,

        /// <summary>
        /// 
        /// </summary>
        [Description("PVA (polyvinylalcohol)")]
        PVA = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reagan Lowe Medium")]
        RLM = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("Siliceous earth, 12 mg")]
        SILICA = 47,

        /// <summary>
        /// 
        /// </summary>
        [Description("SPS(this should be spelled out if not universally understood)")]
        SPS = 48,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serum Separator Tube (Polymer Gel)")]
        SST = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stuart transport medium")]
        STUTM = 50,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thrombin")]
        THROM = 51,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thymol")]
        THYMOL = 52,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thyoglycollate broth")]
        THYO = 53,

        /// <summary>
        /// 
        /// </summary>
        [Description("Toluene")]
        TOLU = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ureaplasma transport medium")]
        URETM = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("Viral Transport medium")]
        VIRTM = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("Buffered Citrate (Westergren Sedimentation Rate)")]
        WEST = 57,


    }
}
