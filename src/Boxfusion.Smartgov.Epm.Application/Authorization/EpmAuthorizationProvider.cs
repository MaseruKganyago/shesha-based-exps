using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Abp.Authorization;
using Abp.Localization;

namespace Boxfusion.Smartgov.Epm.Authorization
{
    /// <summary>
    /// Authorization Provider
    /// </summary>
    public class EpmAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// Register permissions declared in the <see cref="CommonPermissionsObsolete"/> class
        /// </summary>
        /// <param name="context"></param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var permissions = typeof(EpmPermissions)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.IsLiteral)
                .Select(p => new
                {
                    Name = p.GetRawConstantValue()?.ToString(),
                    Description = p.GetCustomAttribute<DescriptionAttribute>()?.Description
                })
                .ToList();

            foreach (var permission in permissions)
            {
                context.CreatePermission(permission.Name, L(permission.Description ?? permission.Name));
            }
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, "Epm");
        }
    }
}
