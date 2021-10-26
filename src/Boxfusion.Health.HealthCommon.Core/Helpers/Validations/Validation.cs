using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Authorization;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.Authorization.Users;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        public static void EmailValidation(string identityNumber)
        {
            //if (identityNumber != null)
            //{
            //    var patientExist = await _repository.FirstOrDefaultAsync(x => x.IdentityNumber == input.IdentityNumber);
            //    throw new UserFriendlyException("User with provided identity number already exists");
            //}
        }

        /// <summary>
        /// Validates Guid Id and check is it's not empty or null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static void ValidateIdWithException(Guid? id, string errorMessage)
        {
            if (id == null || id is Guid guid && guid == Guid.Empty)
                throw new UserFriendlyException(errorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static object ValidateId(Guid? id)
        {
            if (id == null || id is Guid guid && guid == Guid.Empty)
                return null;

            return id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        public static void ValidateConfirmPassword(string password, string confirmPassword)
        {
            if (!password.Equals(confirmPassword))
                throw new UserFriendlyException("Confirm password does not match password");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputName"></param>
        public static void ValidateText(string input, string inputName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new UserFriendlyException($"{inputName} cannot be empty");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputName"></param>
        public static void ValidateNullableType(object input, string inputName)
        {
            if (input == null)
                throw new UserFriendlyException($"{inputName} cannot be empty");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputName"></param>
        public static void ValidateReflist(ReferenceListItemValueDto input, string inputName)
        {
            if (input?.ItemValue == null)
                throw new UserFriendlyException($"{inputName} cannot be empty");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="name"></param>
        public static void ValidateEntityWithDisplayNameDto(List<EntityWithDisplayNameDto<Guid>> input, string name)
        {
            if ((input.Any(x => x?.Id == null)))
                throw new UserFriendlyException($"{name} Id cannot be empty");
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="hospitals"></param>
        //public static void ValidateHospital(List<HospitalInput> hospitals)
        //{
        //    if ((hospitals.Any(x => x?.Id == null)))
        //        throw new UserFriendlyException("Facility Id cannot be empty");
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        //public static void ValidateWard(PersonFhirBaseInput input)
        //{
        //    if (input.Roles.Select(x => x.Id).ToList().Intersect(CdmRoleIds.ClinicalIds).Count() > 0)
        //    {
        //        if ((input.Wards.Any(x => x?.Id == null)))
        //            throw new UserFriendlyException("Ward Id cannot be empty");
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public static void ValidateNumberOfHospitalsForNonCEO(PersonFhirBaseInput input)
        {
            if (!input.Roles.Any(x => x.Id == CdmRoleIds.CEOId))
            {
                if (input.Hospitals.Count > 1)
                    throw new UserFriendlyException("If user is not a CEO, you can only select one facility");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public static void ValidateRolesNotToAssignWard(PersonFhirBaseInput input)
        {
            if (input.Roles.Select(x => x.Id).ToList().Intersect(CdmRoleIds.nonClinicalIds).Count() > 0)
            {
                if (input.Wards.Count > 0)
                    throw new UserFriendlyException("A CEO or HIS Team Member or HIS Manager or Case Management or System Administrator cannot be assigned to a ward");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async static Task ValidateEmail(string username)
        {
            var _userRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<User, long>>();
            //Validate if the submitted username doesn't already exists
            var userNameExists = await _userRepository.FirstOrDefaultAsync(x => x.UserName == username);
            if (userNameExists != null)
                throw new UserFriendlyException("The specified username already exists.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        public static bool IsValidIdentityNumber(string identityNumber)
        {
            // assume everything is correct and if it later turns out not to be, just set this to false
            var correct = true;

            //Ref: http://www.sadev.co.za/content/what-south-african-id-number-made
            // SA ID Number have to be 13 digits, so check the length
            if (identityNumber.Length != 13 || !IsNumeric(identityNumber))
                return false;

            // get first 6 digits as a valid date
            DateTime fromDateValue;
            var tempDate = identityNumber.Substring(2, 2) + "-" + identityNumber.Substring(4, 2) + "-" + identityNumber.Substring(0, 2);
            var formats = "MM-dd-yy";
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out fromDateValue)) { }
            else return false;

            // get the gender
            correct = int.TryParse(identityNumber.Substring(6, 4), out int result);
            if (!correct) return false;

            // get country ID for citzenship
            correct = int.TryParse(identityNumber.Substring(10, 1), out int citizenship);
            if (correct)
                if (citizenship < 0 || citizenship > 1) return false;

            // apply Luhn formula for check-digits
            return checkLuhn(identityNumber);
        }

        private static bool IsNumeric(string number)
        {
            if (Regex.IsMatch(number, @"^\d+$"))
                return true;
            else
                return false;
        }

        //Luhn algorithm
        private static bool checkLuhn(String cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
    }
}
