﻿using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain
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
        public virtual Ward Ward { get; set; }

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
        public virtual int? MidnightCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? TotalAdmittedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? TotalSeparatedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? TotalBedAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? NumBedsInWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual double? BedUtilisation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual double? AverageLengthofStay { get; set; }
    }
}
