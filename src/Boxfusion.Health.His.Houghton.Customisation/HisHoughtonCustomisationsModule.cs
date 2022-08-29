using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.His.Admissions;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Domain;
using Shesha;
using System.Reflection;

namespace Boxfusion.Health.His.Houghton.Customisation
{
    /// <summary>
    /// Health.His Module
    /// </summary>
    [DependsOn(
        typeof(HisAdmissionsDomainModule),
        typeof(HisCommonDomainModule),
        typeof(HealthCommonModule),
        typeof(SheshaApplicationModule),
        typeof(SheshaCoreModule)
    )]
    public class HisHoughtonCustomisationsModule: AbpModule
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
            try
            {
				Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
					typeof(HisHoughtonCustomisationsModule).Assembly,
					moduleName: "HoughCustom",
					useConventionalHttpVerbs: true);
			}
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
