using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.Domain;

namespace Boxfusion.Health.His.Common.Authorization
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

            if (person.User.UserName.ToLower() == "admin")
                return true;

            switch (permissionName)
            {
                case CommonPermissionsObsolete.BookingAdministration:
                    return await IsBookingAdministrator(person);
                case CommonPermissionsObsolete.ScheduleManagement:
                    return await IsScheduleManager(person);
                case CommonPermissionsObsolete.SystemAdministration:
                    return await IsAdmin(person);
                case CommonPermissionsObsolete.UserAdministration:
                    return await IsDataAdministrator(person);
                default:
                    return false;
            }

            //// system administrator has all rights
            //if (await IsInAnyOfRoles(person, CommonRoles.SystemAdministrator))
            //{
            //    if (permissionName == CommonPermissionsObsolete.AdmissionDashboard || permissionName == CommonPermissionsObsolete.Wards)
            //    {
            //        return false;
            //    }
            //    return true;
            //}

            //// data administrator has all rights
            //if (await IsInAnyOfRoles(person, CommonRoles.GlobalAdmin))
            //{
            //    if (permissionName == CommonPermissionsObsolete.AdmissionDashboard || permissionName == CommonPermissionsObsolete.Wards)
            //    {
            //        return false;
            //    }
            //    return true;
            //}

            //switch (permissionName)
            //{
            //    case CommonPermissionsObsolete.Administration:


            //    default:
            //}
            //if (permissionName == CommonPermissionsObsolete.ScheduleManager
            //    || permissionName == CommonPermissionsObsolete.BookAppointment
            //    || permissionName == CommonPermissionsObsolete.RescheduleAppointment)
            //    return await this.IsScheduleManager(person);

            //// add custom permission checks here...
            //if (permissionName == CommonPermissionsObsolete.ApproveReport || permissionName == CommonPermissionsObsolete.DisapproveReport 
            //    || permissionName == CommonPermissionsObsolete.DailyReports || permissionName == CommonPermissionsObsolete.MonthlyReports)
            //    return await this.IsApproverLevel1(person) || await this.IsApproverLevel2(person);

            //if (permissionName == Shesha.Authorization.PermissionNames.Pages_Users || permissionName == CommonPermissionsObsolete.Wards || permissionName == CommonPermissionsObsolete.Speciality)
            //    return await this.IsFacilityAdmin(person);

            //if (permissionName == CommonPermissionsObsolete.SeparateAndTransfer || permissionName == CommonPermissionsObsolete.SubmitsReportsForApproval)
            //    return await this.IsCapturer(person);

            //if (permissionName == CommonPermissionsObsolete.ReportsAndStats || permissionName == CommonPermissionsObsolete.DailyReports 
            //    || permissionName == CommonPermissionsObsolete.AdmissionDashboard || permissionName == CommonPermissionsObsolete.AllAdmissionDashboard 
            //    || permissionName == CommonPermissionsObsolete.DailyAdmissionDashboard)
            //    return await this.IsViewer(person) || await this.IsCapturer(person) || await this.IsManager(person) || await this.IsApproverLevel1(person) || await this.IsApproverLevel2(person);
            //if (permissionName == CommonPermissionsObsolete.Administration || permissionName == CommonPermissionsObsolete.CreateFacility)
            //    return await this.IsFacilityAdmin(person);
            //if (permissionName == CommonPermissionsObsolete.Reports)
            //    return await this.IsManager(person);

            //if (permissionName == CommonPermissionsObsolete.DailyAppointmentBooking)
            //    return await this.IsScheduleManager(person) || await this.IsScheduleFulfiller(person) || await this.IsAdmin(person);

            //if (permissionName == CommonPermissionsObsolete.BookAppointment)
            //    return await this.IsScheduleManager(person) || await this.IsAdmin(person);

            //if (permissionName == CommonPermissionsObsolete.RescheduleAppointment)
            //    return await this.IsScheduleManager(person) || await this.IsAdmin(person);

            //return false;
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
            return await IsInAnyOfRoles(person, CommonRoles.DataAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.SystemAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsScheduleManager(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.ScheduleManager);
        }
        public async Task<bool> IsBookingAdministrator(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.BookingAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsGlobalAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.GlobalAdmin);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsApproverLevel1(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.ApproverLevel1);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsApproverLevel2(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.ApproverLevel2);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsManager(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.Manager);
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsFacilityAdmin(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.FacilityAdmin);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsCapturer(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.Capturer);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsViewer(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.Viewer);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public async Task<bool> IsScheduleFulfiller(Person person)
        //{
        //    return await IsInAnyOfRoles(person, CommonRoles.ScheduleFulfiller);
        //}
    }
}
