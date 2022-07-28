﻿using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class DashboardModelQuery : Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string HospitalName { get; set; }
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
		public virtual int? BedInWard { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual int? TotalAdmittedPatients { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual int? TotalBedAvailability { get; set; }
	}
}