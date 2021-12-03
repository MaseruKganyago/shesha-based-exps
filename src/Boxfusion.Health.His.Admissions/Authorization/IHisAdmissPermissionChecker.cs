using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public interface IHisAdmissPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsDataAdministrator(Person person);
        Task<bool> IsApproverLevel1(Person person);
        Task<bool> IsApproverLevel2(Person person);
    }
}
