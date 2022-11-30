using Abp.Application.Services.Dto;
using Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Components.Dtos
{
	public class ComponentReportingDto: EntityDto<Guid>
	{
		public string NodeName { get; set; }
		public string NodePath { get; set; }
		public string Achievements { get; set; }
		public Guid? Component { get; set; }
		public string CorrectiveMeasure { get; set; }
		public string OtherComments { get; set; }
		public bool PoeRequired { get; set; }
		public Guid PortfolioOfEvidence { get; set; }
		public Guid ProgressReport { get; set; }
		public long? ProgressReportStatus { get; set; }
		public string VarianceReason { get; set; }
		public float? IndicatorTarget { get; set; }
		public float? IndicatorActual { get; set; }
	}
}
