using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Authorization
{
    /// <summary>
    /// Permission checker
    /// </summary>
    public interface IEpmPermissionChecker
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
        Task<bool> IsGlobalAdmin(Person person);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsAdmin(Person person);
    }
}
