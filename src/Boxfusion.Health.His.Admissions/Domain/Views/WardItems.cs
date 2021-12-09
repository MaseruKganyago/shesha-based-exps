﻿using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Views
{
    /// <summary>
    /// 
    /// </summary>
    [ImMutable]
    [Table("vw_WardItems")]
    public class WardItems : Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
		public virtual RefListWardSpecialities? Speciality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual int? NumberOfBeds { get; set; }
	}
}