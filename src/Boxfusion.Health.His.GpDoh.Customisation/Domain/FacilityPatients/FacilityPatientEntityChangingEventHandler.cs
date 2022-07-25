﻿using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Runtime.Validation;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Domain.Helpers;
using Boxfusion.Health.His.GpDoh.Domain.FacilityPatients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.GpDoh.Customisation.Domain.FacilityPatients
{
	/// <summary>
	/// Intercepts entity before create/updated and runs validation on the specific fields.
	/// </summary>
	public class FacilityPatientEntityChangingEventHandler: IEventHandler<EntityChangingEventData<GpDohFacilityPatient>>, ITransientDependency
    {
		/// <summary>
		/// 
		/// </summary>
		public FacilityPatientEntityChangingEventHandler()
		{

		}
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
		public void HandleEvent(EntityChangingEventData<GpDohFacilityPatient> eventData)
		{
			ValidateFacilityPatiententity(eventData.Entity);
        }

        private void ValidateFacilityPatiententity(GpDohFacilityPatient entity)
        {
            var validationResults = new List<ValidationResult>();

            if (entity.IdentificationType == null)
                validationResults.Add(new ValidationResult("IdentificationType is mandatory"));

            if (entity.Gender == null)
                validationResults.Add(new ValidationResult("Gender is mandatory"));

            if (entity.IdentificationType != (long)RefListIdentificationTypes.NotProvided && entity?.IdentificationType != (long)RefListIdentificationTypes.Other)
            {
                if (string.IsNullOrWhiteSpace(entity.FirstName))
                    validationResults.Add(new ValidationResult("First Name is mandatory."));
                if (string.IsNullOrWhiteSpace(entity.LastName))
                    validationResults.Add(new ValidationResult("Last Name is mandatory."));

                if (string.IsNullOrWhiteSpace(entity.IdentityNumber))
                    validationResults.Add(new ValidationResult("I.D. No. is mandatory."));
                if (entity.DateOfBirth is null)
                    validationResults.Add(new ValidationResult("Date of birth is mandatory."));

                if (string.IsNullOrWhiteSpace(entity.HospitalPatientNumber))
                    validationResults.Add(new ValidationResult("Hospital Patient Number is mandatory."));

                if (entity.PatientProvince is null)
                    validationResults.Add(new ValidationResult("Patient Province is mandoty."));
                if (entity.Nationality is null)
                    validationResults.Add(new ValidationResult("Nationality is mandoty."));

                if (entity.IdentificationType == (long)RefListIdentificationTypes.SAID)
                {
                    if (string.IsNullOrWhiteSpace(entity.IdentityNumber))
                        validationResults.Add(new ValidationResult("Identity Number is mandatory."));
                    else if (string.IsNullOrEmpty(entity.IdentityNumber)) //TODO: Implement SA ID validation in Helper.Validation
                        validationResults.Add(new ValidationResult("The specified identify number is not a valid South African ID number."));
                }
            }

            if (validationResults.Any())
                throw new AbpValidationException("Please correct the errors and try again", validationResults);
        }
    }
}
