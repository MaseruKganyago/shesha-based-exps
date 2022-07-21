using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.His.Common.Localization;
using Shesha;
using Shesha.Authorization;
using Boxfusion.Health.HealthCommon.Core;
using Shesha.Startup;
using Shesha.Reporting;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HealthCommonModule),
        typeof(SheshaCoreModule),
        typeof(SheshaReportingModule)
    )]
    public class HisCommonDomainModule : AbpModule
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

            //Configuration.Settings.Providers.Add<HisDomainSettingProvider>();
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            // Exposing of AppServices and Apis should be within Application layer
            //Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HisDomainModule).Assembly, "HisCore");
            //Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HealthCommonModule).Assembly, "HisCore");

            //Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
            //    typeof(HealthCommonModule).Assembly,
            //    moduleName: "HisCore",
            //    useConventionalHttpVerbs: true);

            //Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
            //    typeof(HisDomainModule).Assembly,
            //    moduleName: "HisCore",
            //    useConventionalHttpVerbs: true);
        }
    }
}