using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.PerformanceReports;
using Newtonsoft.Json;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	/// <summary>
	/// 
	/// </summary>
    [Entity(TypeShortAlias = "Epm.Component")]
	public class Component: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual PerformanceReport PerformanceReport { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(200)]
		public virtual string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(20)]
		public virtual string RefNo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(2000)]
		public virtual string Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? OrderIndex { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual ComponentType ComponentType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Component Parent { get; set; }

		/// <summary>
		/// Links to equivalent Component from PerformanceReport based on the same template for the previous period,
		/// i.e allows for reporting of indicators accross long periods.
		/// </summary>
		public virtual Component Predecessor { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual OrganisationUnit ResponsibleOrganisation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Person ResponsibleReporting { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Person ResponsibleQA1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Person ResponsibleQA2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? LatestPerfIndex { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Epm", "RefListIndexCalculationMethod")]
		public virtual long? PerfIndexCalculationMethod { get; set; }

		/// <summary>
		/// Only applies if PerfIndexCalculationMethod of parent Component is 'WeightedChildren'
		/// </summary>
		public virtual int? PerfIndexWeight { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Epm", "RAGValues")]
		public virtual long? FinalRAGValue { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Epm", "RAGCalculationMethod")]
		public virtual long? RAGCalculationMethod { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? RAGGreenThreshold { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? RAGRedThershold { get; set; }

		/// <summary>
		/// In cases were the Component is specific to an area.
		/// </summary>
		public virtual Area Area { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Epm", "IndicatorProgressReportingMethod")]
		public virtual long? IndicatorProgressReportingMethod { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual IndicatorDefinition IndicatorDefinition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? FinalIndicatorTarget { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? LatestIndicatorValue { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal? FinalExpenditureTarget { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal? LatestExpenditureActual { get; set; }

		/// <summary>
		/// Indicates how the indicator values will be  sourced.
		/// </summary>
		[StringLength(2000)]
		public virtual string DataSource { get; set; }

		/// <summary>
		/// Identifies any limitation with the indicator data, including factors the might be beyond the departments control.
		/// </summary>
		[StringLength(2000)]
		public virtual string DataLimitations { get; set; }

		/// <summary>
		/// If component is of ComponentType KPI, choose KPIType.
		/// </summary>
		[ReferenceList("Epm", "KPIType")]
		public virtual long? KPIType { get; set; }
	}
}
