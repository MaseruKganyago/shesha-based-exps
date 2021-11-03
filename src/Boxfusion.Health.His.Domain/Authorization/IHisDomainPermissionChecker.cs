using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Domain.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public interface IHisDomainPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsDataAdministrator(Person person);
    }
}
