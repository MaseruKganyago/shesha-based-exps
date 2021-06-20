using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.Domain.Authorization
{
    /// <summary>
    /// HealthDomain Permission checker
    /// </summary>
    public interface IHealthDomainPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsDataAdministrator(Person person);
    }
}
