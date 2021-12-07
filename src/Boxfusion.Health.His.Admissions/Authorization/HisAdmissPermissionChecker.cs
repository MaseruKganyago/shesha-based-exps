using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.Domain;

namespace Boxfusion.Health.His.Admissions.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public class HisAdmissPermissionChecker : ICustomPermissionChecker, IHisAdmissPermissionChecker
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _rolePersonRepository;
        private readonly IRepository<ShaRoleAppointmentEntity, Guid> _appEntityRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public HisAdmissPermissionChecker(IRepository<Person, Guid> personRepository, IRepository<ShaRoleAppointedPerson, Guid> rolePersonRepository, IRepository<ShaRoleAppointmentEntity, Guid> appEntityRepository)
        {
            _personRepository = personRepository;
            _rolePersonRepository = rolePersonRepository;
            _appEntityRepository = appEntityRepository;
        }

        /// inheritedDoc
        public async Task<bool> IsGrantedAsync(long userId, string permissionName)
        {
            var person = await _personRepository.GetAll().Where(p => p.User.Id == userId).FirstOrDefaultAsync();
            if (person == null)
                return false;

            // system administrator has all rights
            if (await IsInAnyOfRoles(person, RoleNames.SystemAdministrator))
                return true;
            
            // data administrator has all rights
            if (await IsInAnyOfRoles(person, RoleNames.DataAdministrator))
                return true;

            // add custom permission checks here...
            if (permissionName == PermissionNames.ApproveReport || permissionName == PermissionNames.DisapproveReport 
                || permissionName == PermissionNames.DailyReports || permissionName == PermissionNames.MonthlyReports)
                return await this.IsApproverLevel1(person) || await this.IsApproverLevel2(person);

            if (permissionName == PermissionNames.CreateFacility || permissionName == PermissionNames.Facilities)
                return await this.IsGlobalAdmin(person);

            if (permissionName == Shesha.Authorization.PermissionNames.Pages_Users)
                return await this.IsFacilityAdmin(person);
            
            if (permissionName == PermissionNames.SeparateAndTransfer || permissionName == PermissionNames.SubmitsReportsForApproval)
                return await this.IsCapturer(person);

            if (permissionName == PermissionNames.DailyReports)
                return await this.IsViewer(person);

            if (permissionName == PermissionNames.ReportsAndStats)
                return await this.IsViewer(person) || await this.IsCapturer(person) || await this.IsManager(person) || await this.IsApproverLevel1(person) || await this.IsApproverLevel2(person);
            if (permissionName == PermissionNames.Administration)
                return await this.IsFacilityAdmin(person);
            return false;
        }

        /// inheritedDoc
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
        public async Task<bool> IsDataAdministrator(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.DataAdministrator);
        }

        public bool IsGranted(long userId, string permissionName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsApproverLevel1(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ApproverLevel1);
        }

        public async Task<bool> IsApproverLevel2(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ApproverLevel2);
        }
        public async Task<bool> IsManager(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.Manager);
        }

        public async Task<bool> IsGlobalAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.GlobalAdmin);
        }

        public async Task<bool> IsFacilityAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.FacilityAdmin);
        }

        public async Task<bool> IsCapturer(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.Capturer);
        }

        public async Task<bool> IsViewer(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.Viewer);
        }
    }
}
