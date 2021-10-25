using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.Domain;
using Shesha.Utilities;

namespace Boxfusion.Health.HealthCommon.Core
{
    /// <summary>
    /// TeleHealthAdmin Permission checker
    /// </summary>
    public class CdmPermissionChecker : ICustomPermissionChecker, ICdmPermissionChecker
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _rolePersonRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CdmPermissionChecker(IRepository<Person, Guid> personRepository, IRepository<ShaRoleAppointedPerson, Guid> rolePersonRepository, IRepository<ShaRoleAppointmentEntity, Guid> appEntityRepository)
        {
            _personRepository = personRepository;
            _rolePersonRepository = rolePersonRepository;
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public async Task<bool> IsGrantedAsync(long userId, string permissionName)
        {
            var person = await _personRepository.GetAll().Where(p => p.User.Id == userId).FirstOrDefaultAsync();
            if (person == null)
                return false;

            // System administrator has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.SystemAdministrator))
                return true;

            // Patient has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.Patient))
                return true;

            // System administrator has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.WardClerk))
                return true;

            // Patient has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.Nurse))
                return true;

            // System administrator has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.UnitManager))
                return true;

            // Patient has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.Matrons))
                return true;

            // System administrator has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.NursingManagerClinicalServicesManager))
                return true;

            // Patient has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.HISTeamMembers))
                return true;

            // System administrator has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.HISManager))
                return true;

            // Patient has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.CEO))
                return true;

            // System administrator has all rights
            if (await IsInAnyOfRoles(person, CdmRoleNames.CaseManagement))
                return true;

            // add custom permission checks here...

            return false;
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public bool IsGranted(long userId, string permissionName)
        {
            return AsyncHelper.RunSync(() => IsGrantedAsync(userId, permissionName));
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        /// <param name="person"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<bool> IsInAnyOfRoles(Person person, params string[] roles)
        {
            return await _rolePersonRepository.GetAll()
                .Where(e => roles.Contains(e.Role.Name) && e.Person == person).AnyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsPatient(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.Patient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsPractitioner(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.Practitioner);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsSystemAdministrator(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.SystemAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsWardClerk(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.WardClerk);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsNurse(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.Nurse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsUnitManager(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.UnitManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsMatrons(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.Matrons);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsNursingManagerClinicalServicesManager(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.NursingManagerClinicalServicesManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsHISTeamMembers(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.HISTeamMembers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsHISManager(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.HISManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsCEO(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.CEO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsCaseManagement(Person person)
        {
            return await IsInAnyOfRoles(person, CdmRoleNames.CaseManagement);
        }
    }
}
