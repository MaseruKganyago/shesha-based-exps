using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    [AutoMap(typeof(WardMidnightCensusReport))]
    public class WardMidnightCensusReportResponse : EntityDto<Guid>
    {
        public EntityWithDisplayNameDto<Guid?> Ward { get; set; }
        public DateTime? ReportDate { get; set; }
        public ReferenceListItemValueDto? ApprovalStatus { get; set; }
        public ReferenceListItemValueDto? ReportType { get; set; }
        public string Description { get; set; }
        public EntityWithDisplayNameDto<Guid?> ApprovedBy { get; set; }
        public EntityWithDisplayNameDto<Guid?> ApprovedBy2 { get; set; }
        public DateTime? ApprovalTime { get; set; }
        public DateTime? ApprovalTime2 { get; set; }
        public string? RejectionComments { get; set; }
        public EntityWithDisplayNameDto<Guid?> RejectedBy { get; set; }
        public int? MidnightCount { get; set; }
        public int? TotalAdmittedPatients { get; set; }
        public int? TotalSeparatedPatients { get; set; }
        public int? TotalBedAvailability { get; set; }
        public int? NumBedsInWard { get; set; }
        public int? TodaysAdmission { get; set; }
        public int? TotalAdmissions { get; set; }
        public int? TotalSeparations { get; set; }
        public double? BedUtilisation { get; set; }
        public double? AverageLengthofStay { get; set; }
    }
}
