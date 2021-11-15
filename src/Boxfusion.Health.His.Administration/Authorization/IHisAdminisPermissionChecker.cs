﻿using Shesha.Domain;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Administration.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public interface IHisAdminisPermissionChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> IsDataAdministrator(Person person);
    }
}
