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
        Task<bool> IsGlobalAdmin(Person person);
        Task<bool> IsFacilityAdmin(Person person);
        Task<bool> IsCapturer(Person person);
        Task<bool> IsViewer(Person person);
        Task<bool> IsApproverLevel1(Person person);
        Task<bool> IsApproverLevel2(Person person);
        Task<bool> IsManager(Person person);
    }
}
