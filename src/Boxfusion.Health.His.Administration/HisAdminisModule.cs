using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.His.Administration.Localization;
using Shesha;
using Shesha.Authorization;
using Boxfusion.Health.His.Domain;
using Boxfusion.Health.His.Domain.Authorization;

namespace Boxfusion.Health.His.Admissions
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HisDomainModule),
        typeof(SheshaCoreModule)
    )]
    public class HisAdminisModule : AbpModule
    {
        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
          //  IocManager.IocContainer.Register(
          //    Component.For<ICustomPermissionChecker>().Forward<IHisPermissionChecker>().Forward<HisPermissionChecker>().ImplementedBy<HisPermissionChecker>().LifestyleTransient()
          //);

            var thisAssembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void PreInitialize()
        {
            base.PreInitialize();

            //Configuration.Settings.Providers.Add<HisAdmisSettingProvider>();
            ///Configuration.Authorization.Providers.Add<HisAuthorizationProvider>();

            HisAdminisLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HisAdminisModule).Assembly,
                moduleName: "HisAdminis",
                useConventionalHttpVerbs: true);
        }
    }
}