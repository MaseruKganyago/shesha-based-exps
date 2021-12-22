﻿using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class DashboardModelQuery : Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
		public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public int? BedInWard { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int? TotalAdmittedPatients { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int? TotalBedAvailability { get; set; }
	}
}
