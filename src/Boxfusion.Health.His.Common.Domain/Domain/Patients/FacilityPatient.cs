using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Common.Patients
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.FacilityPatient")]
    [DiscriminatorValue("His.HisPatient")]
    [Discriminator]
    public class FacilityPatient : HisPatient
    {
        private string _facilityPatientIdentifier = null;
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public virtual string FacilityPatientIdentifier 
        {
            get
            {
                if (_facilityPatientIdentifier is null)
                {
                    var patientManager = new PatientManager();
                    _facilityPatientIdentifier = patientManager.GetContextFacilityPatientIdentifier(this.Id);
                }
                return _facilityPatientIdentifier; 
            } 
            set { _facilityPatientIdentifier = value;  }
        }
    }
}
