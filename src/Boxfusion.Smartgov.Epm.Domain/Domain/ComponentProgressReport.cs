﻿using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
    [Entity(TypeShortAlias = "Epm.ComponentProgressReport")]
	public class ComponentProgressReport: FullAuditedEntity<Guid>
	{
		public virtual ProgressReport ProgressReport { get; set; }
		public virtual Component Component { get; set; }
		public virtual ComponentProgressReport Parent { get; set; }

		/// <summary>
		/// If true, indicates reporting is skipped for this particular period.
		/// </summary>
		public virtual bool SkipReportingThisPeriod { get; set; }

		public virtual Single? PerfIndex { get; set; }
		public virtual RefListRAGValues? RAGValue { get; set; }
		public virtual RefListTrend? Trend { get; set; }
		public virtual Single? IndicatorTarget { get; set; }
		public virtual Single? IndicatorActual { get; set; }
		public virtual decimal? ExpenditureTarget { get; set; }
		public virtual decimal? ExpenditurerActual { get; set; }
		[StringLength(2000)]
		public virtual string Achievements { get; set; }
		[StringLength(2000)]
		public virtual string VarianceReason { get; set; }
		[StringLength(2000)]
		public virtual string CorrectiveMeasure { get; set; }
		public virtual bool PoeRequired { get; set; }
		public virtual StoredFile PortfolioOfEvidence { get; set; }
		[StringLength(2000)]
		public virtual string OtherComments { get; set; }
		public virtual RefListNodeProgressReportStatus? ProgressReportStatus { get; set; }
		public virtual Person ReportedBy { get; set; }
		public virtual DateTime? ReportedDate { get; set; }
		public virtual Person QA1CompletedBy { get; set; }
		public virtual DateTime? QA1CompletedDate { get; set; }
		[StringLength(2000)]
		public virtual string QA1Comments { get; set; }
		public virtual Person QA2CompletedBy { get; set; }
		public virtual DateTime? QA2CompletedDate { get; set; }
		[StringLength(2000)]
		public virtual string QA2Comments { get; set; }
		public virtual RefListIndicatorAuditOutcome? AuditOutcome { get; set; }
		public virtual RefListIndicatorAuditStatus? AuditStatus { get; set; }
		public virtual Person AuditCompletedBy { get; set; }
		public virtual DateTime? AuditCompletedDate { get; set; }
		[StringLength(2000)]
		public virtual string AuditComments { get; set; }
	}
}
