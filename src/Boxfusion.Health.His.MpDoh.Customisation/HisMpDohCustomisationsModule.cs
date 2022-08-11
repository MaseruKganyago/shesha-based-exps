using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Bookings;
using Boxfusion.Health.His.Bookings.Localization;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Domain;
using Shesha;
using Shesha.Startup;
using System.Reflection;

namespace Boxfusion.Health.His.MpDoh
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HisBookingsDomainModule),
        typeof(HisCommonDomainModule),
        typeof(HealthCommonModule),
        typeof(SheshaApplicationModule),
        typeof(SheshaCoreModule)
    )]
    public class HisMpDohCustomisationsModule : AbpModule
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
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void PostInitialize()
        {

        }
    }
}