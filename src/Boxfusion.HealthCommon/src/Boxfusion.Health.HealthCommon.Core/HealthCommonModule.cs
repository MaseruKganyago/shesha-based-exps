using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Localization;
using Castle.MicroKernel.Registration;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shesha;
using Shesha.Authorization;
using Shesha.Configuration;
using Shesha.RabbitMQ;
using System.Reflection;

namespace Boxfusion.Health.HealthCommon.Core
{
    /// <summary>
    /// TeleHealth Module
    /// </summary>
    [DependsOn(
        typeof(SheshaCoreModule),
        typeof(AbpAspNetCoreModule)
    )]
    public class HealthCommonModule : AbpModule
    {
        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void Initialize()
        {
            var _env = IocManager.IocContainer.Resolve<IWebHostEnvironment>();
            var _appConfiguration = _env.GetAppConfiguration();

            var thisAssembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<ICdmPermissionChecker>().Forward<CdmPermissionChecker>().ImplementedBy<CdmPermissionChecker>().LifestyleTransient()
            );
            var connectionString = _appConfiguration["ConnectionStrings:RabbitMqConnection"];
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                IocManager.IocContainer.Register(
                    Component.For<IBus>().LifestyleSingleton().UsingFactoryMethod(() =>
                    {
                        return RabbitHutch.CreateBus(_appConfiguration["ConnectionStrings:RabbitMqConnection"], c => c.
                                           Register<ITypeNameSerializer>(new TypeAliasTypeNameSerializer(new[] { typeof(HealthCommonModule).Assembly })).
                                           Register<IConventions, SheshaMQConventions>());
                    })
                );
            }

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

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HealthCommonModule).Assembly,
                moduleName: "HealthCommon",
                useConventionalHttpVerbs: true);

            Configuration.Settings.Providers.Add<CdmSettingProvider>();
            Configuration.Authorization.Providers.Add<CdmAuthorizationProvider>();

            CdmLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            var lifeTime = IocManager.Resolve<IHostApplicationLifetime>();

            if (IocManager.IsRegistered<IBus>()) {
                var bus = IocManager.Resolve<IBus>();
                lifeTime.ApplicationStarted.Register(() =>
                {
                    var subscriber = new AutoSubscriber(bus, "HealthCommon");
                    subscriber.Subscribe(typeof(HealthCommonModule).Assembly);
                    subscriber.SubscribeAsync(typeof(HealthCommonModule).Assembly);
                });

                lifeTime.ApplicationStopped.Register(() => { bus.Dispose(); });
            }
        }
    }
}


