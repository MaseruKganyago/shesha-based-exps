using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Domain;
using Boxfusion.Health.His.Domain.Authorization;
using Boxfusion.Health.His.Domain.Localization;
using Shesha;
using Shesha.Authorization;
using Shesha.Startup;
using System;
using Castle.MicroKernel.Registration;
using System.Reflection;
using Boxfusion.Health.His.Bookings;

namespace Boxfusion.Health.His.Bookings
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HealthCommonModule),
        typeof(SheshaCoreModule),
        typeof(HisBookingsDomainModule)
    )]
    public class HisBookingsApplicationModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IHisPermissionChecker>().Forward<HisPermissionChecker>().ImplementedBy<HisPermissionChecker>().LifestyleTransient()
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
            Configuration.Authorization.Providers.Add<HisAuthorizationProvider>();

            HisDomainLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(HisBookingsDomainModule).Assembly, "HisBookings");

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HisBookingsDomainModule).Assembly,
                moduleName: "HisBookings",
                useConventionalHttpVerbs: true);
        }
    }

}
