using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Cdm.Patients
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmPatient")]
    public class CdmPatient : Patient
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDisabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsEmployed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool HasMedicalAid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string MedicalAidName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string MedicalAidNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string MobilePin { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual int NumberOfDependents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Occupation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string NameOfEmployer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string WorkTelephone { get; set; }

    }
}
