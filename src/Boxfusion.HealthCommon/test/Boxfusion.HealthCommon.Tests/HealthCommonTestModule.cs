using System;
using Abp;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using NSubstitute;
using Boxfusion.Health.His.Tests.DependencyInjection;
using Shesha;
using Shesha.Configuration.Runtime;
using Shesha.NHibernate;
using Shesha.Services;
using Boxfusion.Health.HealthCommon.Core;
using Abp.AspNetCore.Configuration;
using Microsoft.Extensions.Hosting;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Castle.Facilities.Logging;
using System.Reflection;

namespace Boxfusion.Health.His.Tests
{
    [DependsOn(
        typeof(AbpKernelModule),
        typeof(AbpTestBaseModule),
        typeof(SheshaApplicationModule),
        typeof(SheshaNHibernateModule),
        typeof(SheshaFrameworkModule),
        typeof(HealthCommonModule)
        )]
    public class HealthCommonTestModule : AbpModule
    {
        //private const string ConnectionString = @"Data Source=sql-shared-nonprod.database.windows.net;Initial Catalog=boxhealthhis-test;User=boxdbadmin;Password=n0-hack.2020;MultipleActiveResultSets=True;TrustServerCertificate=True";
        private string ConnectionString;

        public HealthCommonTestModule(SheshaNHibernateModule nhModule)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ConnectionString = config.GetConnectionString("TestDB");

            nhModule.ConnectionString = ConnectionString;
            nhModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            // Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            // mock IWebHostEnvironment
            IocManager.IocContainer.Register(Component.For<IWebHostEnvironment>().ImplementedBy<TestWebHostEnvironment>().LifestyleSingleton());

            IocManager.IocContainer.Register(
                Component.For<IAbpAspNetCoreConfiguration>()
                    .ImplementedBy<AbpAspNetCoreConfiguration>()
                    .LifestyleSingleton()
            );

            var appLifetimeMoq = new Mock<IHostApplicationLifetime>();
            IocManager.IocContainer.Register(
                Component.For<IHostApplicationLifetime>()
                    .Instance(appLifetimeMoq.Object)
                    .LifestyleSingleton()
            );

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);
            IocManager.IocContainer.Register(
                Component.For<IConfiguration>()
                    .Instance(configuration.Object)
                    .LifestyleSingleton()
            );

            IocManager.IocContainer.Register(
                Component.For<IBackgroundJobClient>()
                    .UsingFactoryMethod(() =>
                    {
                        var storage = new SqlServerStorage(ConnectionString);
                        JobStorage.Current = storage;
                        return new BackgroundJobClient(storage);
                    })
                    .LifestyleSingleton()
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<SheshaDbMigrator>();

            Configuration.ReplaceService<IDynamicRepository, DynamicRepository>(DependencyLifeStyle.Transient);

            // replace email sender
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);

            // replace connection string resolver
            Configuration.ReplaceService<IDbPerTenantConnectionStringResolver, TestConnectionStringResolver>(DependencyLifeStyle.Transient);

            Configuration.ReplaceService<ICurrentUnitOfWorkProvider, AsyncLocalCurrentUnitOfWorkProvider>(DependencyLifeStyle.Singleton);

            if (!IocManager.IsRegistered<ApplicationPartManager>())
                IocManager.IocContainer.Register(Component.For<ApplicationPartManager>().ImplementedBy<ApplicationPartManager>());
        }

        public override void Initialize()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            //IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));

            StaticContext.SetIocManager(IocManager);

            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}