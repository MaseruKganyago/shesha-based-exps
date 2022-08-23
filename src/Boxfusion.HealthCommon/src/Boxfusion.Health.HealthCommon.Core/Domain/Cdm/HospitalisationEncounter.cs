using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.HospitalisationEncounter")]
    [Table("Fhir_Encounters")]
    public class HospitalisationEncounter : Encounter
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string PreAdmissionIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OriginOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OriginOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "EncounterHospitalisationAdmitSources")]
        public virtual int? AdmitSource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "EncounterHospitalisationReAdmissionIndicators")]
        public virtual int? ReAdmission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Cdm", "EncounterHospitalisationDiets")]
        public virtual int? DietPreference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Cdm", "EncounterHospitalisationSpecialCourtesies")]
        public virtual int? SpecialCourtesy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Cdm", "EncounterHospitalisationSpecialArrangements")]
        public virtual int? SpecialArrangement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string DestinationOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string DestinationOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Cdm", "EncounterHospitalisationDischargeDispositions")]
        public virtual int? DischargeDisposition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string AdmissionNotes { get; set; }
    }
}
