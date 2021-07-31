using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Shesha;
using Shesha.Authorization;

namespace Boxfusion.Health.HealthCommon.Core
{
    /// <summary>
    /// TeleHealth Module
    /// </summary>
    [DependsOn(
        typeof(SheshaCoreModule)
    )]
    public class HealthCommonModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
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

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {

            });
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HealthCommonModule).Assembly,
                moduleName: "HealthCommon",
                useConventionalHttpVerbs: true);
        }
    }
}


