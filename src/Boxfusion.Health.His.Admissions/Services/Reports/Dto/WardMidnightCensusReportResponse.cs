using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Common;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardMidnightCensusReport))]
    public class WardMidnightCensusReportResponse : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Ward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReportDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto? ApprovalStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto? ReportType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> ApprovedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> ApprovedBy2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ApprovalTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ApprovalTime2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? RejectionComments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> RejectedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MidnightCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalAdmittedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalSeparatedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalBedAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NumBedsInWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TodaysAdmission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalAdmissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalSeparations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? BedUtilisation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? AverageLengthofStay { get; set; }
    }
}
