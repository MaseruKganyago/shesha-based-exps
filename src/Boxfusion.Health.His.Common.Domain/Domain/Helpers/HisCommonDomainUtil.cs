using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.UI;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public class HisCommonDomainUtil
	{
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public static async Task<T> GetEntityAsync<T, TId>(TId id, bool throwException = true) where T : class, IEntity<TId>
        {
            var DynamicRepo = IocManager.Instance.Resolve<IDynamicRepository>();

            var item = await DynamicRepo.GetAsync(typeof(T), id.ToString());

            if (item != null)
                return (T)item;

            if (throwException)
                throw new UserFriendlyException($"{typeof(T).Name} with the specified id `{id}` not found");

            return null;
        }
    }
}
