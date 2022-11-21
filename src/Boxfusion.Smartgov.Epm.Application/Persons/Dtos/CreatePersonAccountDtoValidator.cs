using Abp.Dependency;
using Abp.Domain.Repositories;
using FluentValidation;
using GraphQL;
using NHibernate.Linq;
using Shesha.Domain;
using Shesha.Persons;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Persons.Dtos
{
    public class CreatePersonAccountDtoValidator : AbstractValidator<CreatePersonAccountDto>
    {
        public CreatePersonAccountDtoValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("First Name is mandatory.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Last Name is mandatory.");
            RuleFor(c => c.TypeOfAccount).NotNull().WithMessage("Type of Account is mandatory.");
        }
    }
}
