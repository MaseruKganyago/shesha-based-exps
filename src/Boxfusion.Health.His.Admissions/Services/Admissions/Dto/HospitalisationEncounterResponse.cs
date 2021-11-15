using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(HospitalisationEncounter))]
    public class HospitalisationEncounterResponse: FhirEncounterResponse
	{
        /// <summary>
        /// 
        /// </summary>
        public string PreAdmissionIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OriginOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OriginOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmitSource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto ReAdmission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto DietPreference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto SpecialCourtesy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto SpecialArrangement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DestinationOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DestinationOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto DischargeDisposition { get; set; }
    }
}
