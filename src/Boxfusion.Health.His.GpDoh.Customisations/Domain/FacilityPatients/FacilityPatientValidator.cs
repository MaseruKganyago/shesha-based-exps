using Abp.Dependency;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.GpDoh.Domain.FacilityPatients
{
    /// <summary>
    /// 
    /// </summary>
    public class FacilityPatientValidator : AbstractValidator<FacilityPatient>
    {
        /// <summary>
        /// 
        /// </summary>
        public FacilityPatientValidator()
        {
            RuleFor(a => a.IdentificationType).NotEmpty().WithMessage("IdentificationType is mandatory.");
            RuleFor(a => a.Gender).NotEmpty().WithMessage("Gender is mandatory.");

            RuleFor(a => a).Custom((entity, context) =>
            {
                if (entity.IdentificationType != (long)RefListIdentificationTypes.NotProvided && entity?.IdentificationType != (long)RefListIdentificationTypes.Other)
                {
                    if (string.IsNullOrWhiteSpace(entity.FirstName))
                        context.AddFailure("First Name is mandatory");
                    if (string.IsNullOrWhiteSpace(entity.LastName))
                        context.AddFailure("Last Name is mandatory.");

                    if (string.IsNullOrWhiteSpace(entity.IdentityNumber))
                        context.AddFailure("I.D. No. is mandatory.");
                    if (entity.DateOfBirth is null)
                        context.AddFailure("Date of birth is mandatory.");

                    if (string.IsNullOrWhiteSpace(entity.HospitalPatientNumber))
                        context.AddFailure("Hospital Patient Number is mandatory.");

                    if (entity.PatientProvince is null)
                        context.AddFailure("Patient Province is mandatory.");
                    if (entity.Nationality is null)
                        context.AddFailure("Nationality is mandatory.");

                    if (entity.IdentificationType == (long)RefListIdentificationTypes.SAID)
                    {
                        if (string.IsNullOrWhiteSpace(entity.IdentityNumber))
                            context.AddFailure("Identity Number is mandatory.");
                        else if (string.IsNullOrEmpty(entity.IdentityNumber)) //TODO: Implement SA ID validation in Helper.Validation
                            context.AddFailure("The specified identify number is not a valid South African ID number.");
                    }
                }
            });
        }
    }
}
