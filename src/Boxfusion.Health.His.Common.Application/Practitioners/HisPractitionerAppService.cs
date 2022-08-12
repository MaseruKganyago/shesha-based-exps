using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Domain;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Linq;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shesha.Persons;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using Shesha.Authorization.Users;
using Shesha.Domain.Enums;
using Boxfusion.Health.His.Common.Authorization;
using Abp.Dependency;

namespace Boxfusion.Health.His.Common.Practitioners
{
    /// <summary>
    /// Extending the default Crud AppService with a couple of User management related end-points.
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Common/[controller]")]
    public class HisPractitionerAppService : HisAppServiceBase //DynamicCrudAppService<HisPractitioner, DynamicDto<HisPractitioner, Guid>, Guid>, ITransientDependency
    {
        IRepository<HisPractitioner, Guid> _repository;

        public HisPractitionerAppService(IRepository<HisPractitioner, Guid> repository) //: base(repository)
        {
            _repository = repository;
        }

        [HttpPost, Route("CreateWithUserAccount")]
        //[AbpAuthorize(CommonPermissions.UserManagement.Create)]
        public async Task<DynamicDto<HisPractitioner, Guid>> CreateWithUserAccountAsync(CreatePersonAccountDto input)
        {
            //CheckCreatePermission();

            // Performing additional validations
            var validationResults = new List<ValidationResult>();

            if (input.TypeOfAccount == null)
                validationResults.Add(new ValidationResult("Type of account is mandatory"));

            if (string.IsNullOrWhiteSpace(input.FirstName))
                validationResults.Add(new ValidationResult("First Name is mandatory"));
            if (string.IsNullOrWhiteSpace(input.LastName))
                validationResults.Add(new ValidationResult("Last Name is mandatory"));

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
            var practitioner = new HisPractitioner()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                MobileNumber1 = input.MobileNumber,
                EmailAddress1 = input.EmailAddress,
                User = user,
            };

            await _repository.InsertAsync(practitioner);

            CurrentUnitOfWork.SaveChanges();

            return await this.MapToDynamicDtoAsync<HisPractitioner, Guid>(practitioner);
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
