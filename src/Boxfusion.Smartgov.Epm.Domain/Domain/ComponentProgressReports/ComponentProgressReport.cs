using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Components;
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

namespace Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports
{
    [Entity(TypeShortAlias = "Epm.ComponentProgressReport")]
    public class ComponentProgressReport : FullAuditedEntity<Guid>
    {
        public virtual ProgressReport ProgressReport { get; set; }
        public virtual Component Component { get; set; }
        public virtual ComponentProgressReport Parent { get; set; }

        /// <summary>
        /// If true, indicates reporting is skipped for this particular period.
        /// </summary>
        public virtual bool SkipReportingThisPeriod { get; set; }

        public virtual float? PerfIndex { get; set; }
		[ReferenceList("Epm", "RAGValues")]
		public virtual long? RAGValue { get; set; }
		[ReferenceList("Epm", "Trend")]
		public virtual long? Trend { get; set; }
        public virtual float? IndicatorTarget { get; set; }
        public virtual float? IndicatorActual { get; set; }
        public virtual decimal? ExpenditureTarget { get; set; }
        public virtual decimal? ExpenditureActual { get; set; }
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
		[ReferenceList("Epm", "NodeProgressReportStatus")]
		public virtual long? ProgressReportStatus { get; set; }
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
		[ReferenceList("Epm", "IndicatorAuditOutcome")]
		public virtual long? AuditOutcome { get; set; }
		[ReferenceList("Epm", "IndicatorAuditStatus")]
		public virtual long? AuditStatus { get; set; }
        public virtual Person AuditCompletedBy { get; set; }
        public virtual DateTime? AuditCompletedDate { get; set; }
        [StringLength(2000)]
        public virtual string AuditComments { get; set; }
    }
}
