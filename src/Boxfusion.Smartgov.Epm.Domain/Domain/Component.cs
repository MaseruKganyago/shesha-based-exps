using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
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
	[Entity(TypeShortAlias = "Epm.Component")]
	public class Component: FullAuditedEntity<Guid>
	{
		public virtual PerformanceReport PerformanceReport { get; set; }
		[StringLength(200)]
		public virtual string Name { get; set; }
		[StringLength(20)]
		public virtual string RefNo { get; set; }
		[StringLength(2000)]
		public virtual string Description { get; set; }
		public virtual Single? OrderIndex { get; set; }
		public virtual ComponentType ComponentType { get; set; }
		public virtual Component Parent { get; set; }

		/// <summary>
		/// Links to equivalent Component from PerformanceReport based on the same template for the previous period,
		/// i.e allows for reporting of indicators accross long periods.
		/// </summary>
		public virtual Component Predecessor { get; set; }
		public virtual OrganisationUnit ResponsibleOrganisation { get; set; }
		public virtual Person ResponsibleReporting { get; set; }
		public virtual Person ResponsibleQA1 { get; set; }
		public virtual Person ResponsibleQA2 { get; set; }
		public virtual Single? LatestPerfIndex { get; set; }
		public virtual RefListIndexCalculationMethod? PerfIndexCalculationMethod { get; set; }

		/// <summary>
		/// Only applies if PerfIndexCalculationMethod of parent Component is 'WeightedChildren'
		/// </summary>
		public virtual int? PerfIndexWeight { get; set; }
		public virtual RefListRAGValues? LatestRAGValue { get; set; }
		public virtual RefListRAGCalculationMethod RAGCalculationMethod { get; set; }
		[StringLength(int.MaxValue)]
		public virtual string RAGThresholds { get; set; }
	}
}
