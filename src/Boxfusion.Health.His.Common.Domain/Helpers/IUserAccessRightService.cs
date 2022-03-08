using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Domain.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserAccessRightService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        Task<bool> IsPersonAssignedToHospital(Guid wardId, Person currentPerson);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        Task<bool> IsPersonAssignedToWard(Guid wardId, Person currentPerson);
    }
}
