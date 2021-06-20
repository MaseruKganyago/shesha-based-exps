using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.Domain.Authorization;
using Boxfusion.Health.Domain.Configuration;
using Boxfusion.Health.Domain.Localization;
using Shesha;
using Shesha.Authorization;

namespace Boxfusion.Health.Domain
{
    /// <summary>
    /// HealthDomain Module
    /// </summary>
    [DependsOn(
        typeof(SheshaCoreModule)
    )]
    public class HealthDomainModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IHealthDomainPermissionChecker>().Forward<HealthDomainPermissionChecker>().ImplementedBy<HealthDomainPermissionChecker>().LifestyleTransient()
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

            Configuration.Settings.Providers.Add<HealthDomainSettingProvider>();
            Configuration.Authorization.Providers.Add<HealthDomainAuthorizationProvider>();

            HealthDomainLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HealthDomainModule).Assembly,
                moduleName: "HealthDomain",
                useConventionalHttpVerbs: true);
        }
    }
}