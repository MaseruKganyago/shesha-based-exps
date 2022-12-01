using Abp.AutoMapper;
using Abp.Modules;
using Shesha;
using Shesha.Enterprise;
using System.Reflection;

namespace Boxfusion.Smartgov.Epm
{
	[DependsOn(
		typeof(SheshaCoreModule),
		typeof(SheshaEnterpriseModule),
		typeof(SheshaApplicationModule)
	)]
	public class EpmDomainModule : AbpModule
	{
		/// inheritedDoc
		public override void Initialize()
		{
			//IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
			//IocManager.IocContainer.Register(
			//    Component.For<ICustomPermissionChecker>().Forward<IHisPermissionChecker>().Forward<HisPermissionChecker>().ImplementedBy<HisPermissionChecker>().LifestyleTransient()
			//);

			var thisAssembly = Assembly.GetExecutingAssembly();
			IocManager.RegisterAssemblyByConvention(thisAssembly);

			Configuration.Modules.AbpAutoMapper().Configurators.Add(
				// Scan the assembly for classes which inherit from AutoMapper.Profile
				cfg => cfg.AddMaps(thisAssembly)
			);
		}

		/// inheritedDoc
		public override void PreInitialize()
		{
			base.PreInitialize();

		}

		/// inheritedDoc
		public override void PostInitialize()
		{
			// Exposing of AppServices and Apis should be within Application layer
		}
	}
}