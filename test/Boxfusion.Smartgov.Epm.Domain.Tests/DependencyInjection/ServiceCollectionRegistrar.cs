using Abp.Dependency;
using Microsoft.Extensions.DependencyInjection;
using Shesha.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Tests.DependencyInjection
{
	public static class ServiceCollectionRegistrar
	{
		public static void Register(IIocManager iocManager)
		{
			var services = new ServiceCollection();

			IdentityRegistrar.Register(services);
		}
	}
}
