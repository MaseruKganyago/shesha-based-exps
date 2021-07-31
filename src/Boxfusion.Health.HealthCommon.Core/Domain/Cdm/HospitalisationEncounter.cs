using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.HospitalisationEncounter")]
    public class HospitalisationEncounter : Encounter
    {
        public virtual string PreAdmissionIdentifier { get; set; }

        public virtual string OriginOwnerId { get; set; }

        public virtual string OriginOwnerType { get; set; }

        [ReferenceList("Cdm", "EncounterHospitalisationAdmitSources")]
        public virtual int? AdmitSource { get; set; }

        [ReferenceList("Cdm", "EncounterHospitalisationReAdmissionIndicators")]
        public virtual int? ReAdmission { get; set; }

        [MultiValueReferenceList("Cdm", "EncounterHospitalisationDiets")]
        public virtual int? DietPreference { get; set; }

        [MultiValueReferenceList("Cdm", "EncounterHospitalisationSpecialCourtesies")]
        public virtual int? SpecialCourtesy { get; set; }

        [MultiValueReferenceList("Cdm", "EncounterHospitalisationSpecialArrangements")]
        public virtual int? SpecialArrangement { get; set; }

        public virtual string DestinationOwnerId { get; set; }

        public virtual string DestinationOwnerType { get; set; }

        [MultiValueReferenceList("Cdm", "EncounterHospitalisationDischargeDispositions")]
        public virtual int? DischargeDisposition { get; set; }
    }
}
