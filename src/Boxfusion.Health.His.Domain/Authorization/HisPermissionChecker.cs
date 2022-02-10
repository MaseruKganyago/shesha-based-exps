using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.Domain;

namespace Boxfusion.Health.His.Domain.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public class HisPermissionChecker : ICustomPermissionChecker, IHisPermissionChecker
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _rolePersonRepository;
        private readonly IRepository<ShaRoleAppointmentEntity, Guid> _appEntityRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public HisPermissionChecker(IRepository<Person, Guid> personRepository, IRepository<ShaRoleAppointedPerson, Guid> rolePersonRepository, IRepository<ShaRoleAppointmentEntity, Guid> appEntityRepository)
        {
            _personRepository = personRepository;
            _rolePersonRepository = rolePersonRepository;
            _appEntityRepository = appEntityRepository;
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

            // system administrator has all rights
            if (await IsInAnyOfRoles(person, RoleNames.SystemAdministrator))
            {
                if (permissionName == PermissionNames.AdmissionDashboard || permissionName == PermissionNames.Wards)
                {
                    return false;
                }
                return true;
            }
                           
            // data administrator has all rights
            if (await IsInAnyOfRoles(person, RoleNames.GlobalAdmin))
            {
                if (permissionName == PermissionNames.AdmissionDashboard || permissionName == PermissionNames.Wards)
                {
                    return false;
                }
                return true;
            }
            
            // add custom permission checks here...
            if (permissionName == PermissionNames.ApproveReport || permissionName == PermissionNames.DisapproveReport 
                || permissionName == PermissionNames.DailyReports || permissionName == PermissionNames.MonthlyReports)
                return await this.IsApproverLevel1(person) || await this.IsApproverLevel2(person);

            if (permissionName == Shesha.Authorization.PermissionNames.Pages_Users || permissionName == PermissionNames.Wards || permissionName == PermissionNames.Speciality)
                return await this.IsFacilityAdmin(person);
            
            if (permissionName == PermissionNames.SeparateAndTransfer || permissionName == PermissionNames.SubmitsReportsForApproval)
                return await this.IsCapturer(person);

            if (permissionName == PermissionNames.ReportsAndStats || permissionName == PermissionNames.DailyReports 
                || permissionName == PermissionNames.AdmissionDashboard || permissionName == PermissionNames.AllAdmissionDashboard 
                || permissionName == PermissionNames.DailyAdmissionDashboard)
                return await this.IsViewer(person) || await this.IsCapturer(person) || await this.IsManager(person) || await this.IsApproverLevel1(person) || await this.IsApproverLevel2(person);
            if (permissionName == PermissionNames.Administration || permissionName == PermissionNames.CreateFacility)
                return await this.IsFacilityAdmin(person);
            if (permissionName == PermissionNames.Reports)
                return await this.IsManager(person);

            if (permissionName == PermissionNames.DailyAppointmentBooking)
                return await this.IsScheduleManager(person) || await this.IsScheduleFulfiller(person) || await this.IsAdmin(person);

            return false;
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
        public async Task<bool> IsDataAdministrator(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.DataAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.SystemAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public bool IsGranted(long userId, string permissionName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsApproverLevel1(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ApproverLevel1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsApproverLevel2(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ApproverLevel2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsManager(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.Manager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsGlobalAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.GlobalAdmin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsFacilityAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.FacilityAdmin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsCapturer(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.Capturer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsViewer(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.Viewer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsScheduleManager(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ScheduleManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsScheduleFulfiller(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ScheduleFulfiller);
        }
    }
}
