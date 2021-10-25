using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize()]
    public abstract class CdmAppServiceBase : SheshaAppServiceBase
    {

        private readonly ICdmPermissionChecker _permissionChecker;

        /// <summary>
        /// 
        /// </summary>
        protected CdmAppServiceBase()
        {
            _permissionChecker = Abp.Dependency.IocManager.Instance.Resolve<ICdmPermissionChecker>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doTask"></param>
        /// <returns></returns>
        protected async Task<T> DoTaskAsync<T>(Func<Task<T>> doTask)
        {
            try { return await doTask(); }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doTask"></param>
        /// <returns></returns>
        protected async Task DoTaskAsync(Func<Task> doTask)
        {
            try { await doTask(); }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// This is used to authenticate if the user role has rights to access the api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doTask">Logic to be executed</param>
        /// <param name="errorMessage">Custom error message</param>
        /// <param name="roleNames">The roles of people who are supposed to access the api</param>
        /// <returns></returns>
        protected async Task<T> DoTaskWithAuthAsync<T>(Func<Task<T>> doTask, string errorMessage, params string[] roleNames)
        {
            return await DoTaskAsync(async () =>
            {
                var person = await GetCurrentPersonAsync();
                var isAuthorized = await _permissionChecker.IsInAnyOfRoles(person, roleNames);

                if (isAuthorized)
                    return await doTask();    //executes the logic
                else
                    throw new UserFriendlyException(errorMessage ?? "You are not authorized to access this api");
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Patient> GetCurrentPatientAsync()
        {
            return await DoTaskAsync<Patient>(async () =>
            {
                var entity = await GetCurrentPersonAsync() as Patient;
                if (entity == null)
                    throw new UserFriendlyException("Account is not found !!");

                return entity;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<CdmPractitioner> GetCurrentPractitionerAsync()
        {
            return await DoTaskAsync<CdmPractitioner>(async () =>
            {
                var entity = await GetCurrentPersonAsync();
                if (entity.GetType().BaseType.Name != typeof(CdmPractitioner).Name)
                    throw new UserFriendlyException("Account is not found !!");

                return entity as CdmPractitioner;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Person> GetCurrentLoggedPersonAsync()
        {
            return await DoTaskAsync<Person>(async () =>
            {
                var entity = await GetCurrentPersonAsync();
                if (entity == null)
                    throw new UserFriendlyException("Account is not found !!");

                return entity;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Person> ValidatePermissionsOfCurrentLoggedInPerson()
        {
            var person = await GetCurrentLoggedPersonAsync();
            var isPratictionerOrSystemAdmin = await _permissionChecker.IsInAnyOfRoles(person, CdmRoleNames.PractitionerAppAccessRoles);
            if (!isPratictionerOrSystemAdmin)
                throw new UserFriendlyException((int)HttpStatusCode.Forbidden, "Only a practitoner or system administrator have access");
            return person;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Person> ValidatePermissionsForAllPerson()
        {
            var person = await GetCurrentLoggedPersonAsync();
            var isPratictionerOrSystemAdmin = await _permissionChecker.IsInAnyOfRoles(person, CdmRoleNames.AllAccessRoles);
            if (!isPratictionerOrSystemAdmin)
                throw new UserFriendlyException((int)HttpStatusCode.Forbidden, "Only a practitoner or system administrator have access");
            return person;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Person> ValidatePermissionsForAdmin()
        {
            var person = await GetCurrentLoggedPersonAsync();
            var isSystemAdmin = await _permissionChecker.IsInAnyOfRoles(person, CdmRoleNames.SystemAdministrator);
            if (!isSystemAdmin)
                throw new UserFriendlyException((int)HttpStatusCode.Forbidden, "Only a system administrator have access");
            return person;
        }
    }
}
