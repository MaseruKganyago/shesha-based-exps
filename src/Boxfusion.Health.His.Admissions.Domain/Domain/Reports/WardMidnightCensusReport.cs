using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.WardMidnightCensusReport")]
    public class WardMidnightCensusReport : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual HisWard Ward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ReportDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListApprovalStatuses? ApprovalStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListReportType? ReportType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase ApprovedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase ApprovedBy2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ApprovalTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ApprovalTime2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? RejectionComments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase RejectedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? MidnightCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? TotalAdmittedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? TotalBedAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? TotalSeparatedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? NumBedsInWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? TodaysAdmission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual double? BedUtilisation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? AverageLengthofStay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? AverageBedAvailability { get; set; }

    }
}
