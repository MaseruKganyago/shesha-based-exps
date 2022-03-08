using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Boxfusion.Health.His.Bookings.Configuration
{
    /// <summary>
    /// Defines Health.His settings
    /// </summary>
    public class HisBookingsSettingProvider : SettingProvider
    {
        /// <summary>
        /// 
        /// </summary>
        protected string LocalizationSourceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HisBookingsSettingProvider()
        {
            LocalizationSourceName = "HisBookings";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
            {
                //new SettingDefinition(Health.HisSettingNames.RevisitPeriod, (7*24*60).ToString() /* 7 days */, L("DSD_NPO_RevisitPeriod"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}
