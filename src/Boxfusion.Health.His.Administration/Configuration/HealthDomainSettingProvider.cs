using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Boxfusion.Health.Domain.Configuration
{
    /// <summary>
    /// Defines HealthDomain settings
    /// </summary>
    public class HealthDomainSettingProvider : SettingProvider
    {
        protected string LocalizationSourceName { get; set; }

        public HealthDomainSettingProvider()
        {
            LocalizationSourceName = "HealthDomain";
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
            {
                //new SettingDefinition(HealthDomainSettingNames.RevisitPeriod, (7*24*60).ToString() /* 7 days */, L("DSD_NPO_RevisitPeriod"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}
