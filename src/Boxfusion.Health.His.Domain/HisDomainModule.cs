using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.His.Domain.Authorization;
//using Boxfusion.Health.His.Domain.Configuration;
using Boxfusion.Health.His.Domain.Localization;
using Shesha;
using Shesha.Authorization;
using Boxfusion.Health.HealthCommon.Core;

namespace Boxfusion.Health.His.Domain
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HealthCommonModule),
        typeof(SheshaCoreModule)
    )]
    public class HisDomainModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IHisDomainPermissionChecker>().Forward<HisDomainPermissionChecker>().ImplementedBy<HisDomainPermissionChecker>().LifestyleTransient()
          );

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

            //Configuration.Settings.Providers.Add<HisDomainSettingProvider>();
            Configuration.Authorization.Providers.Add<HisDomainAuthorizationProvider>();

            HisDomainLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HisDomainModule).Assembly,
                moduleName: "HisDomain",
                useConventionalHttpVerbs: true);
        }
    }
}