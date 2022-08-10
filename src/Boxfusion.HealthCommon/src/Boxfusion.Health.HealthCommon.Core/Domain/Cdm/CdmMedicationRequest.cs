using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
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
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmMedicationRequest")]
    [Table("Fhir_MedicationRequests")]
    public class CdmMedicationRequest : MedicationRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string MedicationName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string MedicationCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Dosages")]
        public virtual RefListDosages? Dosage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Routes")]
        public virtual RefListRoutes? Route { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Frequencies")]
        public virtual RefListFrequencies? Frequency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Durations")]
        public virtual RefListDurations? Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Repeats")]
        public virtual RefListRepeats? Repeat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Cdm", "Instructions")]
        public virtual RefListInstructions? Instruction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string AdditionalInstruction { get; set; }
    }
}
