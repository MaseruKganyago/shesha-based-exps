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
    [Table("vw_HospitalItems")]
    public class HospitalItems : Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
		public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual RefListHospitalTypes? Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual decimal? Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual decimal? Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string PrimaryContactTelephone { get; set; }
	}
}
