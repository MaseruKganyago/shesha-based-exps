﻿using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// A category assigned to the condition.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterClass")]
    public enum RefListEncounterClass : int
    {
        /// <summary>
        /// A comprehensive term for health care provided in a healthcare facility (e.g. a practitioneraTMs office, clinic setting, or hospital) on a nonresident basis. 
        /// The term ambulatory usually implies that the patient has 
        /// come to the location and is not assigned to a bed. Sometimes referred to as an outpatient encounter.
        /// </summary>
        [Description("Ambulatory")]
        AMB = 1,
        /// <summary>
        /// A patient encounter that takes place at a dedicated healthcare service delivery location where the patient receives immediate evaluation and treatment, 
        /// provided until the patient can be discharged or responsibility for the patient's care is transferred elsewhere (for example, the patient could be 
        /// admitted as an inpatient or transferred to another facility.)
        /// </summary>
        [Description("Emergency")]
        EMER = 2,
        /// <summary>
        /// A patient encounter that takes place both outside a dedicated service delivery location and outside a patient's residence. Example locations might include 
        /// an accident site and at a supermarket.
        /// </summary>
        [Description("Field")]
        FLD = 3,
        /// <summary>
        /// Healthcare encounter that takes place in the residence of the patient or a designee
        /// </summary>
        [Description("Home Health")]
        HH = 4,
        /// <summary>
        /// A patient encounter where a patient is admitted by a hospital or equivalent facility, assigned to a location where patients generally stay at least overnight 
        /// and provided with room, board, and continuous nursing service.
        /// </summary>
        [Description("Inpatient Encounter")]
        IMP = 5,
        /// <summary>
        /// An acute inpatient encounter.
        /// </summary>
        [Description("Inpatient Acute")]
        ACUTE = 6,
        /// <summary>
        /// Any category of inpatient encounter except 'acute'
        /// </summary>
        [Description("Inpatient Non-acute")]
        NONAC = 7,
        /// <summary>
        /// An encounter where the patient usually will start in different encounter, such as one in the emergency department (EMER) but then transition to this type of 
        /// encounter because they require a significant period of treatment and monitoring to determine whether or not their condition warrants an inpatient 
        /// admission or discharge. In the majority of cases the decision about admission or discharge will occur within a time period determined by local, regional or 
        /// national regulation, often between 24 and 48 hours.
        /// </summary>
        [Description("Observation Encounter")]
        OBSENC = 8,
        /// <summary>
        /// A patient encounter where patient is scheduled or planned to receive service delivery in the future, and the patient is given a pre-admission account number. 
        /// When the patient comes back for subsequent service, the pre-admission encounter is selected and is encapsulated into the service registration, and a new account number 
        /// is generated. Usage Note: This is intended to be used in advance of encounter types such as ambulatory, inpatient encounter, virtual, etc.
        /// </summary>
        [Description("Pre-admission")]
        PRENC = 9,
        /// <summary>
        /// An encounter where the patient is admitted to a health care facility for a predetermined length of time, usually less than 24 hours.
        /// </summary>
        [Description("Short Stay")]
        SS = 10,
        /// <summary>
        /// A patient encounter where the patient and the practitioner(s) are not in the same physical location. Examples include telephone conference, email exchange, 
        /// robotic surgery, and televideo conference.
        /// </summary>
        [Description("Virtual")]
        VR = 11,

    }
}
