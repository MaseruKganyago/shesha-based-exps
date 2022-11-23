using Abp.Domain.Uow;
using NHibernate;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Components
{
	/// <summary>
	/// 
	/// </summary>
	public static class ComponentsHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="compoentId"></param>
		/// <returns></returns>
		public static async Task<string> GetComponentNodePath(Guid compoentId)
		{
			string path;
			var unitOfWork = StaticContext.IocManager.Resolve<IUnitOfWorkManager>();

			using (var uow = unitOfWork.Begin())
			{
				using (var session = StaticContext.IocManager.Resolve<ISessionFactory>().OpenSession())
				{
					var query = session
					  .CreateSQLQuery(@"SELECT [dbo].[fn_Epm_GetNodePath](:compoentId)")
					  .SetParameter("compoentId", compoentId);

					path = query.UniqueResult<string>();
				}

				await uow.CompleteAsync();
			}

			return path;
		}
	}
}
