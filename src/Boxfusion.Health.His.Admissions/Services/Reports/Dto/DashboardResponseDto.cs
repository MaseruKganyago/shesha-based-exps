using Abp.AutoMapper;
using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
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
    [AutoMapFrom(typeof(DashboardModelQuery))]
    public class DashboardResponseDto : Entity<Guid>
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
