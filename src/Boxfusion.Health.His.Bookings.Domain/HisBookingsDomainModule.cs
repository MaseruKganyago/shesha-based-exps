using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Bookings.Localization;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Domain;
using Shesha;
using Shesha.Enterprise.Reporting;
using Shesha.Startup;
using System.Reflection;

namespace Boxfusion.Health.His.Bookings
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HisCommonDomainModule),
        typeof(SheshaCoreModule),
        typeof(SheshaApplicationModule),
        typeof(HealthCommonModule),
        typeof(SheshaReportingModule)
    )]
    public class HisBookingsDomainModule : AbpModule
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