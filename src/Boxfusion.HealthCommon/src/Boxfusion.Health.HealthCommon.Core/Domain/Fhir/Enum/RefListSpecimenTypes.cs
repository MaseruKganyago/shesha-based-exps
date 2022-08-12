using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{/// <summary>
 /// 
 /// </summary>
    [ReferenceList("Fhir", "SpecimenTypes")]
    public enum RefListSpecimenTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("No suggested values")]
        NSV = 1,


        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess")]
        ABS = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue, Acne")]
        ACNE = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Acne")]
        ACNFLD = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Air Sample")]
        AIRS = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Allograft")]
        ALL = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Amniotic fluid")]
        AMN = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Amputation")]
        AMP = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Angio")]
        ANGI = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Arterial")]
        ARTC = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serum, Acute")]
        ASERU = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aspirate")]
        ASP = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environment, Attest")]
        ATTE = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Autoclave Ampule")]
        AUTOA = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Autoclave Capsule")]
        AUTOC = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Autopsy")]
        AUTP = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood bag")]
        BBL = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cyst, Baker's")]
        BCYST = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("Whole body")]
        BDY = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bile Fluid")]
        BIFL = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bite")]
        BITE = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("Whole blood")]
        BLD = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood arterial")]
        BLDA = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cord blood")]
        BLDCO = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood venous")]
        BLDV = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bleb")]
        BLEB = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blister")]
        BLIST = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("Boil")]
        BOIL = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone")]
        BON = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone")]
        BONE = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bowel contents")]
        BOWL = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("Basophils")]
        BPH = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood product unit")]
        BPU = 33,

        /// <summary>
        /// 
        /// </summary>
        [Description("Burn")]
        BRN = 34,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brush")]
        BRSH = 35,

        /// <summary>
        /// 
        /// </summary>
        [Description("Breath (use EXHLD)")]
        BRTH = 36,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brushing")]
        BRUS = 37,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bubo")]
        BUB = 38,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bulla/Bullae")]
        BULLA = 39,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biopsy")]
        BX = 40,

        /// <summary>
        /// 
        /// </summary>
        [Description("Calculus (=Stone)")]
        CALC = 41,

        /// <summary>
        /// 
        /// </summary>
        [Description("Carbuncle")]
        CARBU = 42,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter")]
        CAT = 43,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bite, Cat")]
        CBITE = 44,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac muscle")]
        CDM = 45,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clippings")]
        CLIPP = 46,

        /// <summary>
        /// 
        /// </summary>
        [Description("Conjunctiva")]
        CNJT = 47,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cannula")]
        CNL = 48,

        /// <summary>
        /// 
        /// </summary>
        [Description("Colostrum")]
        COL = 49,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biospy, Cone")]
        CONE = 50,

        /// <summary>
        /// /
        /// </summary>
        [Description("Scratch, Cat")]
        CSCR = 51,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serum, Convalescent")]
        CSERU = 52,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebral spinal fluid")]
        CSF = 53,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Insertion Site")]
        CSITE = 54,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Cystostomy Tube")]
        CSMY = 55,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Cyst")]
        CST = 56,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood, Cell Saver")]
        CSVR = 57,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter tip")]
        CTP = 58,

        /// <summary>
        /// 
        /// </summary>
        [Description("Curretage")]
        CUR = 59,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cervical Mucus")]
        CVM = 60,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, CVP")]
        CVPS = 61,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, CVP")]
        CVPT = 62,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nodule, Cystic")]
        CYN = 63,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cyst")]
        CYST = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bite, Dog")]
        DBITE = 65,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum, Deep Cough")]
        DCS = 66,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ulcer, Decubitus")]
        DEC = 67,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Water (Deionized)")]
        DEION = 68,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dialysate")]
        DIA = 69,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dialysis Fluid")]
        DIAF = 70,

        /// <summary>
        /// 
        /// </summary>
        [Description("Discharge")]
        DISCHG = 71,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diverticulum")]
        DIV = 72,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drain")]
        DRN = 73,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Tube")]
        DRNG = 74,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Penrose")]
        DRNGP = 75,

        /// <summary>
        /// 
        /// </summary>
        [Description("Duodenal fluid")]
        DUFL = 76,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ear wax (cerumen)")]
        EARW = 77,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brush, Esophageal")]
        EBRUSH = 78,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Eye Wash")]
        EEYE = 79,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Effluent")]
        EFF = 80,

        /// <summary>
        /// 
        /// </summary>
        [Description("Effusion")]
        EFFUS = 81,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Food")]
        EFOD = 82,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Isolette")]
        EISO = 83,

        /// <summary>
        /// 
        /// </summary>
        [Description("Electrode")]
        ELT = 84,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Unidentified Substance")]
        ENVIR = 85,

        /// <summary>
        /// 
        /// </summary>
        [Description("Eosinophils")]
        EOS = 86,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Other Substance")]
        EOTH = 87,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Soil")]
        ESOI = 88,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Solution (Sterile)")]
        ESOS = 89,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aspirate, Endotrach")]
        ETA = 90,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Endotracheal")]
        ETTP = 91,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tube, Endotracheal")]
        ETTUB = 92,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Whirlpool")]
        EWHI = 93,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gas, exhaled (=breath)")]
        EXG = 94,

        /// <summary>
        /// 
        /// </summary>
        [Description("Shunt, External")]
        EXS = 95,

        /// <summary>
        /// 
        /// </summary>
        [Description("Exudate")]
        EXUDTE = 96,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Water (Well)")]
        FAW = 97,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood, Fetal")]
        FBLOOD = 98,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Abdomen")]
        FGA = 99,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fibroblasts")]
        FIB = 100,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fistula")]
        FIST = 101,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Other")]
        FLD = 102,

        /// <summary>
        /// 
        /// </summary>
        [Description("Filter")]
        FLT = 103,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Body unsp")]
        FLU = 104,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid")]
        FLUID = 105,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Foley")]
        FOLEY = 106,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Respiratory")]
        FRS = 107,

        /// <summary>
        /// 
        /// </summary>
        [Description("Scalp, Fetal")]
        FSCLP = 108,

        /// <summary>
        /// 
        /// </summary>
        [Description("Furuncle")]
        FUR = 109,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gas")]
        GAS = 110,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aspirate, Gastric")]
        GASA = 111,

        /// <summary>
        /// 
        /// </summary>
        [Description("Antrum, Gastric")]
        GASAN = 112,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brushing, Gastric")]
        GASBR = 113,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Gastric")]
        GASD = 114,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid/contents, Gastric")]
        GAST = 115,

        /// <summary>
        /// /
        /// </summary>
        [Description("Genital lochia")]
        GENL = 116,

        /// <summary>
        /// 
        /// </summary>
        [Description("Genital vaginal")]
        GENV = 117,

        /// <summary>
        /// 
        /// </summary>
        [Description("Graft")]
        GRAFT = 118,

        /// <summary>
        /// 
        /// </summary>
        [Description("Graft Site")]
        GRAFTS = 119,

        /// <summary>
        /// 
        /// </summary>
        [Description("Granuloma")]
        GRANU = 120,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter, Groshong")]
        GROSH = 121,

        /// <summary>
        /// 
        /// </summary>
        [Description("Solution, Gastrostomy")]
        GSOL = 122,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biopsy, Gastric")]
        GSPEC = 123,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tube, Gastric")]
        GT = 124,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage Tube, Drainage (Gastrostomy)")]
        GTUBE = 125,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hair")]
        HAR = 126,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bite, Human")]
        HBITE = 127,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood, Autopsy")]
        HBLUD = 128,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Hemaquit")]
        HEMAQ = 129,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Hemovac")]
        HEMO = 130,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue, Herniated")]
        HERNI = 131,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drain, Hemovac")]
        HEV = 132,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter, Hickman")]
        HIC = 133,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Hydrocele")]
        HYDC = 134,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bite, Insect")]
        IBITE = 135,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cyst, Inclusion")]
        ICYST = 136,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Indwelling")]
        IDC = 137,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gas, Inhaled")]
        IHG = 138,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Ileostomy")]
        ILEO = 139,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source of Specimen Is Illegible")]
        ILLEG = 140,

        /// <summary>
        /// 
        /// </summary>
        [Description("Implant")]
        IMP = 141,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Incision/Surgical")]
        INCI = 142,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infiltrate")]
        INFIL = 143,

        /// <summary>
        /// 
        /// </summary>
        [Description("Insect")]
        INS = 144,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Introducer")]
        INTRD = 145,

        /// <summary>
        /// 
        /// </summary>
        [Description("Isolate")]
        ISLT = 146,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intubation tube")]
        IT = 147,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intrauterine Device")]
        IUD = 148,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, IV")]
        IVCAT = 149,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, IV")]
        IVFLD = 150,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tubing Tip, IV")]
        IVTIP = 151,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Jejunal")]
        JEJU = 152,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Joint")]
        JNTFLD = 153,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Jackson Pratt")]
        JP = 154,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lavage")]
        KELOI = 155,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Kidney")]
        KIDFLD = 156,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lavage, Bronhial")]
        LAVG = 157,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lavage, Gastric")]
        LAVGG = 158,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lavage, Peritoneal")]
        LAVGP = 159,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lavage, Pre-Bronch")]
        LAVPG = 160,

        /// <summary>
        /// 
        /// </summary>
        [Description("Contact Lens")]
        LENS1 = 161,

        /// <summary>
        /// 
        /// </summary>
        [Description("Contact Lens Case")]
        LENS2 = 162,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lesion")]
        LESN = 163,

        /// <summary>
        /// 
        /// </summary>
        [Description("Liquid, Unspecified")]
        LIQ = 164,

        /// <summary>
        /// 
        /// </summary>
        [Description("Liquid, Other")]
        LIQO = 165,

        /// <summary>
        /// 
        /// </summary>
        [Description("Line arterial")]
        LNA = 166,

        /// <summary>
        /// 
        /// </summary>
        [Description("Line venous")]
        LNV = 167,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Lumbar Sac")]
        LSAC = 168,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphocytes")]
        LYM = 169,

        /// <summary>
        /// 
        /// </summary>
        [Description("Macrophages")]
        MAC = 170,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Makurkour")]
        MAHUR = 171,

        /// <summary>
        /// 
        /// </summary>
        [Description("Marrow")]
        MAR = 172,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mass")]
        MASS = 173,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood, Menstrual")]
        MBLD = 174,

        /// <summary>
        /// 0
        /// </summary>
        [Description("Meconium")]
        MEC = 175,

        /// <summary>
        /// 
        /// </summary>
        [Description("Breast milk")]
        MILK = 176,

        /// <summary>
        /// 
        /// </summary>
        [Description("Milk")]
        MLK = 177,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mucosa")]
        MUCOS = 178,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mucus")]
        MUCUS = 179,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nail")]
        NAIL = 180,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Nasal")]
        NASDR = 181,

        /// <summary>
        /// 
        /// </summary>
        [Description("Needle")]
        NEDL = 182,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Nephrostomy")]
        NEPH = 183,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aspirate, Nasogastric")]
        NGASP = 184,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Nasogastric")]
        NGAST = 185,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Naso/Gastric")]
        NGS = 186,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nodule(s)")]
        NODUL = 187,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secretion, Nasal")]
        NSECR = 188,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other")]
        ORH = 189,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lesion, Oral")]
        ORL = 190,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source, Other")]
        OTH = 191,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pacemaker")]
        PACEM = 192,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pancreatic fluid")]
        PAFL = 193,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Pericardial")]
        PCFL = 194,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Peritoneal Dialysis")]
        PDSIT = 195,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Peritoneal Dialysis Tunnel")]
        PDTS = 196,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Pelvic")]
        PELVA = 197,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lesion, Penile")]
        PENIL = 198,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Perianal")]
        PERIA = 199,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cyst, Pilonidal")]
        PILOC = 200,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Pin")]
        PINS = 201,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Pacemaker Insetion")]
        PIS = 202,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plant Material")]
        PLAN = 203,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plasma")]
        PLAS = 204,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plasma bag")]
        PLB = 205,

        /// <summary>
        /// 
        /// </summary>
        [Description("Placenta")]
        PLC = 206,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serum, Peak Level")]
        PLEVS = 207,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pleural fluid (thoracentesis fluid)")]
        PLR = 208,

        /// <summary>
        /// 
        /// </summary>
        [Description("Polymorphonuclear neutrophils")]
        PMN = 209,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Penile")]
        PND = 210,

        /// <summary>
        /// 
        /// </summary>
        [Description("Polyps")]
        POL = 211,

        /// <summary>
        /// 
        /// </summary>
        [Description("Graft Site, Popliteal")]
        POPGS = 212,

        /// <summary>
        /// 
        /// </summary>
        [Description("Graft, Popliteal")]
        POPLG = 213,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Popliteal Vein")]
        POPLV = 214,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter, Porta")]
        PORTA = 215,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plasma, Platelet poor")]
        PPP = 216,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prosthetic Device")]
        PROST = 217,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plasma, Platelet rich")]
        PRP = 218,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pseudocyst")]
        PSC = 219,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound, Puncture")]
        PUNCT = 220,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pus")]
        PUS = 221,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pustule")]
        PUSFR = 222,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pus")]
        PUST = 223,

        /// <summary>
        /// 
        /// </summary>
        [Description("Quality Control")]
        QC3 = 224,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Random")]
        RANDU = 225,

        /// <summary>
        /// 
        /// </summary>
        [Description("Erythrocytes")]
        RBC = 226,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bite, Reptile")]
        RBITE = 227,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Rectal")]
        RECT = 228,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Rectal")]
        RECTA = 229,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cyst, Renal")]
        RENALC = 230,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Renal Cyst")]
        RENC = 231,

        /// <summary>
        /// 
        /// </summary>
        [Description("Respiratory")]
        RES = 232,

        /// <summary>
        /// 
        /// </summary>
        [Description("Saliva")]
        SAL = 233,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue, Keloid (Scar)")]
        SCAR = 234,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Subclavian")]
        SCLV = 235,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Scrotal")]
        SCROA = 236,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secretion(s)")]
        SECRE = 237,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serum")]
        SER = 238,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Shunt")]
        SHU = 239,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, Shunt")]
        SHUNF = 240,

        /// <summary>
        /// 
        /// </summary>
        [Description("Shunt")]
        SHUNT = 241,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site")]
        SITE = 242,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biopsy, Skin")]
        SKBP = 243,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin")]
        SKN = 244,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mass, Sub-Mandibular")]
        SMM = 245,

        /// <summary>
        /// /
        /// </summary>
        [Description("Seminal fluid")]
        SMN = 246,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fluid, synovial (Joint fluid)")]
        SNV = 247,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spermatozoa")]
        SPRM = 248,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Suprapubic")]
        SPRP = 249,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cathether Tip, Suprapubic")]
        SPRPB = 250,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Spore Strip")]
        SPS = 251,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum")]
        SPT = 252,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum - coughed")]
        SPTC = 253,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum - tracheal aspirate")]
        SPTT = 254,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum, Simulated")]
        SPUT1 = 255,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum, Inducted")]
        SPUTIN = 256,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum, Spontaneous")]
        SPUTSP = 257,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Sterrad")]
        STER = 258,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stool = Fecal")]
        STL = 259,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stone, Kidney")]
        STONE = 260,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Submandibular")]
        SUBMA = 261,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Submaxillary")]
        SUBMX = 262,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drainage, Sump")]
        SUMP = 263,

        /// <summary>
        /// 
        /// </summary>
        [Description("Suprapubic Tap")]
        SUP = 264,

        /// <summary>
        /// 
        /// </summary>
        [Description("Suture")]
        SUTUR = 265,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Swan Gantz")]
        SWGZ = 266,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sweat")]
        SWT = 267,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aspirate, Tracheal")]
        TASP = 268,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tears")]
        TEAR = 269,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thrombocyte (platelet)")]
        THRB = 270,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue")]
        TISS = 271,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue ulcer")]
        TISU = 272,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cathether Tip, Triple Lumen")]
        TLC = 273,

        /// <summary>
        /// 
        /// </summary>
        [Description("Site, Tracheostomy")]
        TRAC = 274,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transudate")]
        TRANS = 275,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serum, Trough")]
        TSERU = 276,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abscess, Testicular")]
        TSTES = 277,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aspirate, Transtracheal")]
        TTRA = 278,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tubes")]
        TUBES = 279,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tumor")]
        TUMOR = 280,

        /// <summary>
        /// 
        /// </summary>
        [Description("Smear, Tzanck")]
        TZANC = 281,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source, Unidentified")]
        UDENT = 282,

        /// <summary>
        /// 
        /// </summary>
        [Description("Unknown Medicine")]
        UMED = 283,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine")]
        UR = 284,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine clean catch")]
        URC = 285,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Bladder Washings")]
        URINB = 286,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Catheterized")]
        URINC = 287,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Midstream")]
        URINM = 288,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Nephrostomy")]
        URINN = 289,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Pedibag")]
        URINP = 290,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine sediment")]
        URNS = 291,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine catheter")]
        URT = 292,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine, Cystoscopy")]
        USCOP = 293,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source, Unspecified")]
        USPEC = 294,
        /// <summary>
        /// 
        /// </summary>
        [Description("Unkown substance")]
        USUB = 295,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Vas")]
        VASTIP = 296,

        /// <summary>
        /// 
        /// </summary>
        [Description("Catheter Tip, Ventricular")]
        VENT = 297,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vitreous Fluid")]
        VITF = 298,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vomitus")]
        VOM = 299,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wash")]
        WASH = 300,
        /// <summary>
        /// 
        /// </summary>
        [Description("Washing, e.g. bronchial washing")]
        WASI = 301,

        /// <summary>
        /// 
        /// </summary>
        [Description("Water")]
        WAT = 302,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood, Whole")]
        WB = 303,

        /// <summary>
        /// 
        /// </summary>
        [Description("Leukocytes")]
        WBC = 304,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wen")]
        WEN = 305,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wick")]
        WICK = 306,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound")]
        WND = 307,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound abscess")]
        WNDA = 308,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound drainage")]
        WNDD = 309,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wound exudate")]
        WNDE = 310,

        /// <summary>
        /// 
        /// </summary>
        [Description("Worm")]
        WORM = 311,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wart")]
        WRT = 312,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Water")]
        WWA = 313,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Water (Ocean)")]
        WWO = 314,

        /// <summary>
        /// 
        /// </summary>
        [Description("Environmental, Water (Tap)")]
        WWT = 315,









    }
}
