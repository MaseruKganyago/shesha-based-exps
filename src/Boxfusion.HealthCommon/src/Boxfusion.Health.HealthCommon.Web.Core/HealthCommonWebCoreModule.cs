using System;
using System.Text;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using Boxfusion.Health.HealthCommon.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shesha;
using Shesha.Authentication.JwtBearer;
using Shesha.AzureAD;
using Shesha.Configuration;
using Shesha.Elmah;
using Shesha.Import;
using Shesha.Ldap;
using Shesha.NHibernate;
using Shesha.Scheduler;
using Shesha.Sms.BulkSms;
using Shesha.Sms.Clickatell;
using Shesha.Sms.SmsPortal;
using Shesha.Sms.Xml2Sms;
using Shesha.Web;
using Shesha.Web.FormsDesigner;

namespace Boxfusion.Health.TeleHealth
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(
         typeof(SheshaApplicationModule),
         typeof(SheshaNHibernateModule),
         typeof(AbpAspNetCoreModule),
         typeof(AbpAspNetCoreSignalRModule),
         typeof(AbpAutoMapperModule),
         typeof(HealthCommonModule),
         
         typeof(SheshaSchedulerModule),
         typeof(SheshaImportModule),
         typeof(SheshaWebControlsModule),
         typeof(SheshaLdapModule),
         typeof(SheshaAzureADModule),
         typeof(SheshaFirebaseModule),
         typeof(SheshaElmahModule),

         typeof(SheshaClickatellModule),
         typeof(SheshaBulkSmsModule),
         typeof(SheshaXml2SmsModule),
         typeof(SheshaSmsPortalModule),
         typeof(SheshaFormsDesignerModule)
     )]
    // ReSharper disable once InconsistentNaming
    public class HealthCommonWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public HealthCommonWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                SheshaConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(SheshaApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(5);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HealthCommonWebCoreModule).GetAssembly());
        }
    }
}
