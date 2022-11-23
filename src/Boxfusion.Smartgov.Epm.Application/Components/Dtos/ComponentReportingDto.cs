using Abp.Application.Services.Dto;
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
		public string NodeTarget { get; set; }
	}
}
