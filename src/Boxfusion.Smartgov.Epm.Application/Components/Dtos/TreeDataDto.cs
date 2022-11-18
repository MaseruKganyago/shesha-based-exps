using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheshaBased.Epm.Components.Dtos
{
	public class TreeDataDto
	{
		public string Title { get; set; }
		public Guid Key { get; set; }
		public string AdminTreeCreateForm { get; set; }
		public string IconLevel { get; set; }
		public Guid? Parent { get; set; }
		public Single? OrderIndex { get; set; }
		public Guid? ComponentType { get; set; }
		public Guid? PerformanceReport { get; set; }
		public List<TreeDataDto> Children { get; set; }
	}
}
