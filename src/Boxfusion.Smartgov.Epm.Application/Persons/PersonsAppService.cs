using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Boxfusion.Smartgov.Epm.Persons.Dtos;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha.Authorization.Users;
using Shesha.Domain;
using Shesha.Domain.Enums;
using Shesha.DynamicEntities.Dtos;
using Shesha.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Persons
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Epm/[controller]")]
	public class PersonsAppService : EpmAppServiceBase
	{
		private readonly IRepository<Person, Guid> _repository;
		private readonly IRepository<ShaRoleAppointedPerson, Guid> _shaRoleAppointedPerson;

		public PersonsAppService(IRepository<Person, Guid> repository, IRepository<ShaRoleAppointedPerson, Guid> shaRoleAppointedPerson)
		{
			_repository = repository;
			_shaRoleAppointedPerson = shaRoleAppointedPerson;
		}

		[HttpPost, Route("CreateWithUserAccount")]
		public async Task<DynamicDto<Person, Guid>> CreateWithUserAccountAsync(CreatePersonAccountDto input)
		{
			var validationResults = new List<ValidationResult>();

			// email and mobile number must be unique
			if (await MobileNoAlreadyInUse(input.MobileNumber, null))
				validationResults.Add(new ValidationResult("Specified mobile number already used by another person"));
			if (await EmailAlreadyInUse(input.EmailAddress, null))
				validationResults.Add(new ValidationResult("Specified email already used by another person"));

			if (validationResults.Any())
				throw new AbpValidationException("Please correct the errors and try again", validationResults);

			// Creating User Account to enable login into the application
			var userManager = IocManager.Resolve<UserManager>();
			User user = await userManager.CreateUser(
					input.UserName,
					input.TypeOfAccount?.ItemValue == (long)RefListTypeOfAccount.Internal,
					input.Password,
					input.PasswordConfirmation,
					input.FirstName,
					input.LastName,
					input.MobileNumber,
					input.EmailAddress);

			// Creating Person entity
			var practitioner = new Person()
			{
				FirstName = input.FirstName,
				LastName = input.LastName,
				MobileNumber1 = input.MobileNumber,
				EmailAddress1 = input.EmailAddress,
				User = user
			};

			await _repository.InsertAsync(practitioner);

			CurrentUnitOfWork.SaveChanges();

			return await MapToDynamicDtoAsync<Person, Guid>(practitioner);
		}

		[HttpGet, Route("[action]")]
		public async Task<PersonIdRoleNamesDto> GetCurrentLoggedInPersonIdRoleNames()
		{
			var person = await GetCurrentPersonAsync();

			var roles = await _shaRoleAppointedPerson.GetAllListAsync(a => a.Person.Id == person.Id);
			var roleNames = roles.Select(a => a.Role.Name).ToList();

			return new PersonIdRoleNamesDto()
			{
				Id = person.Id,
				Roles = roleNames
			};
		}


		/// <summary>
		/// Checks is specified mobile number already used by another person
		/// </summary>
		/// <returns></returns>
		private async Task<bool> MobileNoAlreadyInUse(string mobileNo, Guid? id)
		{
			if (string.IsNullOrWhiteSpace(mobileNo))
				return false;

			return await _repository.GetAll().AnyAsync(e =>
				e.MobileNumber1.Trim().ToLower() == mobileNo.Trim().ToLower() && (id == null || e.Id != id));
		}

		/// <summary>
		/// Checks is specified email already used by another person
		/// </summary>
		/// <returns></returns>
		private async Task<bool> EmailAlreadyInUse(string email, Guid? id)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			return await _repository.GetAll().AnyAsync(e =>
				e.EmailAddress1.Trim().ToLower() == email.Trim().ToLower() && (id == null || e.Id != id));
		}
	}
}
