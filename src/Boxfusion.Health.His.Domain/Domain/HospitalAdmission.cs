using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HospitalAdmission")]
    [Table("Fhir_Encounters")]
    public class HospitalAdmission : HisAdmission
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string HospitalAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListHospitalAdmissionStatuses HospitalAdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListClassifications Classification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListOtherCategories OtherCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirOrganisation TransferFroHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirOrganisation TransferToHospital { get; set; }
    }
}
