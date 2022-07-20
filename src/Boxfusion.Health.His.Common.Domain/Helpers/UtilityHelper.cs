using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Shesha.Authorization.Users;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Services;
using Shesha.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class UtilityHelper
    {

        /// <summary>
        /// todo: implement automapper convention for nested entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static T GetEntity<T, TId>(EntityDto<TId> dto) where T : class, IEntity<TId>
        {
            return dto == null
                ? null
                : GetEntity<T, TId>(dto.Id);
        }

        /// <summary>
        /// todo: implement automapper convention for nested entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetEntity<T, TId>(TId id) where T : class, IEntity<TId>
        {
            if (id == null || id is Guid guid && guid == Guid.Empty)
                return null;

            var repo = StaticContext.IocManager.Resolve<IRepository<T, TId>>();
            return repo.Get(id);
        }

        /// <summary>
        /// todo: implement automapper convention for nested entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetEntity<T>(long id) where T : class, IEntity<long>
        {
            var repo = StaticContext.IocManager.Resolve<IRepository<T, long>>();
            return repo.Get(id);
        }

        /// <summary>
        /// todo: implement automapper convention for reference lists
        /// </summary>
        /// <param name="refListNamespace"></param>
        /// <param name="refListName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetRefListItemText(string refListNamespace, string refListName, long? value)
        {
            if (value == null)
                return null;
            var helper = StaticContext.IocManager.Resolve<IReferenceListHelper>();
            var displayText = helper.GetItemDisplayText(refListNamespace, refListName, value);
            return displayText ?? "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public static long? GetRefListItemValue(ReferenceListItemValueDto valueDto)
        {
            return valueDto?.ItemValue;
        }

        /// <summary>
        /// todo: implement automapper convention for reference lists
        /// </summary>
        /// <param name="refListNamespace"></param>
        /// <param name="refListName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ReferenceListItemValueDto GetRefListItemValueDto(string refListNamespace, string refListName, long? value)
        {
            return value != null
                ? new ReferenceListItemValueDto
                {
                    ItemValue = value != 0 ? (int?)value.Value : null,
                    Item = GetRefListItemText(refListNamespace, refListName, value)
                }
                : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="role"></param>
        /// <returns></returns>
        public static string GetMultiReferenceStrings<T>(T role) where T : struct, IConvertible
        {
            var result = "";

            if (role.ToString() == "0")
                return result;

            var flag = Enum.Parse(typeof(T), role.ToString()) as Enum;

            foreach (var r in (long[])Enum.GetValues(typeof(T)))
            {
                if ((Convert.ToInt32(flag) & r) == r)
                {
                    var enumName = Enum.GetName(typeof(T), r);
                    var fieldInfo = flag.GetType().GetField(enumName);
                    var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    var descriptionEnumElement = descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : flag.ToString();
                    result += descriptionEnumElement + ", ";
                }
            }
            var index = result.LastIndexOf(',');
            result = result.Remove(index, 1);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="role"></param>
        /// <returns></returns>
        public static List<ReferenceListItemValueDto> GetMultiReferenceListItemValueList<T>(T role) where T : struct, IConvertible
        {
            List<ReferenceListItemValueDto> result = new List<ReferenceListItemValueDto>();

            if (role.ToString() == "0")
                return result;

            var flag = Enum.Parse(typeof(T), role.ToString()) as Enum;

            foreach (var r in (long[])Enum.GetValues(typeof(T)))
            {
                if ((Convert.ToInt32(flag) & r) == r)
                {
                    var value = r;
                    var nameValue = new ReferenceListItemValueDto()
                    {
                        Item = Enum.GetName(typeof(T), r),
                        ItemValue = r
                    };

                    result.Add(nameValue);
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long SetMultiValueReferenceList(List<ReferenceListItemValueDto> input)
        {
            if (input == null || input.Count == 0) return 0;

            List<long?> temp = new List<long?>();

            foreach (var item in input)
            {
                temp.Add((long?)(item?.ItemValue));
            }

            var tt = temp.Aggregate((i, t) => i | t);
            return (long)tt;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dateTime"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string ConvertDateTime(DateTime? dateTime, string format)
        {
            if (dateTime == null)
                return null;

            DateTime dt = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
            return dt.ToString(format);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns></returns>
        public static string CalculateAge(DateTime? birthdate)
        {
            if (birthdate == null)
                return "";

            DateTime now = DateTime.Today;
            int age = now.Year - birthdate.Value.Year;
            if (birthdate > now.AddYears(-age)) age--;

            return age.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetInitials(string name)
        {
            string[] nameSplit = name.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            string initials = "";

            foreach (string item in nameSplit)
            {
                initials += item.Substring(0, 1).ToUpper();
            }

            return initials;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// 
        /// TODO:IH - NAME IS NOT DESCRIPTIVE ENOUGH, IN FACT IS MISLEADING. IN ANY CASE SHOULD RATHER BE SHIFTED TO EntityWithDisplayNameDto ITSELF AS A CONSTRUCTOR. 
        /// LOGIC ALSO NEEDS TO BE UPDATED AS THIS ASSUMES THAT THE DisplayName PROPERTY IS ALWAYS EXISTS AND IS CALLED 'Name'
        public static EntityWithDisplayNameDto<Guid?> MapLocation(object obj)
        {
            var id = obj.GetType().GetProperty("Id");
            var name = obj.GetType().GetProperty("Name");

            return new EntityWithDisplayNameDto<Guid?>((Guid)id.GetValue(obj), (name.GetValue(obj).ToString()));
        }
    }
}
