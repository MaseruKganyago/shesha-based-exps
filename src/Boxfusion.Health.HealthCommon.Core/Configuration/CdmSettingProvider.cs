using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Boxfusion.Health.HealthCommon.Core.Configuration
{
    /// <summary>
    /// Defines Cdm settings
    /// </summary>
    public class CdmSettingProvider : SettingProvider
    {
        /// <summary>
        /// 
        /// </summary>
        protected string LocalizationSourceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CdmSettingProvider()
        {
            LocalizationSourceName = "Cdm";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new []
            {
                new SettingDefinition(CdmSettingNames.CustomerSecret,false.ToString(),L("CustomerSecret"),scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.CustomerKey, false.ToString(), L("CustomerKey"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.OrganisationIdentifier, false.ToString(), L("OrganisationIdentifier"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.FacilityIdentifier, false.ToString(), L("FacilityIdentifier"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.AppCertificate, false.ToString(), L("AppCertificate"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.AppId, false.ToString(), L("AppId"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.MedpraxUsername, false.ToString(), L("MedpraxUsername"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.MedpraxPassword, false.ToString(), L("MedpraxPassword"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                new SettingDefinition(CdmSettingNames.MedpraxBaseAddress, false.ToString(), L("MedpraxBaseAddress"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}
