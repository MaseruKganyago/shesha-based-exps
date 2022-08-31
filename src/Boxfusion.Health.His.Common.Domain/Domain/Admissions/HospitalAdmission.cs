using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.BillingClassifications;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.His.Common.Admissions
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

        /// <summary>
        /// 
        /// </summary>
        public virtual string TransferToNonGautengHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsGautengGovFacility { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool CapturedAfterApproval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual BillingClassification BillingClassification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "RegistrationType")]
        public virtual long? RegistrationType { get; set; }
    }
}
