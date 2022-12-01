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
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "Epm.ComponentProgressReport")]
    public class ComponentProgressReport : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual ProgressReport ProgressReport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Component Component { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ComponentProgressReport Parent { get; set; }

        /// <summary>
        /// If true, indicates reporting is skipped for this particular period.
        /// </summary>
        public virtual bool SkipReportingThisPeriod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? PerfIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[ReferenceList("Epm", "RAGValues")]
		public virtual long? RAGValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[ReferenceList("Epm", "Trend")]
		public virtual long? Trend { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? IndicatorTarget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual float? IndicatorActual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? ExpenditureTarget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? ExpenditureActual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string Achievements { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string VarianceReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string CorrectiveMeasure { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool PoeRequired { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StoredFile PortfolioOfEvidence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string OtherComments { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[ReferenceList("Epm", "NodeProgressReportStatus")]
		public virtual long? ProgressReportStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Person ReportedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ReportedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Person QA1CompletedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? QA1CompletedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string QA1Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Person QA2CompletedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? QA2CompletedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string QA2Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[ReferenceList("Epm", "IndicatorAuditOutcome")]
		public virtual long? AuditOutcome { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[ReferenceList("Epm", "IndicatorAuditStatus")]
		public virtual long? AuditStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Person AuditCompletedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? AuditCompletedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public virtual string AuditComments { get; set; }
    }
}
