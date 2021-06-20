using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public interface IHisAdmisPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsDataAdministrator(Person person);
    }
}
