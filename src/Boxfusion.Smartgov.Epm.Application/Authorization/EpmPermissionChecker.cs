using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.Domain;

namespace SheshaBased.Epm.Authorization
{
	/// <summary>
	/// Health.His Permission checker
	/// </summary>
	public class EpmPermissionChecker : ICustomPermissionChecker, IEpmPermissionChecker
	{
		private readonly IRepository<Person, Guid> _personRepository;
		private readonly IRepository<ShaRoleAppointedPerson, Guid> _rolePersonRepository;
		private readonly IRepository<ShaRoleAppointmentEntity, Guid> _appEntityRepository;

		/// <summary>
		/// Default constructor
		/// </summary>
		public EpmPermissionChecker(IRepository<Person, Guid> personRepository, IRepository<ShaRoleAppointedPerson, Guid> rolePersonRepository, IRepository<ShaRoleAppointmentEntity, Guid> appEntityRepository)
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
				case EpmPermissions.SystemAdministration:
					return await IsAdmin(person);
				case EpmPermissions.UserAdministration:
					return await IsDataAdministrator(person);
				default:
					return false;
			}
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
			return await IsInAnyOfRoles(person, EpmRoles.DataAdministrator);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public async Task<bool> IsAdmin(Person person)
		{
			return await IsInAnyOfRoles(person, EpmRoles.SystemAdministrator);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public async Task<bool> IsGlobalAdmin(Person person)
		{
			return await IsInAnyOfRoles(person, EpmRoles.GlobalAdmin);
		}
	}
}
