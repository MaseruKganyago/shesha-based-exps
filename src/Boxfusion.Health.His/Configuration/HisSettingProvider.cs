using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Boxfusion.Health.His.Configuration
{
    /// <summary>
    /// Defines Health.His settings
    /// </summary>
    public class HisSettingProvider : SettingProvider
    {
        protected string LocalizationSourceName { get; set; }

        public HisSettingProvider()
        {
            LocalizationSourceName = "His";
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
            {
                //new SettingDefinition(Health.HisSettingNames.RevisitPeriod, (7*24*60).ToString() /* 7 days */, L("DSD_NPO_RevisitPeriod"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}
