using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using NHibernate;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Products
{
	/// <summary>
	/// 
	/// </summary>
	public static class ProductsHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public static async Task<string> GetProductCode(Guid productId)
		{
			string code;
			var unitOfWork = IocManager.Instance.Resolve<IUnitOfWorkManager>();

			using (var uow = unitOfWork.Begin())
			{
				using (var session = IocManager.Instance.Resolve<ISessionFactory>().OpenSession())
				{
					var query = session
					  .CreateSQLQuery(@"SELECT dbo.fn_His_GetProductCode(:productId)")
					  .SetParameter("productId", productId);

					code = query.UniqueResult<string>();
				}

				await uow.CompleteAsync();
			}

			return code;
		}
	}
}
