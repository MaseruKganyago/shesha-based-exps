using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.AutoMapper;
using Abp.FluentValidation;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using Boxfusion.Smartgov.Epm.Authorization;
using Boxfusion.Smartgov.Epm.Languages;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shesha;
using Shesha.Authentication.JwtBearer;
using Shesha.Authorization;
using Shesha.Bootstrappers;
using Shesha.Configuration;
using Shesha.ConfigurationItems;
using Shesha.Elmah;
using Shesha.Enterprise.Reporting;
using Shesha.Enterprise.Workflow;
using Shesha.GraphQL;
using Shesha.NHibernate;
using Shesha.Scheduler;
using Shesha.Startup;
using Shesha.Web.FormsDesigner;
using System;
using System.Text;

namespace Boxfusion.Smartgov.Epm
{
	[DependsOn(
        typeof(SheshaFrameworkModule),
        typeof(SheshaApplicationModule),
        typeof(SheshaNHibernateModule),
        typeof(AbpAspNetCoreModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpAutoMapperModule),
        typeof(SheshaElmahModule),
        typeof(SheshaSchedulerModule),
        typeof(SheshaGraphQLModule),
        typeof(AbpFluentValidationModule),
        // enterprise modules
        typeof(SheshaWorkflowModule),
        typeof(SheshaReportingModule),
        typeof(SheshaEnterpriseModule),
        typeof(SheshaFormsDesignerModule),
        // smartgov ep modules
        typeof(EpmDomainModule),
        typeof(EpmApplicationModule)
     )]
    public class EpmWebCoreModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public EpmWebCoreModule(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                SheshaConsts.ConnectionStringName
            );

			Configuration.Authorization.Providers.Add<EpmAuthorizationProvider>();

			// Use database for language management
			Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(SheshaApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();

            /*
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<DataTableColumn, DataTableColumnDto>()
                    .ForMember(u => u.Password, options => options.Ignore())
                    .ForMember(u => u.Email, options => options.MapFrom(input => input.EmailAddress));
            });
            */
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EpmWebCoreModule).GetAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IEpmPermissionChecker>().Forward<EpmPermissionChecker>().ImplementedBy<EpmPermissionChecker>().LifestyleTransient()
            );
            IocManager.Register<IBootstrapper, SouthAfricaLanguagesCreator>();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(SheshaFrameworkModule).Assembly, "Shesha");
            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(SheshaFormsDesignerModule).Assembly, "Shesha");
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(SheshaEnterpriseModule).Assembly,
                moduleName: "Shesha",
                useConventionalHttpVerbs: true);

            Configuration.Modules.ShaApplication().CreateAppServicesForEntities(typeof(EpmWebCoreModule).Assembly, "Epm");
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(EpmWebCoreModule).Assembly,
                moduleName: "Epm",
                useConventionalHttpVerbs: true);
        }
    }
}