using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Domain;
using Boxfusion.Health.His.Common.Authorization;
using Boxfusion.Health.His.Common.Localization;
using Shesha;
using Shesha.Authorization;
using Shesha.Startup;
using System;
using Castle.MicroKernel.Registration;
using System.Reflection;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HealthCommonModule),
        typeof(HisCommonDomainModule),
        typeof(SheshaCoreModule)
    )]
    public class HisCommonApplicationModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
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

            //Configuration.Settings.Providers.Add<HisDomainSettingProvider>();
            //Configuration.Authorization.Providers.Add<HisAuthorizationProvider>();        // Initiatlisation handled within Web project

            HisCommonLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HisCommonDomainModule).Assembly, "Common");
            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HealthCommonModule).Assembly, "Cdm");

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HealthCommonModule).Assembly,
                moduleName: "Cdm",
                useConventionalHttpVerbs: true);

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HisCommonDomainModule).Assembly,
                moduleName: "Common",
                useConventionalHttpVerbs: true);

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                assembly: typeof(HisCommonApplicationModule).Assembly,
                moduleName: "Common",
                useConventionalHttpVerbs: true);

            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(SheshaApplicationModule).Assembly, "App");
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(SheshaApplicationModule).GetAssembly()
                 );


            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(SheshaCoreModule).Assembly, "Core");
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(SheshaCoreModule).GetAssembly()
                 );


        }
    }

}
