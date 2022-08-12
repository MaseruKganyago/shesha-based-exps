using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core
{
    /// <summary>
    /// Permission checker
    /// </summary>
    public interface ICdmPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsPatient(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        Task<bool> IsInAnyOfRoles(Person person, params string[] roles);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsPractitioner(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        bool IsGranted(long userId, string permissionName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(long userId, string permissionName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsSystemAdministrator(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsWardClerk(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsNurse(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsUnitManager(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsMatrons(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsNursingManagerClinicalServicesManager(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsHISTeamMembers(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsHISManager(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsCEO(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsCaseManagement(Person person);
        Task<bool> IsAdmin(Person person);
    }
}
