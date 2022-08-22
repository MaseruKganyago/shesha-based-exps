using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Common.WardRoleAppointedPersons
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.WardRoleAppointedPerson")]
    public class WardRoleAppointedPerson : ShaRoleAppointedPerson
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual HisWard Ward { get; set; }

        private HisHealthFacility _healthFacility = null;

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public virtual HisHealthFacility HisHealthFacility 
        { 
            get 
            {
                var wardRoleAppointedPersonManager = new WardRoleAppointedPersonManager();
                _healthFacility = wardRoleAppointedPersonManager.GetFacilityFromWard(Ward);

				return _healthFacility;
            }
            set
            {
            }
        }
    }
}
