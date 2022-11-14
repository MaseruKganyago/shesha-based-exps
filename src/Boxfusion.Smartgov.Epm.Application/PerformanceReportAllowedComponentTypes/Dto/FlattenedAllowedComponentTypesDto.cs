using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheshaBased.Epm.PerformanceReportAllowedComponentTypes.Dto
{
	public class FlattenedAllowedComponentTypesDto: Entity<Guid>
	{
		public string FormPath { get; set; }
		public Guid ComponentTypeId { get; set; }
		public string ComponentTypeName { get; set; }
		public bool CanBeRoot { get; set; }
	}
}
