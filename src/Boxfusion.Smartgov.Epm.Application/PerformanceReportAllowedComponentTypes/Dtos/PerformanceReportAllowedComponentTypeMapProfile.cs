using Boxfusion.Smartgov.Epm.Domain;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.PerformanceReportAllowedComponentTypes.Dtos
{
	public class PerformanceReportAllowedComponentTypeMapProfile : ShaProfile
	{
		public PerformanceReportAllowedComponentTypeMapProfile()
		{
			CreateMap<PerformanceReportAllowedComponentType, FlattenedAllowedComponentTypesDto>()
				.ForMember(a => a.FormPath, b => b.MapFrom(c => c.ComponentType.AdminTreeCreateForm))
				.ForMember(a => a.ComponentTypeId, b => b.MapFrom(c => c.ComponentType.Id))
				.ForMember(a => a.Id, b => b.MapFrom(c => c.ComponentType.Id))
				.ForMember(a => a.ComponentTypeName, b => b.MapFrom(c => c.ComponentType.Name));
		}
	}
}
