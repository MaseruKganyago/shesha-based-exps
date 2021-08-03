using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public interface IHisPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsDataAdministrator(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsSystemAdministrator(Person person);
    }
}
