using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Authorization;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Authorization.Users;
using Shesha.AutoMapper.Dto;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Domain.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class Validation
    {
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
        public static bool IsValidateId(Guid? id)
        {
            if (id == null || id is Guid guid && guid == Guid.Empty)
                return false;

            return true;
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
        /// <exception cref="UserFriendlyException"></exception>
        public static void CheckPasswordComplexity(string password)
        {
            var regex = new Regex(@"
                (?=.*[0-9]) #Must contain numbers
                 (?=.*[a-zA-Z]) #Must contain lowercase or uppercase letters
                 (?=([\x21-\x7e]+)[^a-zA-Z0-9]) #Must include special symbols
                 .{8,30} #At least 8 characters, at most 30 characters
                ", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            if (!regex.Match(password).Success)
                throw new UserFriendlyException
                ("Please ensure that your password contains at least 8 characters, include a numerical value and a special character ");

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
        public static void ValidateEntityWithDisplayNameDto(List<EntityWithDisplayNameDto<Guid?>> input, string name)
        {
            if ((input.Any(x => x?.Id == null)))
                throw new UserFriendlyException($"{name} Id cannot be empty");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="name"></param>
        public static void ValidateEntityWithDisplayNameDto(EntityWithDisplayNameDto<Guid?> input, string name)
        {
            if ((input?.Id == null || input.Id is Guid guid && guid == Guid.Empty))
                throw new UserFriendlyException($"{name} Id cannot be empty");
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