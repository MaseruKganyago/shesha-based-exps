using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.His.Administration.Authorization;
//using Boxfusion.Health.His.Administration.Configuration;
using Boxfusion.Health.His.Administration.Localization;
using Shesha;
using Shesha.Authorization;
using Boxfusion.Health.His.Domain;

namespace Boxfusion.Health.His.Admissions
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HisDomainModule),
        typeof(SheshaCoreModule)
    )]
    public class HisBookingsModule : AbpModule
    {
        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IHisBookingsPermissionChecker>().Forward<HisBookingsPermissionChecker>().ImplementedBy<HisBookingsPermissionChecker>().LifestyleTransient()
          );

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
            Configuration.Authorization.Providers.Add<HisBookingsAuthorizationProvider>();

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
        }
    }
}