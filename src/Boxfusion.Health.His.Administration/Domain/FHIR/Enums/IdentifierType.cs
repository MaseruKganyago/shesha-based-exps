using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// A coded type for the identifier that can be used to determine which identifier to use for a specific purpose.
    /// </summary>
    [ReferenceList("HealthDomain", "IdentifierType")]
    public enum RefListIdentifierType : int
    {
        /// <summary>
        /// Accreditation/Certification Identifier
        /// </summary>
        [Description("Accreditation/Certification Identifier")]
        AC = 1,
        /// <summary>
        /// Accession Identifier
        /// </summary>
        [Description("Accession ID")]
        ACSN = 2,
        /// <summary>
        /// Deprecated and replaced by BC in v 2.5.
        /// </summary>
        [Description("American Express")]
        AM = 3,
        /// <summary>
        /// A physician identifier assigned by the AMA.
        /// </summary>
        [Description("American Medical Association Number")]
        AMA = 4,
        /// <summary>
        /// An identifier that is unique to an account.
        /// </summary>
        [Description("Account number")]
        AN = 5,
        /// <summary>
        /// Class: Financial A more precise definition of an account number: sometimes two distinct account numbers must be 
        /// transmitted in the same message, one as the creditor, the other as the debitor. Kreditorenkontonummer
        /// </summary>
        [Description("Account number Creditor")]
        ANC = 6,
        /// <summary>
        /// Class: Financial A more precise definition of an account number: sometimes two distinct account numbers must be 
        /// transmitted in the same message, one as the creditor, the other as the debitor. Debitorenkontonummer
        /// </summary>
        [Description("Account number debitor")]
        AND = 7,
        /// <summary>
        /// An identifier for a living subject whose real identity is protected or suppressed Justification: For public health 
        /// reporting purposes, anonymous identifiers are occasionally used for protecting patient identity in reporting certain 
        /// results. For instance, a state health department may choose to use a scheme for generating an anonymous identifier 
        /// for reporting a patient that has had a positive human immunodeficiency virus antibody test. Anonymous identifiers can 
        /// be used in PID 3 by replacing the medical record number or other non-anonymous identifier. The assigning authority for 
        /// an anonymous identifier would be the state/local health department.
        /// </summary>
        [Description("Anonymous identifier")]
        ANON = 8,
        /// <summary>
        /// Class: Financial Temporary version of an Account Number. Use Case: An ancillary system that does not normally assign 
        /// account numbers is the first time to register a patient. This ancillary system will generate a temporary account number 
        /// that will only be used until an official account number is assigned.
        /// </summary>
        [Description("Temporary Account Number")]
        ANT = 9,
        /// <summary>
        /// An identifier that is unique to an advanced practice registered nurse within the jurisdiction of a certifying board
        /// </summary>
        [Description("Advanced Practice Registered Nurse number")]
        APRN = 10,
        /// <summary>
        /// A unique identifier for the ancestor specimen. All child, grandchild, etc. specimens of the ancestor specimen share the 
        /// same Ancestor Specimen ID.
        /// </summary>
        [Description("Ancestor Specimen ID")]
        ASID = 11,
        /// <summary>
        /// Class: Financial
        /// </summary>
        [Description("Bank Account Number")]
        BA = 12,
        /// <summary>
        /// Class: Financial An identifier that is unique to a person's bank card. Replaces AM, DI, DS, MS, and VS beginning in v 2.5.
        /// </summary>
        [Description("Bank Card Number")]
        BC = 13,
        /// <summary>
        /// 
        /// </summary>
        [Description("Birth Certificate File Number")]
        BCFN = 14,
        /// <summary>
        /// A number associated with a document identifying the event of a person's birth.
        /// </summary>
        [Description("Birth Certificate")]
        BCT = 15,
        /// <summary>
        /// A number associated with a document identifying the event of a person's birth.
        /// </summary>
        [Description("Birth registry number")]
        BR = 16,
        /// <summary>
        /// 
        /// </summary>
        [Description("Breed Registry Number")]
        BRN = 17,
        /// <summary>
        /// Betriebsstättennummer - for use in the German realm.
        /// </summary>
        [Description("Primary physician office number")]
        BSNR = 18,
        /// <summary>
        /// Class: Financial Use Case: needed especially for transmitting information about invoices.
        /// </summary>
        [Description("Cost Center number")]
        CC = 19,
        /// <summary>
        /// A number associated with a document identifying a person's legal change of name.
        /// </summary>
        [Description("Change of Name Document")]
        CONM = 20,
        /// <summary>
        /// 
        /// </summary>
        [Description("County number")]
        CY = 21,
        /// <summary>
        /// A number assigned by a person's country of residence to identify a person's citizenship.
        /// </summary>
        [Description("Citizenship Card")]
        CZ = 22,
        /// <summary>
        /// 
        /// </summary>
        [Description("Death Certificate ID")]
        DC = 23,
        /// <summary>
        /// 
        /// </summary>
        [Description("Death Certificate File Number")]
        DCFN = 24,
        /// <summary>
        /// An identifier that is unique to a dentist within the jurisdiction of the licensing board
        /// </summary>
        [Description("Dentist license number")]
        DDS = 25,
        /// <summary>
        /// An identifier for an individual or organization relative to controlled substance regulation and transactions. 
        /// Use case: This is a registration number that identifies an individual or organization relative to controlled substance 
        /// regulation and transactions. A DEA number has a very precise and widely accepted meaning within the United States. 
        /// Surprisingly, the US Drug Enforcement Administration does not solely assign DEA numbers in the United States. 
        /// Hospitals have the authority to issue DEA numbers to their medical residents. These DEA numbers are based upon the 
        /// hospital’s DEA number, but the authority rests with the hospital on the assignment to the residents. Thus, DEA as an 
        /// Identifier Type is necessary in addition to DEA as an Assigning Authority.
        /// </summary>
        [Description("Drug Enforcement Administration registration number")]
        DEA = 26,
        /// <summary>
        /// An identifier issued to a health care provider authorizing the person to write drug orders Use Case: A nurse practitioner 
        /// has authorization to furnish or prescribe pharmaceutical substances; this identifier is in component 1.
        /// </summary>
        [Description("Drug Furnishing or prescriptive authority Number")]
        DFN = 27,
        /// <summary>
        /// Deprecated and replaced by BC in v 2.5.
        /// </summary>
        [Description("Diner's Club card")]
        DI = 28,
        /// <summary>
        /// 
        /// </summary>
        [Description("Driver's license number")]
        DL = 29,
        /// <summary>
        /// 
        /// </summary>
        [Description("Doctor number")]
        DN = 30,
        /// <summary>
        /// An identifier that is unique to an osteopath within the jurisdiction of a licensing board.
        /// </summary>
        [Description("Osteopathic License number")]
        DO = 31,
        /// <summary>
        /// A number assigned to a diplomatic passport.
        /// </summary>
        [Description("Diplomatic Passport")]
        DP = 32,
        /// <summary>
        /// An identifier that is unique to a podiatrist within the jurisdiction of the licensing board.
        /// </summary>
        [Description("Podiatrist license number")]
        DPM = 33,
        /// <summary>
        /// 
        /// </summary>
        [Description("Donor Registration Number")]
        DR = 34,
        /// <summary>
        /// Deprecated and replaced by BC in v 2.5.
        /// </summary>
        [Description("Discover Card.")]
        DS = 35,
        /// <summary>
        /// A number that uniquely identifies an employee to an employer.
        /// </summary>
        [Description("Employee number")]
        EI = 36,
        /// <summary>
        /// A number that uniquely identifies an employee to an employer.
        /// </summary>
        [Description("Employer number")]
        EN = 37,
        /// <summary>
        /// An identifier that is unique to a staff member within an enterprise (as identified by the Assigning Authority).
        /// </summary>
        [Description("Staff Enterprise Number")]
        ESN = 38,
        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal Death Report ID")]
        FDR = 39,
        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal Death Report File Number")]
        FDRFN = 40,
        /// <summary>
        /// 
        /// </summary>
        [Description("Facility ID")]
        FI = 41,
        /// <summary>
        /// 
        /// </summary>
        [Description("Filler Identifier")]
        FILL = 42,
        /// <summary>
        /// Class: Financial
        /// </summary>
        [Description("Guarantor internal identifier")]
        GI = 43,
        /// <summary>
        /// Class: Financial
        /// </summary>
        [Description("General ledger number")]
        GL = 44,
        /// <summary>
        /// Class: Financial
        /// </summary>
        [Description("Guarantor external identifier")]
        GN = 45,
        /// <summary>
        /// 
        /// </summary>
        [Description("Health Card Number")]
        HC = 46,
        /// <summary>
        /// A number assigned to a member of an indigenous or aboriginal group outside of Canada.
        /// </summary>
        [Description("Indigenous/Aboriginal")]
        IND = 47,
        /// <summary>
        /// Class: Insurance 2 uses: a) UK jurisdictional CHI number; b) Canadian provincial health card number:
        /// </summary>
        [Description("Jurisdictional health number (Canada)")]
        JHN = 48,
        /// <summary>
        /// A laboratory accession id is used in the laboratory domain. The concept of accession is used in other domains such as 
        /// radiology, so the LACSN is used to distinguish a lab accession id from an radiology accession id
        /// </summary>
        [Description("Laboratory Accession ID")]
        LACSN = 49,
        /// <summary>
        /// Lifelong physician number
        /// </summary>
        [Description("Lifelong physician number")]
        LANR = 50,
        /// <summary>
        /// 
        /// </summary>
        [Description("Labor and industries number")]
        LI = 51,
        /// <summary>
        /// 
        /// </summary>
        [Description("License number")]
        LN = 52,
        /// <summary>
        /// 
        /// </summary>
        [Description("Local Registry ID")]
        LR = 53,
        /// <summary>
        /// Class: Insurance
        /// </summary>
        [Description("Patient Medicaid number")]
        MA = 54,
        /// <summary>
        /// An identifier for the insured of an insurance policy (this insured always has a subscriber), usually assigned by the 
        /// insurance carrier. Use Case: Person is covered by an insurance policy. This person may or may not be the subscriber of 
        /// the policy.
        /// </summary>
        [Description("Member Number")]
        MB = 55,
        /// <summary>
        /// Class: Insurance
        /// </summary>
        [Description("Patient's Medicare number")]
        MC = 56,
        /// <summary>
        /// Class: Insurance
        /// </summary>
        [Description("Practitioner Medicaid number")]
        MCD = 57,
        /// <summary>
        /// 
        /// </summary>
        [Description("Microchip Number")]
        MCN = 58,
        /// <summary>
        /// Class: Insurance
        /// </summary>
        [Description("Practitioner Medicare number")]
        MCR = 59,
        /// <summary>
        /// A number associated with a document identifying the event of a person's marriage.
        /// </summary>
        [Description("Marriage Certificate")]
        MCT = 60,
        /// <summary>
        /// An identifier that is unique to a medical doctor within the jurisdiction of a licensing board. Use Case: These license 
        /// numbers are sometimes used as identifiers. In some states, the same authority issues all three identifiers, 
        /// e.g., medical, osteopathic, and physician assistant licenses all issued by one state medical board. For this case, 
        /// the CX data type requires distinct identifier types to accurately interpret component 1. Additionally, the distinction 
        /// among these license types is critical in most health care settings (this is not to convey full licensing information, 
        /// which requires a segment to support all related attributes).
        /// </summary>
        [Description("Medical License number")]
        MD = 61,
        /// <summary>
        /// A number assigned to an individual who has had military duty, but is not currently on active duty. The number is 
        /// assigned by the DOD or Veterans' Affairs (VA).
        /// </summary>
        [Description("Military ID number")]
        MI = 62,
        /// <summary>
        /// An identifier that is unique to a patient within a set of medical records, not necessarily unique within an application.
        /// </summary>
        [Description("Medical record number")]
        MR = 63,
        /// <summary>
        /// Temporary version of a Medical Record Number Use Case: An ancillary system that does not normally assign medical record 
        /// numbers is the first time to register a patient. This ancillary system will generate a temporary medical record number that 
        /// will only be used until an official medical record number is assigned.
        /// </summary>
        [Description("Temporary Medical Record Number")]
        MRT = 64,
        /// <summary>
        /// Deprecated and replaced by BC in v 2.5.
        /// </summary>
        [Description("MasterCard")]
        MS = 65,
        /// <summary>
        /// Nebenbetriebsstättennummer - for use in the German realm.
        /// </summary>
        [Description("Secondary physician office number")]
        NBSNR = 66,
        /// <summary>
        /// A number associated with a document identifying a person's retention of citizenship in a particular country.
        /// </summary>
        [Description("Naturalization Certificate")]
        NCT = 67,
        /// <summary>
        /// In the US, the Assigning Authority for this value is typically CMS, but it may be used by all providers and insurance 
        /// companies in HIPAA related transactions.
        /// </summary>
        [Description("National employer identifier")]
        NE = 68,
        /// <summary>
        /// Class: Insurance Used for the UK NHS national identifier. In the US, the Assigning Authority for this value is typically 
        /// CMS, but it may be used by all providers and insurance companies in HIPAA related transactions.
        /// </summary>
        [Description("National Health Plan Identifier")]
        NH = 69,
        /// <summary>
        /// Class: Insurance In the US, the Assigning Authority for this value is typically CMS, but it may be used by all providers 
        /// and insurance companies in HIPAA related transactions.
        /// </summary>
        [Description("National unique individual identifier")]
        NI = 70,
        /// <summary>
        /// Class: Insurance In Germany a national identifier for an insurance company. It is printed on the insurance card 
        /// (health card). It is not to be confused with the health card number itself. Krankenkassen-ID der KV-Karte
        /// </summary>
        [Description("National Insurance Organization Identifier")]
        NII = 71,
        /// <summary>
        /// Class: Insurance In Germany the insurance identifier addressed as the payor. Krankenkassen-ID des Rechnungsempfängers 
        /// Use case: a subdivision issues the card with their identifier, but the main division is going to pay the invoices.
        /// </summary>
        [Description("National Insurance Payor Identifier (Payor)")]
        NIIP = 72,
        /// <summary>
        /// National Person Identifier
        /// </summary>
        [Description("National Person Identifier")]
        NNZAF = 73,
        /// <summary>
        /// An identifier that is unique to a nurse practitioner within the jurisdiction of a certifying board.
        /// </summary>
        [Description("Nurse practitioner number")]
        NP = 74,
        /// <summary>
        /// Class: Insurance In the US, the Assigning Authority for this value is typically CMS, but it may be used by all providers 
        /// and insurance companies in HIPAA related transactions.
        /// </summary>
        [Description("National provider identifier")]
        NPI = 75,
        /// <summary>
        /// 
        /// </summary>
        [Description("Observation Instance Identifier")]
        OBI = 76,
        /// <summary>
        /// A number that is unique to an individual optometrist within the jurisdiction of the licensing board.
        /// </summary>
        [Description("Optometrist license number")]
        OD = 77,
        /// <summary>
        /// An identifier that is unique to a physician assistant within the jurisdiction of a licensing board
        /// </summary>
        [Description("Physician Assistant number")]
        PA = 78,
        /// <summary>
        /// A number identifying a person on parole.
        /// </summary>
        [Description("Parole Card")]
        PC = 79,
        /// <summary>
        /// A number assigned to individual who is incarcerated.
        /// </summary>
        [Description("Penitentiary/correctional institution Number")]
        PCN = 80,
        /// <summary>
        /// An identifier that is unique to a living subject within an enterprise (as identified by the Assigning Authority).
        /// </summary>
        [Description("Living Subject Enterprise Number")]
        PE = 81,
        /// <summary>
        /// 
        /// </summary>
        [Description("Pension Number")]
        PEN = 82,
        /// <summary>
        /// 
        /// </summary>
        [Description("Public Health Case Identifier")]
        PHC = 83,
        /// <summary>
        /// 
        /// </summary>
        [Description("Public Health Event Identifier")]
        PHE = 84,
        /// <summary>
        /// 
        /// </summary>
        [Description("Public Health Official ID")]
        PHO = 85,
        /// <summary>
        /// A number that is unique to a patient within an Assigning Authority.
        /// </summary>
        [Description("Patient internal identifier")]
        PI = 86,
        /// <summary>
        /// 
        /// </summary>
        [Description("Placer Identifier")]
        PLAC = 87,
        /// <summary>
        /// A number that is unique to a living subject within an Assigning Authority.
        /// </summary>
        [Description("Person number")]
        PN = 88,
        /// <summary>
        /// Temporary version of a Lining Subject Number.
        /// </summary>
        [Description("Temporary Living Subject Number")]
        PNT = 89,
        /// <summary>
        /// Class: Insurance
        /// </summary>
        [Description("Medicare/CMS Performing Provider Identification Number")]
        PPIN = 90,
        /// <summary>
        /// A unique number assigned to the document affirming that a person is a citizen of the country. In the US this number is 
        /// issued only by the State Department.
        /// </summary>
        [Description("Passport number")]
        PPN = 91,
        /// <summary>
        /// 
        /// </summary>
        [Description("Permanent Resident Card Number")]
        PRC = 92,
        /// <summary>
        /// A number that is unique to an individual provider, a provider group or an organization within an Assigning Authority. 
        /// Use case: This allows PRN to represent either an individual (a nurse) or a group/organization (orthopedic surgery team).
        /// </summary>
        [Description("Provider number")]
        PRN = 93,
        /// <summary>
        /// 
        /// </summary>
        [Description("Patient external identifier")]
        PT = 94,
        /// <summary>
        /// 
        /// </summary>
        [Description("QA number")]
        QA = 95,
        /// <summary>
        /// A generalized resource identifier. Use Case: An identifier type is needed to accommodate what are commonly known as 
        /// resources. The resources can include human (e.g. a respiratory therapist), non-human (e.g., a companion animal), 
        /// inanimate object (e.g., an exam room), organization (e.g., diabetic education class) or any other physical or logical 
        /// entity.
        /// </summary>
        [Description("Resource identifier")]
        RI = 96,
        /// <summary>
        /// An identifier that is unique to a registered nurse within the jurisdiction of the licensing board.
        /// </summary>
        [Description("Registered Nurse Number")]
        RN = 97,
        /// <summary>
        /// An identifier that is unique to a pharmacist within the jurisdiction of the licensing board.
        /// </summary>
        [Description("Pharmacist license number")]
        RPH = 98,
        /// <summary>
        /// An identifier for an individual enrolled with the Railroad Retirement Administration. Analogous to, but distinct from, 
        /// a Social Security Number
        /// </summary>
        [Description("Railroad Retirement number")]
        RR = 99,
        /// <summary>
        /// 
        /// </summary>
        [Description("Regional registry ID")]
        RRI = 100,
        /// <summary>
        /// Class: Insurance
        /// </summary>
        [Description("Railroad Retirement Provider")]
        RRP = 101,
        /// <summary>
        /// 
        /// </summary>
        [Description("Social Beneficiary Identifier")]
        SB = 102,
        /// <summary>
        /// Identifier for a specimen. Used when it is not known if the specimen ID is a unique specimen ID (USID) or an ancestor ID 
        /// (ASID).
        /// </summary>
        [Description("Specimen ID")]
        SID = 103,
        /// <summary>
        /// 
        /// </summary>
        [Description("State license")]
        SL = 104,
        /// <summary>
        /// Class: Insurance An identifier for a subscriber of an insurance policy which is unique for, and usually assigned by, 
        /// the insurance carrier. Use Case: A person is the subscriber of an insurance policy. The person’s family may be plan 
        /// members, but are not the subscriber.
        /// </summary>
        [Description("	Subscriber Number")]
        SN = 105,
        /// <summary>
        /// 
        /// </summary>
        [Description("State assigned NDBS card Identifier")]
        SNBSN = 106,
        /// <summary>
        /// 
        /// </summary>
        [Description("Serial Number")]
        SNO = 107,
        /// <summary>
        /// A number associated with a permit identifying a person who is a resident of a jurisdiction for the purpose of education.
        /// </summary>
        [Description("Study Permit")]
        SP = 108,
        /// <summary>
        /// 
        /// </summary>
        [Description("State registry ID")]
        SR = 109,
        /// <summary>
        /// 
        /// </summary>
        [Description("Social Security number")]
        SS = 110,
        /// <summary>
        /// 
        /// </summary>
        [Description("Shipment Tracking Number")]
        STN = 111,
        /// <summary>
        /// 
        /// </summary>
        [Description("Tax ID number")]
        TAX = 112,
        /// <summary>
        /// A number assigned to a member of an indigenous group in Canada. Use Case: First Nation.
        /// </summary>
        [Description("Treaty Number/ (Canada)")]
        TN = 113,
        /// <summary>
        /// Temporary Permanent Resident (Canada)
        /// </summary>
        [Description("Treaty Number/ (Canada)")]
        TPR = 114,
        /// <summary>
        /// Temporary Permanent Resident (Canada)
        /// </summary>
        [Description("Training License Number")]
        TRL = 115,
        /// <summary>
        /// Temporary Permanent Resident (Canada)
        /// </summary>
        [Description("Unspecified identifier")]
        U = 116,
        /// <summary>
        /// 
        /// </summary>
        [Description("Universal Device Identifier")]
        UDI = 117,
        /// <summary>
        /// Class: Insurance An identifier for a provider within the CMS/Medicare program. A globally unique identifier for 
        /// the provider in the Medicare program.
        /// </summary>
        [Description("Medicare/CMS (formerly HCFA)'s Universal Physician Identification numbers")]
        UPIN = 118,
        /// <summary>
        /// A unique identifier for a specimen.
        /// </summary>
        [Description("Unique Specimen ID")]
        USID = 119,
        /// <summary>
        /// 
        /// </summary>
        [Description("Visit number")]
        VN = 120,
        /// <summary>
        /// A number associated with a document identifying a person as a visitor of a jurisdiction or country.
        /// </summary>
        [Description("Visitor Permit")]
        VP = 121,
        /// <summary>
        /// Deprecated and replaced by BC in v 2.5.
        /// </summary>
        [Description("VISA")]
        VS = 122,
        /// <summary>
        /// 
        /// </summary>
        [Description("WIC identifier")]
        WC = 123,
        /// <summary>
        /// 
        /// </summary>
        [Description("Workers' Comp Number")]
        WCN = 124,
        /// <summary>
        /// A number associated with a permit for a person who is granted permission to work in a country for a specified time period.
        /// </summary>
        [Description("Work Permit")]
        WP = 125,
        /// <summary>
        /// 
        /// </summary>
        [Description("Health Plan Identifier")]
        XV = 126,
        /// <summary>
        /// 
        /// </summary>
        [Description("Organization identifier")]
        XX = 127,
    }
}
