using Abp.Modules;
using Abp.Reflection.Extensions;
using Boxfusion.Smartgov.Epm;
using Boxfusion.Smartgov.Epm.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Shesha.Configuration;
using Shesha.Web.FormsDesigner;

namespace Boxfusion.Smartgov.Epm.Web.Host.Startup
{
    [DependsOn(typeof(EpmWebCoreModule), typeof(SheshaFormsDesignerModule))]
    public class SheshaWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SheshaWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            base.PreInitialize();
            /*
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.Auditing.IsEnabled = false;
            */
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SheshaWebHostModule).GetAssembly());
        }
    }
}
