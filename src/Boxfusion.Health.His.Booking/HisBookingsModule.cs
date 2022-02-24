using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Bookings.Localization;
using Boxfusion.Health.His.Domain;
using Shesha;
using Shesha.Startup;
using System.Reflection;

namespace Boxfusion.Health.His.Bookings
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HisDomainModule),
        typeof(SheshaCoreModule),
        typeof(SheshaApplicationModule),
        typeof(HealthCommonModule)
    )]
    public class HisBookingsModule : AbpModule
    {
        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
          
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
            //Configuration.Authorization.Providers.Add<HisBookingsAuthorizationProvider>();

            HisBookingsLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HisBookingsModule).Assembly,
                moduleName: "HisBookings",
                useConventionalHttpVerbs: true);

            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HealthCommonModule).Assembly, "HisBookings");
            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(SheshaCoreModule).Assembly, "HisBookings");
        }
    }
}