using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Localization;
using Boxfusion.Health.HealthCommon.Core.Reports;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Locations.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Organisations.Helper;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers;
using Castle.MicroKernel.Registration;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shesha;
using Shesha.Authorization;
using Shesha.Configuration;
using Shesha.RabbitMQ;
using Shesha.Services;

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
              Component.For<ICustomPermissionChecker>().Forward<ICdmPermissionChecker>().Forward<CdmPermissionChecker>().ImplementedBy<CdmPermissionChecker>().LifestyleTransient(),
              Component.For<IBus>().LifestyleSingleton().Instance(RabbitHutch.CreateBus(_appConfiguration["ConnectionStrings:RabbitMqConnection"], c => c.
                           Register<ITypeNameSerializer>(new TypeAliasTypeNameSerializer(new[] { typeof(HealthCommonModule).Assembly })).
                           Register<IConventions, SheshaMQConventions>()))
              );

            IocManager.Register(typeof(IDocumentProcessor<>),
              typeof(DocumentProcessor<>),
              DependencyLifeStyle.Transient);

            IocManager.Register(typeof(IEncounterCrudHelper<>),
              typeof(EncounterCrudHelper<>),
              DependencyLifeStyle.Transient);

            IocManager.Register(typeof(IServiceRequestCrudHelper<,>),
              typeof(ServiceRequestCrudHelper<,>),
              DependencyLifeStyle.Transient);

            IocManager.Register(typeof(ILocationCrudHelper<,>),
              typeof(LocationCrudHelper<,>),
              DependencyLifeStyle.Transient);

            IocManager.Register(typeof(IOrganisationCrudHelper<,>),
              typeof(OrganisationCrudHelper<,>),
              DependencyLifeStyle.Transient);

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

            base.PreInitialize();

            Configuration.Settings.Providers.Add<CdmSettingProvider>();
            Configuration.Authorization.Providers.Add<CdmAuthorizationProvider>();

            CdmLocalizationConfigurer.Configure(Configuration.Localization);
            //Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            //{

            //});
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(HealthCommonModule).Assembly,
                moduleName: "HealthCommon",
                useConventionalHttpVerbs: true);

            var lifeTime = IocManager.Resolve<IHostApplicationLifetime>();
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


