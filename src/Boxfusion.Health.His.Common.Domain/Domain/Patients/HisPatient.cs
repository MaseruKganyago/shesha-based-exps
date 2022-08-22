using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Boxfusion.Health.Cdm.Patients;
using Shesha.Domain;

namespace Boxfusion.Health.His.Common.Patients
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisPatient")]
    public class HisPatient : CdmPatient
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string PatientMasterIndexNumber { get; set; }

       
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "Provinces")]
        public virtual long? PatientProvince { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string HospitalPatientNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "PatientType")]
        public virtual long? PatientType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile ProofOfResidents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile PaySlip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile MedicalAidDocument { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile RefferalNote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile MotivationLetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile AffidavitUnemployed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile AffidavitLostDocuments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile OtherDocuments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string MedicalAidOption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "DependentNumber")]
        public virtual long? DependentNumber { get; set; }
    }
}
