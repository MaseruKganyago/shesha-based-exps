using Abp;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Boxfusion.Health.His.Admissions;
using Boxfusion.Health.His.Tests.DependencyInjection;
using Castle.MicroKernel.Registration;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using NSubstitute;
using Shesha;
using Shesha.NHibernate;
using Shesha.Services;
using System;

namespace Boxfusion.Health.His.Tests.Modules
{
    [DependsOn(
        typeof(AbpKernelModule),
        typeof(AbpTestBaseModule),
        typeof(SheshaApplicationModule),
        typeof(SheshaNHibernateModule),
        typeof(SheshaFrameworkModule),
        typeof(HisAdmissModule)
        )]
    public class SeparationsTestModule : AbpModule
    {
        private const string connectionString = @"Data Source = 129.232.214.82; Initial Catalog = eThekwini; User=boxfusion;Password=!!!BoxSqlPass2015;MultipleActiveResultSets=True";

        public SeparationsTestModule(SheshaNHibernateModule nhModule)
        {
            nhModule.ConnectionString = connectionString;

            /*
            nhModule.UseInMemoryDatabase = true;
            nhModule.SkipDbSeed = true;
            */
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactionScopeAvailable = false;

            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            var hostingEnvironment = Mock.Of<IWebHostEnvironment>(e => e.ApplicationName == "test");
            IocManager.IocContainer.Register(
                Component.For<IWebHostEnvironment>()
                    .UsingFactoryMethod(() => hostingEnvironment)
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
                        var storage = new SqlServerStorage(connectionString);
                        JobStorage.Current = storage;
                        return new BackgroundJobClient(storage);
                    })
                    .LifestyleSingleton()
            );

            //IocManager.Register<IUtilManPermissionChecker, UtilManPermissionChecker>();
            //Configuration.ReplaceService<IPushNotifier, NullPushNotifier>(DependencyLifeStyle.Transient);

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            // RegisterFakeService<SheshaDbMigrator>();

            Configuration.ReplaceService<IDynamicRepository, DynamicRepository>(DependencyLifeStyle.Transient);

            //Configuration.ReplaceService<ISmsGateway, NullSmsGateway>(DependencyLifeStyle.Transient);

            // replace email sender
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);

            // replace connection string resolver
            Configuration.ReplaceService<IDbPerTenantConnectionStringResolver, TestConnectionStringResolver>(DependencyLifeStyle.Transient);

        }

        public override void Initialize()
        {
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
