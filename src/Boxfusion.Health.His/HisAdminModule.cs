using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.His.Admissions.Authorization;
using Boxfusion.Health.His.Admissions.Configuration;
using Boxfusion.Health.His.Admissions.Localization;
using Shesha;
using Shesha.Authorization;

namespace Boxfusion.Health.His.Admissions
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(SheshaCoreModule)
    )]
    public class HisAdminModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IHisAdminPermissionChecker>().Forward<HisAdminPermissionChecker>().ImplementedBy<HisAdminPermissionChecker>().LifestyleTransient()
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

            Configuration.Settings.Providers.Add<HisAdminSettingProvider>();
            Configuration.Authorization.Providers.Add<HisAdminAuthorizationProvider>();

            HisAdminLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HisAdminModule).Assembly,
                moduleName: "His",
                useConventionalHttpVerbs: true);
        }
    }
}