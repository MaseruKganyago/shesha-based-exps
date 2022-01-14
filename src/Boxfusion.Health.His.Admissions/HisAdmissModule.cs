using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Boxfusion.Health.His.Admissions.Authorization;
//using Boxfusion.Health.His.Admissions.Configuration;
using Boxfusion.Health.His.Admissions.Localization;
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
    public class HisAdmissModule : AbpModule
    {
        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IHisAdmissPermissionChecker>().Forward<HisAdmissPermissionChecker>().ImplementedBy<HisAdmissPermissionChecker>().LifestyleTransient()
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
            Configuration.Authorization.Providers.Add<HisAdmissAuthorizationProvider>();

            HisAdmissLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void PostInitialize()
        {
            try
            {
                Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                    typeof(HisAdmissModule).Assembly,
                    moduleName: "HisAdmis",
                    useConventionalHttpVerbs: true);
            }
            catch
            {
            }
        }
    }
}