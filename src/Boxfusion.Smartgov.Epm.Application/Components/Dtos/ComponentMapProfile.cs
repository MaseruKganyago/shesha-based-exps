using Abp.Domain.Entities;
using Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports;
using Shesha.AutoMapper;

namespace Boxfusion.Smartgov.Epm.Components.Dtos
{
	public class ComponentMapProfile: ShaProfile
	{
		public ComponentMapProfile()
		{
			CreateMap<ComponentProgressReport, ComponentReportingDto>()
				.ForMember(a => a.Component, b => b.MapFrom(c => NullableObjectId(c.Component)))
				.ForMember(a => a.PortfolioOfEvidence, b => b.MapFrom(c => NullableObjectId(c.PortfolioOfEvidence)))
				.ForMember(a => a.ProgressReport, b => b.MapFrom(c => NullableObjectId(c.ProgressReport)))
				.ForMember(a => a.NodeName, b => b.MapFrom(c => c.Component.Name));
		}

		private Guid? NullableObjectId<T>(T entity) where T: IEntity<Guid>
		{
			if (entity is null) return null;

			return entity.Id;
		}
	}
}
