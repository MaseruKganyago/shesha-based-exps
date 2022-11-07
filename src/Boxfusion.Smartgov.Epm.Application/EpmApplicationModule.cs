using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Smartgov.Epm.Localization;
using Shesha.Startup;
using System.Reflection;

namespace Boxfusion.Smartgov.Epm
{
	[DependsOn(
		typeof(EpmDomainModule))]
	public class EpmApplicationModule : AbpModule
	{
		/// inheritedDoc
		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
			//IocManager.IocContainer.Register(
			//  Component.For<ICustomPermissionChecker>().Forward<IHisPermissionChecker>().Forward<HisPermissionChecker>().ImplementedBy<HisPermissionChecker>().LifestyleTransient()
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

			Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(EpmDomainModule).Assembly, "Epm");

			Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
				assembly: typeof(EpmDomainModule).Assembly,
				moduleName: "Epm",
				useConventionalHttpVerbs: true);

			Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
				assembly: typeof(EpmApplicationModule).Assembly,
				moduleName: "Epm",
				useConventionalHttpVerbs: true);

			//Configuration.Settings.Providers.Add<HisDomainSettingProvider>();
			//Configuration.Authorization.Providers.Add<HisBookingsAuthorizationProvider>();    //TODO: To reinstitute permissions later - currently being handled with Common

			EpmLocalizationConfigurer.Configure(Configuration.Localization);
		}
	}
}