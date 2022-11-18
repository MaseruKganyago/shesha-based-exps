using Abp.Hangfire;
using Abp.Hangfire.Configuration;
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
    [DependsOn(typeof(EpmWebCoreModule), typeof(AbpHangfireAspNetCoreModule))]
    public class SheshaWebHostModule: AbpModule
    {
		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(typeof(SheshaWebHostModule).GetAssembly());
		}
		public override void PreInitialize()
		{
			Configuration.BackgroundJobs.UseHangfire();
		}
	}
}
