using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Administration.Domain.Views
{
    /// <summary>
    /// 
    /// </summary>
    [ImMutable]
    [Table("vw_SpecialityItems")]
    public class SpecialityItems : Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
		public virtual RefListWardSpecialities? Speciality { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public virtual int? NumberOfBedsInSpeciality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid HospitalId { get; set; }
    }
}
