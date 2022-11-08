using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
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
		public virtual string RAGThresholds 
		{
			get
			{
				if (!string.IsNullOrEmpty(RAGThresholds))
					RAGThresholdsList = JsonConvert.DeserializeObject<List<RefListRAGValues>>(RAGThresholds);

				return RAGThresholds;
			}
			set 
			{
				if (RAGThresholdsList.Count > 0)
					value = JsonConvert.SerializeObject(RAGThresholdsList);
			} 
		}

		/// <summary>
		/// The Indicator the Component relates to. Only applies if ComponentType.IsIndincator = true.
		/// </summary>
		public virtual Indicator Indicator { get; set; }

		/// <summary>
		/// In cases were the Component is specific to an area.
		/// </summary>
		public virtual Area Area { get; set; }

		/// <summary>
		/// In cases were the Component is specific to a Project.
		/// </summary>
		public virtual Project Project { get; set; }

		public virtual RefListIndicatorProgressReportingMethod? IndicatorProgressReportingMethod { get; set; }
		public virtual IndicatorDefinition IndicatorDefinition { get; set; }
		public virtual Single? FinalIndicatorTarget { get; set; }
		public virtual Single? LatestIndicatorValue { get; set; }
		public virtual decimal FinalExpenditureTarget { get; set; }
		public virtual decimal LatestExpenditureActual { get; set; }

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
		[NotMapped]
		public List<RefListRAGValues> RAGThresholdsList { get; set; }
	}
}
