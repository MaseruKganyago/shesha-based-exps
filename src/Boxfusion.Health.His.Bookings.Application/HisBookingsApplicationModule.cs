using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Bookings.Localization;
using Shesha;
using Shesha.Startup;
using System.Reflection;

namespace Boxfusion.Health.His.Bookings
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HealthCommonModule),
        typeof(SheshaCoreModule),
        typeof(HisBookingsDomainModule),
        typeof(AbpAspNetCoreModule)
    )]
    public class HisBookingsApplicationModule : AbpModule
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

            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HisBookingsDomainModule).Assembly, "HisBookings");

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                assembly: typeof(HisBookingsDomainModule).Assembly,
                moduleName: "HisBookings",
                useConventionalHttpVerbs: true);

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                assembly: typeof(HisBookingsApplicationModule).Assembly,
                moduleName: "HisBookings",
                useConventionalHttpVerbs: true);

            //Configuration.Settings.Providers.Add<HisDomainSettingProvider>();
            //Configuration.Authorization.Providers.Add<HisBookingsAuthorizationProvider>();    //TODO: To reinstitute permissions later - currently being handled with Common

            HisBookingsLocalizationConfigurer.Configure(Configuration.Localization);
        }
    }
}
